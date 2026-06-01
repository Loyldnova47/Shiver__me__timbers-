using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AMainMenuController : MonoBehaviour
{
    //Populate these in the inspector
    public GameObject PlayMenuHolder;

    public void ToggleState()
    {
        bool currentstate = PlayMenuHolder.activeSelf;
        PlayMenuHolder.SetActive(!currentstate);
    }
}
