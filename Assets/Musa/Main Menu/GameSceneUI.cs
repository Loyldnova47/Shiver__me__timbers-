using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for UI components
using UnityEngine.SceneManagement; // Needed for scene management

public class GameSceneUI : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("StartButton")
            .GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                Debug.Log("Start Button Clicked");
                Loader.Load(Loader.Scene.GameScene);
            });

    }
}
