using UnityEngine;

public class Gamethingy : MonoBehaviour
{
    public AudioClip Level1;

    void Start()
    {
        SSSoundManager.Instance.PlayMusic(Level1);
    }
}
