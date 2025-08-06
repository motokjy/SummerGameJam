using UnityEngine;
using System.Collections;

public class clearManager : MonoBehaviour
{
    public GameObject clear;
    public GameObject gameOver;
    public GameObject Hint;
    public Stop stopScript;
    public bool canClear = false;

    [SerializeField] private GameObject questPaper;
    [SerializeField] private GameObject questBoard;
    [SerializeField] private RandomQuest randomQuest;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private MoneyManager moneyManager; // 報酬管理用

    private bool isProcessing = false;

    void Start()
    {
        canClear = false;
        clear.SetActive(false);
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canClear = true;
    }

    void Update()
    {
        if (isProcessing) return;

        if (stopScript.isStop)
        {
            if (canClear)
            {
                StartCoroutine(ClearSequence());
            }
            else
            {
                StartCoroutine(GameOverSequence());
            }
        }
    }

    private IEnumerator ClearSequence()
    {
        isProcessing = true;
        if (clear != null) clear.SetActive(true);
        if (gameOver != null) gameOver.SetActive(false);
        if (Hint != null) Hint.SetActive(false);

        yield return new WaitForSeconds(2f);

        if (clear != null) clear.SetActive(false);

        if (questPaper != null) questPaper.SetActive(true);
        if (questBoard != null) questBoard.SetActive(true);

        // 報酬を加算
        if (randomQuest != null && randomQuest.SelectedRequest != null && moneyManager != null)
            moneyManager.AddMoney(randomQuest.SelectedRequest.requestReward);

        if (randomQuest != null) randomQuest.ShowNewQuestText();

        gameObject.SetActive(false); // ミニゲームプレハブを非表示

        isProcessing = false;
    }

    private IEnumerator GameOverSequence()
    {
        isProcessing = true;
        if (clear != null) clear.SetActive(false);
        if (gameOver != null) gameOver.SetActive(true);
        if (Hint != null) Hint.SetActive(false);

        yield return new WaitForSeconds(2f);

        if (gameOver != null) gameOver.SetActive(false);

        if (questPaper != null) questPaper.SetActive(true);
        if (questBoard != null) questBoard.SetActive(true);
        if (randomQuest != null) randomQuest.ShowNewQuestText();

        gameObject.SetActive(false); // ミニゲームプレハブを非表示

        isProcessing = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canClear = false;
    }
}