using UnityEngine;
using System.Collections;

public class GameOverSpace : MonoBehaviour
{
    [SerializeField] private GameObject Hint;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject questPaper;
    [SerializeField] private GameObject questBoard;
    [SerializeField] private RandomQuest randomQuest;
    [SerializeField] private GameObject gameObject;

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
            StartCoroutine(GameOverSequence());
        }
    }

    private IEnumerator GameOverSequence()
    {
        if (GameOver != null)
            GameOver.SetActive(true);

        yield return new WaitForSeconds(2f);

        if (GameOver != null)
            GameOver.SetActive(false);
        if (gameObject != null)
            gameObject.SetActive(false);

        if (questPaper != null)
                questPaper.SetActive(true);
        if (questBoard != null)
            questBoard.SetActive(true);
        if (randomQuest != null)
            randomQuest.ShowNewQuestText();
    }
}
