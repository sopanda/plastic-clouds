using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.HeroDiedAndRestart = false;
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Gameplay 1");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Gameplay 2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
