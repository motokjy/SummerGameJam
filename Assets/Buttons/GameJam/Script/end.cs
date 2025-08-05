using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalClear : MonoBehaviour
{
    public GameObject clearText; // クリアテキスト用

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Debug.Log("ゲームクリア！");
            Time.timeScale = 0;
            if (clearText != null)
            {
                clearText.SetActive(true); // クリアテキスト表示
            }
        }
    }
}