using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;


public class RespawnTrigger : MonoBehaviour
{
    public GameObject Deathscreen;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        // "Fire1" should me a virtual button, for now it is linked to an actual button
        { 
            // create code for the restart
            Deathscreen.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("If character dies this must show up!");
        }
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }


     //void Upadate()
     //{
     //   if (Input.GetButton("Quit"))
     //   {
            
     //      Deathscreen.SetActive(false);
     //      Time.timeScale = 1;
            
     //   }
     //}

    public void QuitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    // this script uses the pausemenu as reference but alters the buttons:https://www.youtube.com/watch?v=fspxIduosYQ&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=6
}
