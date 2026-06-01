using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void ContinueGame()
    {
        int savedLevel = SaveManager.LoadLevel();
        SceneManager.LoadScene(savedLevel);
    }
}
