using UnityEngine;
using UnityEngine.UI;

public class SettingstoMain : MonoBehaviour
{
    //Populate these in the inspector
    public GameObject SettingsHolder;

    public void ToggleState()
    {
        bool state = SettingsHolder.activeSelf;
        SettingsHolder.SetActive(!state);

    }

}
