using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public float speed = 5f;
    public float deceleration = 10f;
    public GameObject clearText;

    private bool isCleared = false;
    private float currentSpeed = 0f;

    void Start()
    {
        clearText.SetActive(false);
    }

    void Update()
    {
        if (!isCleared)
        {
            if (Input.GetKey(KeyCode.D))
            {
                currentSpeed = speed; // Dキー押しで速度セット
            }
            else
            {
                // Dキー離したら徐々に減速
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
            }

            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal") && !isCleared)
        {
            clearText.SetActive(true);
            isCleared = true;
            currentSpeed = 0f; // ゴールに触れたら即停止
        }
    }
}