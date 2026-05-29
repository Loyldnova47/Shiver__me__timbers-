using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    //Populate these in the inspector
    public GameObject MainMenuHolder;

    public void ToggleState()
    {
       bool currentstate = MainMenuHolder.activeSelf;
       MainMenuHolder.SetActive(!currentstate);

    }
    
}
