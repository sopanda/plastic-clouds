using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWalk : MonoBehaviour
{
    private float speed = 30f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private float jumpForce = 500f;
    private bool isGrounded = false;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        HeroWalkKeyboard();
        Jump();
    }

    private void HeroWalkKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal"); // from user input

        //h = 1, if pressed a or leftArrow
        //h = 0, nothing pressed
        //h = -1, if pressed d or rightArrow
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale; // took the local scale
            temp.x = 9.160614f;
            transform.localScale = temp; //set new scale

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale; // took the local scale
            temp.x = -9.160614f;
            transform.localScale = temp; //set new scale

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                myBody.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
        }
    }
} //class
