using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class MusicChanger : MonoBehaviour 
{
    private static MusicChanger _instance;

    public static MusicChanger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MusicChanger();
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    } 

    private GameObject musicManager;
    public string MusicToStop;

    void Start()
    {
        musicManager = GameObject.Find("AudioManager");
        AudioManager.Instance.StopMusic(MusicToStop);
        AudioManager.Instance.PlayMusic("Level 1");
    }
}
