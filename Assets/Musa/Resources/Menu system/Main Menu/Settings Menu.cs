using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public SoundSo buttonSo;
    public void ChangeScene(string SettingsMenu)
    {
        SoundMMManager.Instance.PlaySound(buttonSo);
        SceneManager.LoadScene("Settings");
    }

}
