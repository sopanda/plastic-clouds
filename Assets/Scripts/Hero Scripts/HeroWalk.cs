using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWalk : MonoBehaviour
{
    private float speed = 30f, maxVelocity = 4f;

    private Rigidbody2D myBody;

	void Awake ()
    {
        myBody = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate ()
    {
        HeroWalkKeyboard();
	}

    private void HeroWalkKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal"); // from user input

        //h = 1, if pressed a or leftArrow
        //h = 0, nothing pressed
        //h = -1, if pressed d or rightArrow
        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                forceX = speed;
            }
        }
        else if(h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }
} //class
