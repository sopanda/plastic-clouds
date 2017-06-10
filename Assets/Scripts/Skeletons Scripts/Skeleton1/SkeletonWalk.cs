using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa fizyki wrogów
/// </summary>
public class SkeletonWalk : MonoBehaviour
{
    private float speed = 3f;
    public bool walkLeft;


    void Start()
    {
        StartCoroutine(ChangeDirection());
    }


    void Update()
    {
        Walk();
    }

	/// <summary>
	/// chodżba wrogów
	/// </summary>
    private void Walk()
    {
        Vector3 tmp = transform.position;
        Vector3 tempScale = transform.localScale;
        //to the left
        if (walkLeft)
        {
            tmp.x -= speed * Time.deltaTime;//difference between frames
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        //to the right
        else
        {
            tmp.x += speed * Time.deltaTime;
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        transform.position = tmp;
        transform.localScale = tempScale;
    }

    /// <summary>
	/// czekam 3 sec i zmiana direction
    /// </summary>
    /// <returns>The direction.</returns>
    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(3f);
        walkLeft = !walkLeft; //oposite value after 3 sec
        StartCoroutine(ChangeDirection());
    }
}//class
