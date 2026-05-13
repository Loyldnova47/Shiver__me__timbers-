using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SSSoundManager : MonoBehaviour
{
    // Audio players components
    public AudioSource EffectSource;
    public AudioSource MusicSource;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    //Singleton instance.
    public static SSSoundManager Instance = null;

    //Initialize the singleton instance.
    private void Awake()
    {
        //If there is not already an instance of SoundManager, set it to this.
        if ( Instance == null)
        {
            Instance = this;
        }

        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad (gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectSource.clip = clip;
        EffectSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        
        EffectSource.pitch = randomPitch;
        EffectSource.clip = clips[randomIndex];
        EffectSource.Play();
    }
}
