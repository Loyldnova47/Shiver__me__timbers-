using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Awake()
    {
        // Test to see if the buttons actually work
        if (startButton != null)
            startButton.onClick.AddListener(() => PlayGame());
        else
            Debug.LogError("StartButton not assigned!");

        if (quitButton != null)
            quitButton.onClick.AddListener(() => QuitGame());
        else
            Debug.LogError("QuitButton not assigned!");
    }

    public void PlayGame()
    {
        // This makes the start button work  
        Debug.Log("Start Button Clicked");
        Loader.Load(Loader.Scene.GameScene);
    }

    public void QuitGame()
    {
        // This makes the quit button work 
        Debug.Log("Quit Button Clicked");
        Application.Quit();
    }
   
    public class Menu : MonoBehaviour
    {
        public void OnPlayButtonPressed()
        {
            Loader.Load(Loader.Scene.GameScene);
        }
    }
    // this script was developed with the asistance from Code Monkey :  https://www.youtube.com/watch?v=3I5d2rUJ0pE&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=7
}

