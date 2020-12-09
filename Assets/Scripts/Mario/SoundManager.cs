using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variables
    public AudioSource backgroundMusic;
    public AudioClip loseALiveClip;
    public AudioClip starManClip;
    public AudioClip finishLevelClip;
    public AudioClip coinClip;
    public AudioClip kickEnemyClip;
    public AudioClip MushroomUpClip;
    public AudioClip MushroomDownClip;
    public AudioClip PowerUpAppears;
    AudioSource audioSource;
    private AudioClip backgroundClip;
    
    // On Start
    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        backgroundClip = backgroundMusic.clip;
    }

    // playing music
    public float Starman()
    {
        return PlayMusic(starManClip, 5f);
    }
    public float FinishLevel()
    {
        return PlayMusic(finishLevelClip, finishLevelClip.length);
    }
    public float LoseALive()
    {
        return PlayMusic(loseALiveClip, loseALiveClip.length);
    }
    // playing Sounds
    public void CoinSound()
    {
        audioSource.PlayOneShot(coinClip);
    }
    public void KickEnemySound()
    {
        audioSource.PlayOneShot(kickEnemyClip);
    }
    public void MushroomSound(bool powerUp)
    {
        if(powerUp)
        {
            audioSource.PlayOneShot(MushroomUpClip);
        }
        else
        {
            audioSource.PlayOneShot(MushroomDownClip);
        }
    }
    public void QuestionBlockSound(bool appearItem)
    {
        if(appearItem)
        {
            audioSource.PlayOneShot(PowerUpAppears);
        }
        else
        {
            CoinSound();
        }
    }

    // private mehtods and coroutines
    private float PlayMusic(AudioClip pMusic, float clipTime)
    {
        backgroundMusic.clip = pMusic;
        backgroundMusic.Play();
        StartCoroutine(ActivateBackGroundMusic(clipTime));
        return pMusic.length;
    }
    private IEnumerator ActivateBackGroundMusic(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        backgroundMusic.clip = backgroundClip;
        backgroundMusic.Play();  
    }
} 