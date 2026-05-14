using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SSSoundManagerButtonEffect : MonoBehaviour
{
    // Audio players components
    public AudioSource EffectSource;
    public AudioClip EffectSound1;
    public AudioSource MusicSource;
    public AudioSource EffectSource2;
    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    //Singleton instance.
    public static SSSoundManagerButtonEffect InstanceEffect = null;

    //Initialize the singleton instance.
    private void Awake()
    {
        //If there is not already an instance of SoundManager, set it to this.
        if ( InstanceEffect == null)
        {
            InstanceEffect = this;
        }

        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (InstanceEffect != this)
        {
            //Destroy(gameObject);
        }

        //DontDestroyOnLoad (gameObject);
    }

    // Play a single clip through the sound effects source.
    public void PlayEffect()
    {
        EffectSource.clip = EffectSound1;
        EffectSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusicEffect(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomEffect2(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        
        EffectSource.pitch = randomPitch;
        EffectSource.clip = clips[randomIndex];
        EffectSource.Play();
    }
}
