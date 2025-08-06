using UnityEngine;

public class kaihiC : MonoBehaviour
{
    //junpForce調整可能　400～600；- velocity を使うことで自然なジャンプ挙動が作れるよ
    public float jumpForce = 400f;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 横方向に自動移動
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Aキーが反応しました");
            rb.linearVelocity = Vector2.up * jumpForce * Time.deltaTime;
        }
    }
}