using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa dla menu pause pod czas gry
/// </summary>
public class Pause : MonoBehaviour 
{
	public GameObject PauseUI;

	private bool paused = false;

	/// <summary>
	/// chowamy pause menu
	/// </summary>
	void Start()
	{
		PauseUI.SetActive(false);
	}

	/// <summary>
	/// sprawdzamy stan
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			paused = !paused;
		}

		if (paused) 
		{
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) 
		{
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}
	/// <summary>
	/// inicjalizacja resume
	/// </summary>
	public void Resume()
	{
		paused = false;
	}
	/// <summary>
	/// inicjalizacja wyjścia
	/// </summary>
	public void Quit()
	{
		Application.Quit ();
	}
}
