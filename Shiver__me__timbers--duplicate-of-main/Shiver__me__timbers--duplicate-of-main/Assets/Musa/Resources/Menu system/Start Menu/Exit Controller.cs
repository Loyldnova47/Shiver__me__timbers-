using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene("Main Menu");
    }
}