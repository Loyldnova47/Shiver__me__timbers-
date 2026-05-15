using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public SoundSo buttonSo;
    public void ChangeScene(string MainMenu)
    {
        SoundMMManager.Instance.PlaySound(buttonSo);
        SceneManager.LoadScene("Main Menu");
    }
}