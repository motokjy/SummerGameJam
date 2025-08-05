using UnityEngine;

public class renda : MonoBehaviour
{
    public GameObject bow;
    private bool movePositive = true;
    private float baseAngle = 0f; 

    void Start()
    {
            bow = GameObject.Find("bow"); // ← ヒエラルキー上の正確な名前を指定！
            if (bow == null)
            {
                Debug.LogError("⚠️ BowObjectName が見つかりません。名前を確認してください！");
                return;
            }
            baseAngle = bow.transform.rotation.eulerAngles.x;

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Aボタンが押された");

            float currentZAngle = bow.transform.rotation.eulerAngles.z;
            float angleOffset = movePositive ? -20f : 20f;
            float newZAngle = currentZAngle + angleOffset;

            bow.transform.rotation = Quaternion.Euler(0f, 0f,newZAngle);

            movePositive = !movePositive;
        }
    }
}