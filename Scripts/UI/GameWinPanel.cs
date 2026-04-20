using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinPanel : MonoBehaviour
{
    public Button nextBtn;
    public Button backBtn;
    public GameObject[] starGameObjects;

    private void Start()
    {
        nextBtn.onClick.AddListener(LoadNextScene);
        backBtn.onClick.AddListener(LoadScene);
    }
    
    private void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            SceneManager.LoadScene("Scene2");
        }
        else if (SceneManager.GetActiveScene().name == "Scene2")
        {
            SceneManager.LoadScene("Scene3");
        }else if (SceneManager.GetActiveScene().name == "Scene3")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //根据星星数量来显示内容
    public void SetUI(int starCount)
    {
        //设置星星的显示
        int count = 0;
        if (starCount >= 0)
            count++;
        if (starCount >= 1)
            count++;
        if (starCount >= 2)
            count++;
        for (int i = 0; i < starGameObjects.Length; i++)
        {
            starGameObjects[i].SetActive(i + 1 <= count);
        }
    }
}