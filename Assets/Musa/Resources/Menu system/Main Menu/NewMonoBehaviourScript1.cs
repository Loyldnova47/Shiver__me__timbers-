using UnityEngine;
using UnityEngine.SceneManagement;

public class NewtoVideo
    : MonoBehaviour
{
    public void NewGame()
    {
        SaveManager.DeleteSave(); // optional reset
        SceneManager.LoadScene("Prologue");
    }
}