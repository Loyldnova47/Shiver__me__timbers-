using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void ChangeScene(string PlayMenu)
    {
        SceneManager.LoadScene("Play Menu");
    }
     
    
}
