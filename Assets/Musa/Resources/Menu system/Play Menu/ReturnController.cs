using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //remeber to change to esc
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        }
    }
}
