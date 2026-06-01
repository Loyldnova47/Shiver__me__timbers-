using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AAMainMenuController : MonoBehaviour
{
    public void ChangeScene(string PlayMenu)
    {
        SceneManager.LoadScene("Start Menu");
    }
     
    
}
