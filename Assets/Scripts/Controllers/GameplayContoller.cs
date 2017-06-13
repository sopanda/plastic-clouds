using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Gameplay contoller.
/// </summary>
public class GameplayContoller : MonoBehaviour
{
    public static GameplayContoller instance;

    private Text scoreText;
    private Text lifeText;


    private double Score;
	private int lifeScore;

    void Awake()
    {
        MakeInstance();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
    }
	/// <summary>
	/// Raises the enable event.
	/// </summary>
    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }
	/// <summary>
	/// Raises the disable event.
	/// </summary>
    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

	/// <summary>
	/// Levels finished loading.
	/// </summary>
	/// <param name="scene">Scene.</param>
	/// <param name="mode">Mode.</param>
    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay" || scene.name == "Gameplay 1" || scene.name == "Gameplay 2")
        {
            if (!GameManager.instance.HeroDiedAndRestart) //started for 1 time
            {
                Score = 0;
                lifeScore = 2;
            }
            else //restarted
            {
                Score = GameManager.instance.score;
                lifeScore = GameManager.instance.lifescore;
            }
            scoreText.text = "x " + Score;
            lifeText.text = "x " + lifeScore;
        }
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

	/// <summary>
	/// Increments the score.
	/// </summary>
    public void IncrementScore()
    {
        Score += 0.5;
        scoreText.text = "x " + (Score);
    }

	/// <summary>
	/// Decrements the life.
	/// </summary>
    public void DecrementLife()
    {
        lifeScore--;
        if (lifeScore >= 0)
        {
            lifeText.text = "x " + lifeScore;
        }
        StartCoroutine(HeroDied());
    }

	/// <summary>
	/// zażądzanie życiem
	/// </summary>
	/// <returns>The died.</returns>
    IEnumerator HeroDied()
    {
        yield return new WaitForSeconds(2f);

        if (lifeScore < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            GameManager.instance.HeroDiedAndRestart = true;
            GameManager.instance.score = Score;
            GameManager.instance.lifescore = lifeScore;
            SceneManager.LoadScene("Gameplay");
        }
    }

} // class
