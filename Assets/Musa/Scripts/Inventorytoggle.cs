using UnityEngine;
using System.Collections;


public class Inventorytoggle : MonoBehaviour
{
    public GameObject activeGameObject;

    public void ActivateObject()
    {
        if (activeGameObject.activeSelf != true)
        {
            activeGameObject.SetActive(true);
        }
        else
        {
            activeGameObject.SetActive(false);
        }
    }

// this code was developed to make the inventory slot appear when the button was pressed
// It was developed with the assitance of Musawenkosi Madlala

}
