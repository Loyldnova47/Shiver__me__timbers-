using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour
{
    public void ChangeScene(string GameScene)
    {
        SceneManager.LoadScene("Level 1");
    }
}