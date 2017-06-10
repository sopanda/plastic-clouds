using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Audio manager sprawdzanie czy już jest muzyka.
/// </summary>
public class AudioManagerCheck : MonoBehaviour
{
    public GameObject audioMan;
    void Start()
    {
        if (FindObjectOfType<AudioManager>())
        {
            return;
        }
        else
        {
            Instantiate(audioMan, transform.position, transform.rotation);
        }

    }
}
