using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SSoundManager : MonoBehaviour
{
    public Slider VolumeSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
            LoadVolume();
        else
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
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
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
       
    }

    public void LoadVolume()
    {
       VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}