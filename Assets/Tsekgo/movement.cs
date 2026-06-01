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

    private float swimLock = 0f;

   

    //public AudioClip swimmingSound; // Assign this in the Inspector with your swimming sound effect
    //private AudioSource audioSource;

    [Header("Audio Settings")]
    
    public float minSpeed = 0f;
    public float maxSpeed = 5f;
    public float minVolume = 0.1f;
    public float maxVolume = 0.8f;
    public float minPitch = 0.8f;
    public float maxPitch = 1.3f;
    void Start()
    {
        if (Quill == null) Quill = GetComponent<Rigidbody2D>();
        //Prevent rotation from physics interactions
        Quill.freezeRotation = true;
        originalScale = transform.localScale;
        targetRotation = transform.rotation;

       
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1;
            targetRotation = Quaternion.Euler(0, 0, 0);
            // Set isSwimming bool to true 
            isSwimming = true;

        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1;
            targetRotation = Quaternion.Euler(0, 0, 180f);
            // Set isSwimming bool to true 
            isSwimming = true;

        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
            targetRotation = Quaternion.Euler(0, 0, 90f);
            // Set isSwimming bool to true 
            isSwimming = true;
            //Flip the sprite to the left
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
            targetRotation = Quaternion.Euler(0, 0, -90f);
            // Set isSwimming bool to true 
            isSwimming = true;
            //Flip the sprite to the right
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);

        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * 360f * Time.deltaTime);

        if (moveDirection == Vector3.zero)
        {
            // If no movement keys are pressed, set isSwimming to false
            isSwimming = false;

        }
        //Move the player
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        bool isMoving = moveDirection != Vector3.zero;

        if (isMoving)
        {
            swimLock -= Time.deltaTime;

            if (swimLock <= 0f)
            {
                SoundEffectManager.PlaySoundEffect("PlayerSwim");

                // reset lock (THIS controls spacing)
                swimLock = Random.Range(0.6f, 1.2f);
            }
        }
        else
        {
            swimLock = 0f;
        }
    }

}

    