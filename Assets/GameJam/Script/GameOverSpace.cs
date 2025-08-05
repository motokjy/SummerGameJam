using UnityEngine;

public class GameOverSpace : MonoBehaviour
{
    [SerializeField] private GameObject Hint;
    [SerializeField] private GameObject GameOver;
    void Start()
    {
        if (Hint != null) Hint.SetActive(true);
        if (GameOver != null) GameOver.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slime"))
        {
            Debug.Log("ゲームオーバー");
            if (Hint != null) Hint.SetActive(false);
            if (GameOver != null) GameOver.SetActive(true);
        }
    }
}
