using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour

{
    public Button prologueButton;

    public void ChangeScene(string GameScene)
    {
        SceneManager.LoadScene("Prologue");
    }
}


