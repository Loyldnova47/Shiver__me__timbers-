using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        if (image != null)
            image.fillAmount = Loader.GetLoadingProgress();
    }
}