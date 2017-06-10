using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio manager.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

	/// <summary>
	/// zmiana utworu
	/// </summary>
	/// <param name="music">Music.</param>
    public void ChangeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
