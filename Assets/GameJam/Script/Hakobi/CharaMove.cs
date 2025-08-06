using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    [HideInInspector] public float xSpeed;
    [HideInInspector] public bool rightFacing;
    [SerializeField] private float jumpPower = 6.0f;

    private bool isGrounded = false; // 地面判定用

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rightFacing = true;
    }

    void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xSpeed = 6.0f;
            rightFacing = true;
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidbody2D.linearVelocity;
        velocity.x = xSpeed;
        rigidbody2D.linearVelocity = velocity;
    }

    // 地面判定（タグは"Ground"に設定してください）
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}