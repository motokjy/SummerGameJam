using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RandomQuest : MonoBehaviour
{
    [SerializeField] private RequestDataBase requestDataBase;
    [SerializeField] private TMP_Text questText;
    [SerializeField] private List<GameObject> allPrefabs; // シーン上の全プレハブをアサイン

    private GameObject currentActivePrefab;
    private Request selectedRequest; // 現在選ばれているリクエスト

    // テキストだけ更新
    public void ShowNewQuestText()
    {
        if (requestDataBase == null || requestDataBase.requests.Count == 0) return;
        int idx = Random.Range(0, requestDataBase.requests.Count);
        selectedRequest = requestDataBase.requests[idx];
        questText.text = selectedRequest.requestText;
    }

    // プレハブだけ表示
    public void ShowPrefabForCurrentQuest()
    {
        // すべて非表示
        foreach (var obj in allPrefabs)
            obj.SetActive(false);

        // 名前で一致するものだけ表示
        if (selectedRequest == null) return;
        var showObj = allPrefabs.Find(obj => obj.name == selectedRequest.prefabName);
        if (showObj != null)
            showObj.SetActive(true);

        currentActivePrefab = showObj;
    }
}