using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject countDown;
    void Start()
    {
        countDown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCountDown()
    {
        countDown.SetActive(true);
    }

    public void HideCountDown()
    {
        countDown.SetActive(false);
    }
}
