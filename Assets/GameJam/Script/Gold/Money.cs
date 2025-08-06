using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public int money = 2000;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private int goalMoney = 4000; // 目標金額
    [SerializeField] private string ClearScene = "Clear"; // クリア時のシーン名
    [SerializeField] private string GameOverScene = "GameOver"; // 借金ゲームオーバー時のシーン名
    private bool isClearing = false;

    void Start()
    {
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();

        // 目標金額に到達したらクリア
        if (!isClearing && money >= goalMoney)
        {
            isClearing = true;
            StartCoroutine(GoToClearScene());
        }
        // 所持金が0未満になったら借金ゲームオーバー
        else if (!isClearing && money < 0)
        {
            isClearing = true;
            StartCoroutine(GoToDebtScene());
        }
    }

    private IEnumerator GoToClearScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(ClearScene);
    }

    private IEnumerator GoToDebtScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(GameOverScene);
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
            moneyText.text = money.ToString() + " G";
    }
}
