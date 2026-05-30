using UnityEngine;

public class StartontoGameplay : MonoBehaviour
{
    public static StartontoGameplay Instance;
    public AudioSource source;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
