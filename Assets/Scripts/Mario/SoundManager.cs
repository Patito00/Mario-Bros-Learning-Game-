using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip loseALifeClip;
    public AudioSource backgroundMusic;
    AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public float LoseALiveSound()
    {
        audioSource.PlayOneShot(loseALifeClip);
        backgroundMusic.Pause();
        return loseALifeClip.length;
    }
}