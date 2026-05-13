using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public AudioClip[] ButtonSound;
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    
}
