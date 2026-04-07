using UnityEngine;
using System.Collections;


public class Iventorytoggle : MonoBehaviour
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



}
