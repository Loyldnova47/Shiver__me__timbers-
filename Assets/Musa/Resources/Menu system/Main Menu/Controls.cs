using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public SoundSo buttonSo;
    public void ChangeScene(string Controls)
    {
        SoundMMManager.Instance.PlaySound(buttonSo);
        SceneManager.LoadScene("Controls");
    }

}
