using UnityEngine;
using TMPro;

public class Slime : MonoBehaviour {
    public int hitCount = 25;
    public float timeLimit = 5f;
    private float timer = 0f;
    private bool isActive = true;

    public TextMeshProUGUI hitText;
    public TextMeshProUGUI timerText;

    void Update() {
        if (!isActive) return;

        timer += Time.deltaTime;

        // 表示更新
        hitText.text = "HP: " + hitCount;
        timerText.text = "time left: " + (timeLimit - timer).ToString("F1") + "second";

        if (Input.GetKeyDown(KeyCode.A)) {
            hitCount--;
        }

        if (hitCount <= 0) {
            hitText.text = "Destroy!";
            Destroy(gameObject);
            isActive = false;
        }

        if (timer >= timeLimit) {
            timerText.text = "Time is up";
            isActive = false;
        }
    }
}