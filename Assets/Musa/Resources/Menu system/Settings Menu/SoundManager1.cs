using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SSoundManager1 : MonoBehaviour
{
    public Slider VolumeSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("soundVolume"))
            LoadVolume();
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 0.5f);
            LoadVolume();
        }
        
    }

    public void SetVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
       
    }

    public void LoadVolume()
    {
       VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
}