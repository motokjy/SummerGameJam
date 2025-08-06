using UnityEngine;
using System.Collections;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject goalText;      // ゴールテキスト用オブジェクト
    [SerializeField] private GameObject questPaper;    // 紙UI（インスペクターでアサイン）
    [SerializeField] private GameObject questBoard;    // クエストボード（インスペクターでアサイン）
    [SerializeField] private RandomQuest randomQuest;  // 新しいクエストテキスト用
    [SerializeField] private GameObject gameObject;
    [SerializeField] private MoneyManager moneyManager; // 追加

    private void Start()
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

            StartCoroutine(GoalSequence());
        }
    }

    private IEnumerator GoalSequence()
    {
        yield return new WaitForSeconds(2f);

        if (goalText != null)
            goalText.SetActive(false);
        gameObject.SetActive(false);

        if (questPaper != null)
            questPaper.SetActive(true);
        if (questBoard != null)
            questBoard.SetActive(true);

        // 報酬を加算
        if (randomQuest != null && randomQuest.SelectedRequest != null && moneyManager != null)
            moneyManager.AddMoney(randomQuest.SelectedRequest.requestReward);

        if (randomQuest != null)
            randomQuest.ShowNewQuestText();
    }
}
