using UnityEngine;

public class ControlsController : MonoBehaviour
{
    //Populate these in the inspector
    public GameObject ControlsHolder;

    public void ToggleState()
    {
        bool currentstate = ControlsHolder.activeSelf;
        ControlsHolder.SetActive(!currentstate);
    }
}
