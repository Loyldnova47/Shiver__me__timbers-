using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButtonLogic : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Prologue");
    }
}
