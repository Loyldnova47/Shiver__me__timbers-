using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public void PlayClick()
    {
        SoundEffectManager.PlaySoundEffect("PlayerMenu");
    }
}
