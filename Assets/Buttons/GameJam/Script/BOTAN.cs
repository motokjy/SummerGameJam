using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject nextButton;

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Title"); // 次のシーン名に置き換えて！
    }

    public void ShowButton()
    {
        nextButton.SetActive(true);
    }
}
