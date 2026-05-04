using UnityEngine;

 public class movement : MonoBehaviour
{  
    
    public Rigidbody2D Quill;
    // Public variables to control movement and rotation speed, and a target transform 
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public Transform target;
    // Private variable to store the target rotation for smooth rotation towards the mouse cursor
    private Quaternion targetRotation;
    bool isSwimming = false;
    private Vector3 originalScale;
    private Vector3 moveDirection;

    

    void Start()
    {
        Quill = GetComponent<Rigidbody2D>();
        //Prevent rotation from physics interactions
        Quill.freezeRotation = true; 
        originalScale = transform.localScale;
      
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        Vector3 keyDirection = Vector3.zero;
        Vector3 MovePosition = Vector3.zero;
        

         if (Input.GetKey(KeyCode.W))
        {
           moveDirection.y += 1;
           keyDirection = Vector3.up;
            // Set isSwimming bool to true 
            isSwimming = true;

        }   
         if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1;
            keyDirection = Vector3.down;
            // Set isSwimming bool to true 
            isSwimming = true;  
        }
       if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
            keyDirection = Vector3.left;                    
            // Set isSwimming bool to true 
            isSwimming= true; 
            //Flip the sprite to the left
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
         if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
            keyDirection = Vector3.right;
            // Set isSwimming bool to true 
            isSwimming = true; 
            //Flip the sprite to the right
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }

        if (keyDirection != Vector3.zero)
        { 
            float angle = Mathf.Atan2(keyDirection.y, keyDirection.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        //Move the player
       transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

     void FixedUpdate()
    {
        // Physics-safe movement
        Quill.MovePosition(Quill.position + (Vector2)(moveDirection.normalized * moveSpeed * Time.fixedDeltaTime));

        // Physics-safe rotation
        Quaternion newRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
        Quill.MoveRotation(newRotation);
    }
}
    