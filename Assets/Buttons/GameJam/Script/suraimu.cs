using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 2f; // 移動速度

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // ←左へ移動！
    }
}