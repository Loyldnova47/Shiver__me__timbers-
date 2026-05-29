using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum SoundType
{
    SWIM,
    HIDE,
    HURT,
}

[RequireComponent(typeof(AudioSource))]

public class SoundMManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundMManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
      /*  instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);*/
    }
}
