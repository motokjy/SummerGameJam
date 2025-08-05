using UnityEngine;

public class clearManager : MonoBehaviour
{
    public GameObject clear;
    public GameObject gameOver;
    private bool hitGoal1 = false;
    private bool isStop = false; // 追加
    private bool isInGoal2 = false; // goal2内にいるか

    void Start()
    {
        clear.SetActive(false);
        gameOver.SetActive(false);
        hitGoal1 = false;
        isStop = false; // 初期化
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal1"))
        {
            hitGoal1 = true;
            gameOver.SetActive(true);
            clear.SetActive(false);
        }
        if (collision.gameObject.CompareTag("goal2"))
        {
            isInGoal2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal2"))
        {
            isInGoal2 = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay called with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("goal2"))
        {
            if (!hitGoal1 && isStop)
            {
                Debug.Log("ゲームクリア！");
                clear.SetActive(true);
                gameOver.SetActive(false);
            }
        }
    }

    void Update()
    {
        // 左クリックを押した瞬間
        if (Input.GetMouseButtonDown(0))
        {
            SetStopTrue();
        }
    }

    // 他スクリプトから呼び出す用
    public void SetStopTrue()
    {
        isStop = true;
        if (isInGoal2 && !hitGoal1)
        {
            clear.SetActive(true);
            gameOver.SetActive(false);
        }
    }
}