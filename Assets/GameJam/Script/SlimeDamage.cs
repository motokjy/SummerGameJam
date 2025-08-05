using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    public int hp = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bow"))
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}