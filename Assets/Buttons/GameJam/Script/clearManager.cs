using UnityEngine;

public class clearManager : MonoBehaviour
{
    public GameObject clear;
    public GameObject gameOver;
    public GameObject Hint;
    public Stop stopScript; // Stopスクリプトをアサイン
    public bool canClear = false;

    void Start()
    {
        canClear = false;
        clear.SetActive(false);
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canClear = true;
    }

    void Update()
    {
        if (canClear)
        {
            if (stopScript.isStop)
            {
                clear.SetActive(true);
                gameOver.SetActive(false);
                if (Hint != null) Hint.SetActive(false); // クリア時にヒント非表示
            }
        }
        else
        {
            if (stopScript.isStop)
            {
                clear.SetActive(false);
                gameOver.SetActive(true);
                if (Hint != null) Hint.SetActive(false); // 失敗時もヒント非表示
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canClear = false;
    }


}