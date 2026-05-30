using UnityEngine;

public class textpopup : MonoBehaviour
{
    private bool displayText = false;

    void OnTriggerEnter()
    {
        displayText = true;
    }

    private void OnTriggerExit()
    {
        displayText = false;
    }

    void OnGUI()
    {
        if (displayText == true)
        {
            GUI.Label(new Rect(10, 10, 200, 20), "Press Space to interact");
        }
    }
}