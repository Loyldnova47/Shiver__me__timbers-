using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenuController : MonoBehaviour
{
    //Populate these in the inspector
    public GameObject PlayMenuHolder;

    public void ToggleState()
    {
        bool currentstate = PlayMenuHolder.activeSelf;
        PlayMenuHolder.SetActive(!currentstate);
    }
}
