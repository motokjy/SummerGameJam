using UnityEngine;

public class QuestCancelAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MoveQuest moveQuest;
    [SerializeField] private GameObject questPaper; // 紙UI
    [SerializeField] private RandomQuest randomQuest; // 新しいクエスト表示用

    private bool hasPlayed = false;

    // 追加：初期Transform保存用
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        // 紙UIの初期Transformを保存
        initialPosition = questPaper.transform.localPosition;
        initialRotation = questPaper.transform.localRotation;
        initialScale = questPaper.transform.localScale;
    }

    void Update()
    {
        if(moveQuest.IsCancelled() && !hasPlayed)
        {
            animator.SetTrigger("Cancel");
            hasPlayed = true;
        }
    }

    // アニメーションの最後にAnimation Eventでこのメソッドを呼ぶ
    public void OnCancelAnimationEnd()
    {
        questPaper.SetActive(false);

        // 紙UIのTransformを初期状態に戻す
        questPaper.transform.localPosition = initialPosition;
        questPaper.transform.localRotation = initialRotation;
        questPaper.transform.localScale = initialScale;

        randomQuest.ShowNewQuest();
        questPaper.SetActive(true);

        hasPlayed = false;
        moveQuest.ResetCancel();
    }
}