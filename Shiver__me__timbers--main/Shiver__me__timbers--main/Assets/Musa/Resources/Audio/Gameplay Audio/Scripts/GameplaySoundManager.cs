using UnityEngine;

public class GameplaySoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip swimSound;
    [SerializeField] private AudioClip hideSound;
    [SerializeField] private AudioSource audioSource;

    public static GameplaySoundManager Instance;

    private void Awake()
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
    public void PlaySwimSound()
    {
        audioSource.PlayOneShot(swimSound);
    }

    public void PlayHideSound()
    {
        audioSource.PlayOneShot(hideSound);
    }

}
