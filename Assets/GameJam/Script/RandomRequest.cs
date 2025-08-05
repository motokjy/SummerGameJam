using UnityEngine;
using TMPro;

public class RandomQuest : MonoBehaviour
{
    [SerializeField] private RequestDataBase requestDataBase;
    [SerializeField] private TMP_Text questText;

    void SetRandomQuest()
    {
        if (requestDataBase == null || requestDataBase.requests.Count == 0) return;
        int idx = Random.Range(0, requestDataBase.requests.Count);
        Request selected = requestDataBase.requests[idx];
        questText.text = selected.requestText;
    }

    public void ShowNewQuest()
    {
        SetRandomQuest();
    }
}