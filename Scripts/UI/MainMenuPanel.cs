using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    public Button enterBtn;
    public Button exitBtn;
    void Start()
    {
        enterBtn.onClick.AddListener(LoadScene);
        exitBtn.onClick.AddListener(Application.Quit);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }
}
