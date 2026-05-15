using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public SoundSo buttonSo;
    public void ChangeScene(string MainMenu)
    {
        SoundMMManager.Instance.PlaySound(buttonSo);
        SceneManager.LoadScene(MainMenu);
    }
   
}
