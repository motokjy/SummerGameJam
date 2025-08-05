using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveQuest : MonoBehaviour
{
    [SerializeField] private float displayDuration = 5f;
    [SerializeField] private GameObject otherObject;
    [SerializeField] private GameObject Prefub;
    [SerializeField] private CountDownManager countDownManager;
    [SerializeField] private RandomQuest randomQuest; // 追加
    
    private float timer;
    private bool isCancelled = false; // 修正: privateにしてメソッドでアクセス
    private bool isCountDownStarted = false;
    public Animator animator;

    void OnEnable()
    {
        timer = displayDuration;
        isCancelled = false;
        isCountDownStarted = false;
    }

    void Update()
    {
        if (isCancelled) return;

        timer -= Time.deltaTime;

        if (!isCountDownStarted && timer <= (displayDuration - 2f))
        {
            isCountDownStarted = true;
            if (countDownManager != null)
            {
                countDownManager.ShowCountDown();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("キャンセルしました");
            isCancelled = true;
            if (countDownManager != null)
            {
                countDownManager.HideCountDown();
            }
            return;
        }


        if (timer <= 0f)
        {
            StartMiniGame();
        }
    }

    public bool IsCancelled()
    {
        return isCancelled;
    }

    public void ResetCancel()
    {
        isCancelled = false;
    }
    void StartMiniGame()
    {
        if (Prefub != null)
            Prefub.SetActive(false);
        if (otherObject != null)
            otherObject.SetActive(false);

        if (randomQuest != null)
            randomQuest.ShowPrefabForCurrentQuest(); // プレハブだけ表示
    }
}
