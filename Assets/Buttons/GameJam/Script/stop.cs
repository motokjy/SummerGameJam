using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public float speed = 0.01f;
    Vector2 startPos;
    public bool isStop = false;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(this.speed, 0, 0);// 移動
        if (Input.GetMouseButtonDown(0))
        {
            this.speed *= 0.00f;// 減速
            isStop = true;
        }
    }
}



