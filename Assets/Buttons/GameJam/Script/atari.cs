using UnityEngine;

public class EnemyVanishOnHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bow"))
        {
            Debug.Log("竹刀が当たった！敵を消去します");
            Destroy(gameObject); // 敵自身を消す
        }
    }
}