using UnityEngine;

public class Re_enable : MonoBehaviour
{
    public GameObject targetObject; // The object to re-enable
    private void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true); // Re-enable the target object
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}