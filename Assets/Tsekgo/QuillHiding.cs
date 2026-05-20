using UnityEngine;
using UnityEngine.InputSystem;

public class QuillHiding : MonoBehaviour
{
    // Public variables to specify the target tag for hiding and the maximum distance for hiding
    public string targetTag = "Seaweed1";
    public float hideDistance = 2.0f;

    // Private variable to store the original position of Quill before hiding
    private Vector3 originalPosition;

    // Flag to track whether Quill is currently hiding
    private bool isHiding = false;

    // References to components for controlling visibility and movement
    private SpriteRenderer quillRenderer;
    private movement movementScript;
    private Rigidbody2D rb;

    void Start()
    {
        // Get references to the SpriteRenderer, movement script, and Rigidbody2D components
        quillRenderer = GetComponent<SpriteRenderer>();
        movementScript = GetComponent<movement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Toggle hiding with the space key
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // If not currently hiding, attempt to hide; otherwise, unhide
            if (!isHiding)
                PerformHide();
            else
                Unhide();
        }
    }

    void PerformHide()
    {
        // Find the nearest seaweed object with the specified tag
        GameObject seaweed = GameObject.FindWithTag(targetTag);

        if (seaweed != null)
        {
            // Calculate the distance from Quill to the seaweed
            float distanceToSeaweed = Vector2.Distance(transform.position, seaweed.transform.position);

            // If the seaweed is too far away, do not hide and log a message
            if (distanceToSeaweed > hideDistance)
            {
                Debug.Log("Too far!");
                return;
            }

            // Store original position before hiding
            originalPosition = transform.position;

            // Disable movement and physics so nothing fights the position change
            movementScript.enabled = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;

            // Move Quill behind seaweed
            transform.position = new Vector3(
                seaweed.transform.position.x,
                seaweed.transform.position.y,
                transform.position.z
            );

            isHiding = true;
            Debug.Log("Hiding!");
        }
    }

    void Unhide()
    {
        // Restore position
        transform.position = originalPosition;

        // Re-enable movement and physics
        rb.bodyType = RigidbodyType2D.Dynamic;
        movementScript.enabled = true;

        // Set hiding state to false
        isHiding = false;
        Debug.Log("Unhiding!");
    }
}