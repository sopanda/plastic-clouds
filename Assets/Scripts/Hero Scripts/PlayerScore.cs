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
            collision.gameObject.SetActive(false); //uncheking and hidding
        }

        if (collision.tag == "Skeleton")
        {
            isAlive = false;
            transform.position = new Vector3(0, 100000, 0);
        }

        if (collision.tag == "Exit")
        {
            Time.timeScale = 0f;
        }

    }
}//class
