using UnityEngine;
using UnityEngine.UI;

public class PhoneReceiver : MonoBehaviour
{
    public Transform receiver;       // 受話器のオブジェクト
    public Text instructionText;     // 点滅テキスト
    public string clearText = "Clear";

    private bool isPickedUp = false;
    private float blinkTimer = 0f;
    private bool showText = true;
    public float blinkSpeed = 0.5f;

    void Update()
    {
        if (!isPickedUp)
        {
            // 点滅処理
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= blinkSpeed)
            {
                showText = !showText;
                instructionText.enabled = showText;
                blinkTimer = 0f;
            }

            // Dキーで電話を取る
            if (Input.GetKeyDown(KeyCode.A))
            {
                receiver.rotation = Quaternion.Euler(0f, 0f, -30f); // Z軸に左傾き
                instructionText.text = clearText;
                instructionText.enabled = true; // 点滅止めて表示固定
                isPickedUp = true;
            }
        }
    }
}