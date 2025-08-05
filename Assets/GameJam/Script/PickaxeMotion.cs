using UnityEngine;

public class PickaxeMotion : MonoBehaviour
{
    public Transform pickaxeTransform;
    private Quaternion defaultRotation;

    void Start()
    {
        defaultRotation = pickaxeTransform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pickaxeTransform.rotation = Quaternion.Euler(0f, 0f, -40f); // Z軸に20度（見えやすい）
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            pickaxeTransform.rotation = defaultRotation;
        }
    }
}