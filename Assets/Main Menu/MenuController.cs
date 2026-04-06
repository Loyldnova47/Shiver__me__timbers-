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
            Loader.Load(Loader.Scene.GameScene); // Assuming you have a scene named "GameScene"
    }   

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Quit clicked"); // Shows in editor
    }
}