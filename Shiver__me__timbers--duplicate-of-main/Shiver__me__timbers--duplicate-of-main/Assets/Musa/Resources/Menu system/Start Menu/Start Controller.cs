using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
   
}
