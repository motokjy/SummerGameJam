using UnityEngine;

public class wallManager : MonoBehaviour{
    [SerializeField] private clearManager clearManager;
    public GameObject GameOver;
    public GameObject Hint;

    void Start() {
        Hint.SetActive(true);
        GameOver.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "wall"){
            clearManager.canClear = false;
            Hint.SetActive(false);
            GameOver.SetActive(true);
        }
    }
}