using Unity.VisualScripting;
using UnityEngine;

public class StopSoundMMManager : MonoBehaviour
{
    static StopSoundMMManager instance;
    public static SoundMMManager Instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy (AudioObject);
        }
        else
        {
             instance = this;
             GameObject.DontDestroyOnLoad(AudioOject);
        }
    }
}