using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keep score and if HERO is dead
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

    private void MakeSingleton()
    {
        if(instance != null)
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
