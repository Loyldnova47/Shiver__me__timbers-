using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public SoundSo buttonSo;
    public void ChangeScene(string PlayMenu)
    {
        SoundMMManager.Instance.PlaySound(buttonSo);
        SceneManager.LoadScene("Play Menu");
    }
     
    
}
