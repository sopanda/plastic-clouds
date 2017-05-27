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
	
}
