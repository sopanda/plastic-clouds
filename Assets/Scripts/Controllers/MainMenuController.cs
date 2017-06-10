using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Klasa dla głownego menu
/// </summary>
public class MainMenuController : MonoBehaviour
{
	/// <summary>
	/// ładowanie 1 poziomu
	/// </summary>
    public void StartGame()
    {
        GameManager.instance.HeroDiedAndRestart = false;
        SceneManager.LoadScene("Gameplay");
    }

	/// <summary>
	/// ładowanie 2 poziomu
	/// </summary>
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Gameplay 1");
    }

	/// <summary>
	/// ładowanie 3 poziomu
	/// </summary>
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Gameplay 2");
    }

	/// <summary>
	/// ładowanie głownego menu
	/// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	/// <summary>
	/// wyjście
	/// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
