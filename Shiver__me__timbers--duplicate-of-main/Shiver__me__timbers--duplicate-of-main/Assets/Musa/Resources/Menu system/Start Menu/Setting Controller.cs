using UnityEngine;


public class SettingsController : MonoBehaviour
{
    //Populate these in the inspector
    public GameObject SettingsHolder;

    public void ToggleState()
    {
        bool currentstate = SettingsHolder.activeSelf;
        SettingsHolder.SetActive(!currentstate);
    }
}
