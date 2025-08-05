using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    public float xSpeed;
    public bool rightFacing;
    [SerializeField] private float jumpPower = 6.0f;
    public bool isGrounded = false; // 地面判定用
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rightFacing = true;
    }
    void Update()
    {
        MoveUpdate();
        JumpUpdate();
    }
    private void MoveUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xSpeed = 6.0f;
            rightFacing = true;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            xSpeed = -6.0f;
            rightFacing = false;
            spriteRenderer.flipX = true;
        }
        else
        {
            xSpeed = 0.0f;
        }
    }
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpPower);
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 velocity = rigidbody2D.linearVelocity;
        velocity.x = xSpeed;
        rigidbody2D.linearVelocity = velocity;
    }
    // 地面判定（タグは"Ground"に設定してください）
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("地面設置中");
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