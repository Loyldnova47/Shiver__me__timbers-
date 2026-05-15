using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/SoundSo", fileName = "Soundso")]
public class SoundSo : ScriptableObject
{
    // Contains the sound clip, name, volume, and loop settings for a sound effect or music track.
    public AudioClip soundClip1;


    // The name of the sound, used for identification and retrieval in the sound manager.
    public string soundName;

    // The volume level at which the sound should be played, typically a value between 0.0 (silent) and 1.0 (full volume).
    public float onVolume;

    // A boolean flag indicating whether the sound should loop when played. If true, the sound will repeat continuously until stopped.
    public bool isLoop;
}
