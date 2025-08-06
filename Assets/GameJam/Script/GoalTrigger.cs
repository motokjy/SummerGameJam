using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject clearText; // "Clear" を表示するオブジェクト

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            clearText.SetActive(true);
        }
    }
}