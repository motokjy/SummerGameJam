using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // 追加

public class chara : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("Ingame");
    }
}