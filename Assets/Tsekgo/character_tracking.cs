using UnityEngine;
using UnityEngine.InputSystem;

public class character_tracking : MonoBehaviour
{
    //Tracking Quill
    public Transform target;
    //How smoothly the camera tracks Quill
    public float smoothSpeed = 0.2f;
    //Initial zoom distance from Quill
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    //Current zoom level of the camera
    private float currentZoom;
    //How fast the camera zooms in and out
    public float zoomSpeed = 10f;
    //Minimum zoom distance from Quill
    public float minZoom = 5f;
    //Maximum zoom distance from Quill
    public float maxZoom = 20f;
    

    void Start()
    { 
        // Check if the target is not assigned in the inspector, if not, find the GameObject named "Quill" and set it as the target
        if (target == null)
        {
            // Find the GameObject named "Quill" in the scene and set it as the target for the camera to follow
            target = GameObject.Find("Quill").transform;
        }
        
        // Initialize the current zoom level to the camera's initial field of view
        currentZoom = Camera.main.fieldOfView;
    }

    // Update is called once per frame after all Update functions gave ran
    void LateUpdate()
    {
        // Check if there is an assigned target to follow
        if (target == null) return;
       
        // Working with zoom input 
        Vector3 desiredPosition = target.position + offset;
        // Camera smoothly moves towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Ensures camera is always on Quill
        transform.LookAt(target);

        // Working with zoom input
        if (Mouse.current != null && Mouse.current.scroll.ReadValue().y != 0)
        {float scrollData = Mouse.current.scroll.ReadValue().y;

        if (Mathf.Abs(scrollData) > 0.01f)

            {
            // Adjust the current zoom level based on mouse scroll input
            currentZoom -= Mouse.current.scroll.ReadValue().y * zoomSpeed;
            //Ancour the zoom level to be within defined perimeters 
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            // Update the camera's field of view to reflect the new zoom level
            Camera.main.fieldOfView = currentZoom;

            // Update the camera's position to maintain the correct distance from Quill based on the new zoom level
            Camera.main.transform.position = target.position - offset.normalized * currentZoom;
            }
        }
    }
}
