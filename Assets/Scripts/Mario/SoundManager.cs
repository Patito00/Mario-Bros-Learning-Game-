using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip loseALiveClip;
    [SerializeField] private AudioClip starManClip;
    [SerializeField] private AudioClip finishLevelClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip kickEnemyClip;
    [SerializeField] private AudioClip MushroomUpClip;
    [SerializeField] private AudioClip MushroomDownClip;
    [SerializeField] private AudioClip PowerUpAppears;
    [SerializeField] private AudioClip keySound;
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
    public void UnlockedKeySound() 
    {
        audioSource.PlayOneShot(keySound);
    }

    // private mehtods and coroutines
    private float PlayMusic(AudioClip pMusic, float clipTime)
    {
        backgroundMusic.clip = pMusic;
        backgroundMusic.Play();
        StopAllCoroutines();
        StartCoroutine(ActivateBackgroundMusic(clipTime));
        return pMusic.length;
    }
    private IEnumerator ActivateBackgroundMusic(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        backgroundMusic.clip = backgroundClip;
        backgroundMusic.Play();  
    }
} 