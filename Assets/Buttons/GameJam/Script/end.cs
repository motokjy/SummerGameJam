using System.Collections;
using UnityEngine;

public class GoalClear : MonoBehaviour
{
    public GameObject clearText; // クリアテキスト用
    public RandomQuest randomQuest; // インスペクターでアサイン
    public GameObject questPaper;   // 紙UI（インスペクターでアサイン）
    public GameObject questBord;
    public GameObject miniGame;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Debug.Log("ゲームクリア！");
            StartCoroutine(ClearSequence());
        }
    }

    private IEnumerator ClearSequence()
    {
        if (clearText != null)
            clearText.SetActive(true);

        // 2秒待つ
        yield return new WaitForSecondsRealtime(2f);

        if (clearText != null)
            clearText.SetActive(false);
        if (miniGame != null)
            miniGame.SetActive(false);

        // 新しいリクエストのテキストを更新
            if (randomQuest != null)
                randomQuest.ShowNewQuestText();

        // 紙UIを表示
        if (questPaper != null)
            questPaper.SetActive(true);
        if (questBord != null)
            questBord.SetActive(true);
    }
}