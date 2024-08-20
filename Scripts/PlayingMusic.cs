using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingMusic : MonoBehaviour
{
    public AudioSource myAudio;
    public Character playerCharacter;
    void Start()
    {
        myAudio.Play();
    }

    void Update()
    {
        StopPlaying();
    }

    void StopPlaying()
    {
        if (playerCharacter.currentHp <= 0)
        {
            myAudio.Stop();
        }
    }
}
