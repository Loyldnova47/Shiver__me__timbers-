using UnityEngine;
using UnityEngine.InputSystem;

 public class movement : MonoBehaviour
{  
    
    public Rigidbody2D Quill;
    // Public variables to control movement and rotation speed, and a target transform 
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public Transform target;
    // Private variable to store the target rotation for smooth rotation towards the mouse cursor
    private Quaternion targetRotation;
    

    void Start()
    {
        Quill = GetComponent<Rigidbody2D>();
        //Prevent rotation from physics interactions
        Quill.freezeRotation = true; 
    }

    void Update()
    {
        // Get current mouse positioning in the screen space
        Vector3 mousePos = Mouse.current.position.ReadValue();

        // The z-coordinate is set to the distance from the camera to the near clipping plane to ensure correct depth when converting to world space
        mousePos.z = Camera.main.nearClipPlane; 

        // Convert mouse position from screen space to world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Adjusting heading of Quill to face the mouse cursor position
        Vector2 direction = (Vector2)mouseWorldPos - (Vector2)transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Quill smoothly rotates to face the mouse cursor direction
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Quill structure of movement based on WASD keys
        Vector2 movementDirection = Vector2.zero;


        if (Keyboard.current.wKey.isPressed)
        {
            // Quill moving in the direction it is facing (forward)
           movementDirection = (Vector2)(transform.up * moveSpeed);
            Quill.AddForce(movementDirection);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            // Quill moving in the opposite direction it is facing (backward)
            movementDirection = (Vector2)(-transform.up * moveSpeed);
            Quill.AddForce(movementDirection);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            // Quill moving to the left
            movementDirection = (Vector2)(-transform.right * moveSpeed);
            Quill.AddForce(movementDirection);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            // Quill moving to the right
            movementDirection = (Vector2)(transform.right * moveSpeed);
            Quill.AddForce(movementDirection);
        }
        if (!Keyboard.current.wKey.isPressed && !Keyboard.current.sKey.isPressed && !Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
        {
            //Quill remaining stationary when keys WASD are not pressed
            Quill.linearVelocity = Vector2.zero;
        }

    
    }
}
    