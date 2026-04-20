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
        // this script was developed with the asistance from Code Monkey :  https://www.youtube.com/watch?v=3I5d2rUJ0pE&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=7
    }

}

