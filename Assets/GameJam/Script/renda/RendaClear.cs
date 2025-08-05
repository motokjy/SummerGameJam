using UnityEngine;
using System.Collections;

public class RendaClear : MonoBehaviour
{
    [SerializeField] private SlimeDamage slimeDamage; // インスペクターでアサイン
    [SerializeField] private GameObject clearText;
    [SerializeField] private GameObject questPaper;
    [SerializeField] private GameObject questBoard;
    [SerializeField] private RandomQuest randomQuest;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject Hint;
    private bool isCleared = false;

    // Update is called once per frame
    void Update()
    {
        if (!isCleared && slimeDamage != null && slimeDamage.hp <= 0)
        {
            isCleared = true;
            StartCoroutine(ClearSequence());
        }
    }

    private IEnumerator ClearSequence()
    {
        if (clearText != null)
            clearText.SetActive(true);
        if (Hint != null)
            Hint.SetActive(false);

        yield return new WaitForSeconds(2f);

        if (clearText != null)
            clearText.SetActive(false);
        gameObject.SetActive(false);

        if (questPaper != null)
            questPaper.SetActive(true);
        if (questBoard != null)
            questBoard.SetActive(true);

        if (randomQuest != null)
            randomQuest.ShowNewQuestText();

    }
}
