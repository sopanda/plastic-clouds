using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayContoller : MonoBehaviour
{
    public static GameplayContoller instance;

    private Text scoreText;
    private Text lifeText;


    private int score;
    private int lifeScore;

	void Awake ()
    {
        MakeInstance();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            if(!GameManager.instance.HeroDiedAndRestart) //started for 1 time
            {
                score = 0;
                lifeScore = 2;
            }
            else //restarted
            {
                score = GameManager.instance.score;
                lifeScore = GameManager.instance.lifescore;
            }
            scoreText.text = "x " + score;
            lifeText.text = "x " + lifeScore;
        }
    }

    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "x " + (score); 
    }

    public void DecrementLife()
    {
        lifeScore--;
        if(lifeScore >= 0)
        {
            lifeText.text = "x " + lifeScore;
        }
        StartCoroutine(HeroDied());
    }

    IEnumerator HeroDied()
    {
        yield return new WaitForSeconds(2f);

        if(lifeScore < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            GameManager.instance.HeroDiedAndRestart = true;
            GameManager.instance.score = score;
            GameManager.instance.lifescore = lifeScore;
            SceneManager.LoadScene("Gameplay");

        }
    }

} // class
