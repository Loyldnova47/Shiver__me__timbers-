using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSwitch : MonoBehaviour
{
    public void ChangeScene(string GameScene)
    {
        SceneManager.LoadScene("Shiver me timbers'");
    }
}
