using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMMManager : MonoBehaviour
{
    public List<SoundSo> allSounds = new List<SoundSo>();

    public Dictionary<string, AudioSource> soundDictionary = new Dictionary<string, AudioSource>();

    public GameObject audioSourceObject;

    public GameObject audioSourceObject2;

    public SoundSo backgroundSo;

    public SoundSo foregroundSo;

    public GameObject Re_enable_sound;

    public static SoundMMManager Instance;

    private bool hasLandedInGameScene = false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene (Main)" && !hasLandedInGameScene)
        {
            hasLandedInGameScene = true;
            SoundMMManager.Instance.gameObject.SetActive(false);

        }
        else if (SceneManager.GetActiveScene().name != "GameScene (Main)" && hasLandedInGameScene)
        {
            hasLandedInGameScene = false;
            SoundMMManager.Instance.gameObject.SetActive(true);
        }
    }
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
        PlaySound(foregroundSo);

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

    void OnEnable()
    {

        // Subscribe to the scene Loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks 
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Main Menu")
        {
            SoundMMManager.Instance.gameObject.SetActive(true);
        }


        // Check if this is the next scene (replace "NextSceneName")
        else if (scene.name == "GameScene (Main)")
        {
            // Stop the sound
            SoundMMManager.Instance.gameObject.SetActive(false);
        }

    }

   
}
