using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject goalText; // ゴールテキスト用オブジェクト

    void Start()
    {
        if (goalText != null)
            goalText.SetActive(false); // 最初は非表示
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (goalText != null)
                goalText.SetActive(true); // ゴールテキストを表示
        }
    }
}
