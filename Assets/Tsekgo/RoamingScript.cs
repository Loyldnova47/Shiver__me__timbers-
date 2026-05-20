using UnityEngine;


public class RoamingScript : MonoBehaviour
{
    // This script controls the roaming behavior of an NPC that interacts with a player character named "Quill"
    public Transform Quill;
    public float moveSpeed = 3f;
    public float sightRange = 10f;
    public float touchRange = 0.5f;
    public float roamRange = 3f;
    public float roamWaitTime = 2f;


    // Internal state variables for roaming behavior
    private Rigidbody2D rb;


    // Internal state variables for roaming behavior
    private Vector2 startPosition;
    private Vector2 roamTarget;
    private bool hasRoamTarget = false;
    private float roamTimer = 0f;
    private float stuckTimer = 0f;
    private Vector2 lastPosition;


    // Variable to store the current velocity for movement
    private Vector2 currentVelocity;


    //
    private void Awake()
    {
        // Find the "Quill" GameObject in the scene and store its Transform for later use
        rb = GetComponent<Rigidbody2D>();


        // Store the initial position of the NPC for roaming calculations
        startPosition = rb.position;
        lastPosition = rb.position;




        roamTimer = roamWaitTime;
    }


    private void Update()
    {
        // If Quill is not found, log a warning and exit the method to prevent errors
        if (Quill == null)
        {
            Debug.LogError("Quill is NOT assigned in Inspector!");
            return;
        }


        // Calculate the distance to Quill and determine behavior based on that distance
        float distanceToQuill = Vector2.Distance(rb.position, (Vector2)Quill.position);
        // Debug.Log("Distance: " + distanceToQuill);


        // If Quill is within touch range, trigger the touch interaction
        if (distanceToQuill <= touchRange)
        {
            // Stop movement when touching Quill
            OnTouchQuill();
            currentVelocity = Vector2.zero;
        }
        else if (distanceToQuill <= sightRange)
        {
            ChasePlayer();
        }
        else
        {
            Roam();
        }


        // Check if the NPC is stuck (not moving significantly) and if so, pick a new random roam target after a certain time
        HandleStuckDetection();
    }


    private void FixedUpdate()
    {
        // Apply the calculated velocity to the Rigidbody2D for movement
        rb.linearVelocity = currentVelocity;
    }


    //Script to avoid walls
    private Vector2 GetWallAvoidance()
    {
        // Perform a CircleCast to detect nearby obstacles in the "Obstacle" layer
        RaycastHit2D hit = Physics2D.CircleCast(
            rb.position,
            0.3f,
            Vector2.zero,
            0f,
            LayerMask.GetMask("Obstacle")
        );
        // If an obstacle is detected, calculate a push direction away from the obstacle and return it as a velocity vector
        if (hit.collider != null)
        {
            // Calculate a push direction away from the obstacle and return it as a velocity vector
            Vector2 pushDir = ((Vector2)rb.position - hit.point).normalized;
            return pushDir * moveSpeed;
        }


        return Vector2.zero;
    }


    // Script to chase the player when within sight range
    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        Vector2 avoid = GetWallAvoidance();


        currentVelocity = (direction * moveSpeed + avoid).normalized * moveSpeed;
    }


    // Script for roaming behavior
    private void Roam()
    {
        if (!hasRoamTarget)
        {
            roamTimer -= Time.deltaTime;


            if (roamTimer <= 0f)
            {
                // Pick a new random roam target within the specified roam range around the starting position
                Vector2 randomOffset = Random.insideUnitCircle * roamRange;
                roamTarget = startPosition + randomOffset;
                hasRoamTarget = true;
            }


            currentVelocity = Vector2.zero;
            return;
        }
        // Move towards the roam target while avoiding obstacles
        Vector2 direction = (roamTarget - rb.position).normalized;
        Vector2 avoid = GetWallAvoidance();


        currentVelocity = (direction * (moveSpeed * 0.5f) + avoid).normalized * (moveSpeed * 0.5f);


        // If the NPC is close enough to the roam target, reset the roaming state to pick a new target after waiting
        if (Vector2.Distance(rb.position, roamTarget) < 0.5f)
        {
            hasRoamTarget = false;
            roamTimer = roamWaitTime;
        }
    }


    // Script to detect if the NPC is stuck (not moving significantly) and if so, pick a new random roam target after a certain time
    private void HandleStuckDetection()
    {
        if (Vector2.Distance(rb.position, lastPosition) < 0.01f)
        {
            // If the NPC hasn't moved significantly, increment the stuck timer
            stuckTimer += Time.deltaTime;


            if (stuckTimer > 1f)
            {
                // If the NPC has been stuck for more than 1 second, pick a new random roam target to try to get unstuck
                Vector2 randomOffset = Random.insideUnitCircle * roamRange;
                roamTarget = rb.position + randomOffset;


                // Set the roaming state to move towards the new target and reset timers
                hasRoamTarget = true;
                roamTimer = 0f;
                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }
        // Update the last position for the next check
        lastPosition = rb.position;
    }


    // Script for handling touch events with Quill, currently just logs a message to the console but can be expanded for more complex interactions
    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
    }
}
