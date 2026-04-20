using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for UI components
using UnityEngine.SceneManagement; // Needed for scene management

public class MenuController : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("StartButton")
            .GetComponent<Button>()
            .onClick.AddListener(GameScene);
        // Example: Load the main game scene
    }

    public void GameScene()
    {
            Debug.Log("Start clicked"); // Shows in editor
            Loader.Load(Loader.Scene.GameScene); // Connected to the "GameScene"
    }   

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Quit clicked"); // Shows in editor
    }
    // this script was developed with the asistance from Code Monkey :  https://www.youtube.com/watch?v=3I5d2rUJ0pE&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=7
}

