using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveQuest : MonoBehaviour
{
    [SerializeField] private float displayDuration = 5f;
    private float timer;
    private bool isCancelled = false; // 修正: privateにしてメソッドでアクセス

    public Animator animator;

    void OnEnable()
    {
        timer = displayDuration;
        isCancelled = false; 
    }

    void Update()
    {
        if (isCancelled) return;

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("キャンセルしました");
            isCancelled = true;
            return;
        }

        timer -= Time.deltaTime;
        if(timer <= 0f)
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
        gameObject.SetActive(false);
    }
}
