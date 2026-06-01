using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSound;

    public void PlayClick()
    {
        StartontoGameplay.Instance.PlaySound(clickSound);   
    }

}
