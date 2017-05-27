using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public bool isAlive;

	void Awake ()
    {
        isAlive = true;	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            GameplayContoller.instance.IncrementScore();
            collision.gameObject.SetActive(false); //uncheking and hidding
        }

        if (collision.tag == "Skeleton")
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
        }

    }
}//class
