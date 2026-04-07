using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Awake()
    {
        // Safety check
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
        Debug.Log("Start Button Clicked");
        Loader.Load(Loader.Scene.GameScene);
    }

    public void QuitGame()
    {
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
}