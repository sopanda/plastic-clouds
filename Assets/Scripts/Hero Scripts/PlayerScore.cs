using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public bool isAlive;

    private GameObject gamefinished;

	void Awake ()
    {
        isAlive = true;
        gamefinished = GameObject.Find("LvlFinish");
        gamefinished.gameObject.SetActive(false);
	}

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            GameplayContoller.instance.IncrementScore();
            collision.gameObject.SetActive(false); //uncheking and hidding
        }

        if (collision.tag == "Skeleton" )
        {
            if(isAlive)
            {
                isAlive = false;
                GameplayContoller.instance.DecrementLife();
                transform.position = new Vector3(0, 100000, 0);
            }
        }

        if (collision.tag == "Exit")
        {
            Time.timeScale = 0f;
            gamefinished.gameObject.SetActive(true);
        }

    }
}//class
