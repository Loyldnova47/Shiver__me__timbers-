using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour
{
    public SoundSo buttonSo;
    public void ChangeScene(string GameScene)
    {
        SoundMMManager.Instance.PlaySound(buttonSo);
        SceneManager.LoadScene("GameScene (Main)");
    }
    
}