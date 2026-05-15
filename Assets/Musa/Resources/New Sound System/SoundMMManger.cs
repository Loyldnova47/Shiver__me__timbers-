using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundMMManager : MonoBehaviour
{
    public List<SoundSo> allSounds = new List<SoundSo>();

    public Dictionary<string, AudioSource> soundDictionary = new Dictionary<string, AudioSource>();

    public GameObject audioSourceObject;

    public SoundSo backgroundSo;

    public static SoundMMManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(target: this);
        }
        else
        {
            Destroy(gameObject);
        }

        SetSounds();
        PlaySound(backgroundSo);
       
    }

    public void SetSounds()
    {
        foreach (var sound in allSounds)
        {
            var temObject = Instantiate(audioSourceObject, transform);
            temObject.name = sound.name;
            var tempSource = temObject. GetComponent<AudioSource>();
            soundDictionary.Add(sound.name, tempSource);
        }
    }

    public void PlaySound(SoundSo soundSo)
    {
        foreach (var sound in allSounds)
        {
            if (sound.name == soundSo.name)
            {
                if (soundDictionary.TryGetValue(sound.name, out AudioSource source))
                {
                    source.clip = sound.soundClip1;
                    source.volume = sound.onVolume;
                    source.loop = sound.isLoop;
                    source.Play();
                }

                return;
            }
        }
    }
}
