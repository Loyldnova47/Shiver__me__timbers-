using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public void ChangeScene(string SettingsMenu)
    {
        SceneManager.LoadScene("Settings Menu");
    }

}
