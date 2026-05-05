using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource source;
   // GameObject pressEtoInteractOBJ;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if(collision.CompareTag("PPlayer"))
    //    {
    //        pressEtoInteractOBJ.SetGameObjectsActive(true);
    //    }


    //}
}
