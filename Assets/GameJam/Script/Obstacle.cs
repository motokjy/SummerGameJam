using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Aキーが反応しました");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}