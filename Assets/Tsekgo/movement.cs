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
         if (Input.GetKey(KeyCode.W))
         {
           moveDirection.y += 1;

         }   
         if (Input.GetKey(KeyCode.S))
         {
            moveDirection.y -= 1;
            
         }
       if (Input.GetKey(KeyCode.A))
       {
            moveDirection.x -= 1;
            // Set isSwimming bool to true 
            isSwimming= true; 
            //Flip the sprite to the left
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
       }
         if (Input.GetKey(KeyCode.D))
         {
            moveDirection.x += 1;
            // Set isSwimming bool to true 
            isSwimming = true; 
            //Flip the sprite to the right
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
         }
        //Move the player
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        
    }
 }
    