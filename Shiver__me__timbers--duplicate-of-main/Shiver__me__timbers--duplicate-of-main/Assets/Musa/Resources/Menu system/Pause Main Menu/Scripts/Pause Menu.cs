using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Container;
    void Update()
    {
        // this exercutes the pause menu from pressing the "esc" button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Container.SetActive(true);
           Time.timeScale = 0;
        }    
    }

    // this resumes the game 
    public void ResumeButton()
    {
        Container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    //This script was done with the assistance : https://www.youtube.com/watch?v=fspxIduosYQ&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=6
}
