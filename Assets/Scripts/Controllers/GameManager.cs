using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// klasa ma 1 objekt całą gre i pomaga monitorować parametry
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public double score;
    public int lifescore;

    public bool HeroDiedAndRestart;

    void Awake()
    {
        MakeSingleton();
    }

	/// <summary>
	/// Przeschodzi przez wszystkie sceny
	/// </summary>
    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  //over object will not be destroyed after changing scene
        }
    }

}// class
