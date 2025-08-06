using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    [SerializeField] GameObject Slime; // スライム（敵キャラ）

    public int hp = 3;

    void Start()
    {
        if (Slime != null)
            Slime.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bow"))
        {
            hp--;
            if (hp <= 0)
            {
                if (Slime != null)
                    Slime.SetActive(false); // スライムは即消す
                // ここでコルーチンやUI処理はしない
            }
        }
    }
}