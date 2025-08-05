using UnityEngine;

public class gamengai : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slime"))
        {
            Destroy(other.gameObject); // スライムを消す
            Debug.Log("スライムに命中！");
        }
    }
}