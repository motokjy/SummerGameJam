using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject countDown;
    [SerializeField] private GameObject questPaper;
    [SerializeField] private RandomQuest randomQuest;
    [SerializeField] private MoveQuest moveQuest;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    private bool hasPlayed = false;

    void Start()
    {
        countDown.SetActive(false);

        // 初期状態を保存
        initialPosition = questPaper.transform.localPosition;
        initialRotation = questPaper.transform.localRotation;
        initialScale = questPaper.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCountDown()
    {
        countDown.SetActive(true);
    }

    public void HideCountDown()
    {
        countDown.SetActive(false);
    }

    public void OnCancelAnimationEnd()
    {
        questPaper.SetActive(false);

        // 紙UIのTransformを初期状態に戻す
        questPaper.transform.localPosition = initialPosition;
        questPaper.transform.localRotation = initialRotation;
        questPaper.transform.localScale = initialScale;

        // テキストだけ更新
        randomQuest.ShowNewQuestText();

        questPaper.SetActive(true);

        hasPlayed = false;
        moveQuest.ResetCancel();
    }
}
