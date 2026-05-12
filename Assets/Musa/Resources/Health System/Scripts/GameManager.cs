using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;


    //Restart the game
    void Start()
    {
        gameOverScreen.SetActive(false);
        
    }

    public void TriggerGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
       
    }

    public void RestartGame()
    {
        //Reset our timescale
        Time.timeScale = 1;

        //Reload the current scene
        SceneManager.LoadScene("GameScene (Main)");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

   
}
