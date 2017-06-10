using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa dla kamery
/// </summary>
public class CameraFollow : MonoBehaviour
{
    private GameObject hero;
    private PlayerScore heroScore;

    private float minX = 0f, maxX = 204f;

    void Awake()
    {
        hero = GameObject.Find("HERO");
        heroScore = hero.GetComponent<PlayerScore>();
    }

    void Update()
    {
        FollowHero();
    }

	/// <summary>
	/// kamera idzie za bohaterem
	/// </summary>
    private void FollowHero()
    {
        if (heroScore.isAlive)
        {
            Vector3 tmp = transform.position;

            tmp.x = hero.transform.position.x;

            if (tmp.x < minX)
            {
                tmp.x = minX;
            }

            if (tmp.x > maxX)
            {
                tmp.x = maxX;
            }

            tmp.y = hero.transform.position.y + 3f;

            transform.position = tmp;
        }
    }
}//class
