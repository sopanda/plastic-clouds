using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{

    public AudioClip NewTrack;

    private AudioManager AM;

    void Start()
    {
        AM = FindObjectOfType<AudioManager>();

        if (NewTrack != null)
            AM.ChangeBGM(NewTrack);
    }
}
