using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    public SoundSo foreground;

    void Start()
    {
        SoundMMManager.Instance.PlaySound(foreground);
    }
}
