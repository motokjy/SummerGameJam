using UnityEngine;

public class QuestCancelAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MoveQuest moveQuest;

    private bool hasPlayed = false; // 追加

    void Update()
    {
        if(moveQuest.IsCancelled() && !hasPlayed)
        {
            Debug.Log("キャンセルアニメーション");
            animator.SetTrigger("Cancel");
            hasPlayed = true; // 一度だけ再生
        }
    }
}