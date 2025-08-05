using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    [SerializeField] GameObject Hint;
    [SerializeField] GameObject clearText; // クリアテキスト用オブジェクトを追加
    public int hp = 3;

    void Start()
    {
        Hint.SetActive(true);
        clearText.SetActive(false); // 最初は非表示
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bow"))
        {
            hp--;
            if (hp <= 0)
            {
                if (clearText != null)
                    clearText.SetActive(true); // クリアテキストを表示
                Hint.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}