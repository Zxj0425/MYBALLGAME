using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Button backBtn;

    private void Start()
    {
        backBtn.onClick.AddListener(LoadMainMenuPanel);
    }

    private void LoadMainMenuPanel()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
