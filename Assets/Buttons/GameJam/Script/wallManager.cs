using UnityEngine;

public class wallManager : MonoBehaviour{

    public GameObject GameOver;
    public GameObject Hint;

    void Start() {
        Hint.SetActive(true);
        GameOver.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "wall"){
            Hint.SetActive(false);
            GameOver.SetActive(true);
        }
    }
}
