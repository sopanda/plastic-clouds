using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	

	private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IncrementScore()
    {
        score += 1;
        scoreText.text = "x " + (score); 
    }

    public void DecrementLife()
    {
        lifeScore--;
        if(lifeScore >= 0)
        {
            lifeText.text = "x " + lifeScore;
        }
    }

} // class
