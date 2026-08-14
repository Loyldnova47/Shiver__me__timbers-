using UnityEngine;


public class RoamingScript : MonoBehaviour
{
    // This script controls the roaming behavior of an NPC that interacts with a player character named "Quill".
    public Transform Quill;
    public float moveSpeed = 3f;
    public float sightRange = 5f;
    public float touchRange = 1f;
    public float roamRange = 3f;
    public float roamWaitTime = 2f;
    public float obstacleDetectRange = 1.5f;

    // Internal state variables for roaming behavior
    private Vector2 startPosition;
    private Vector2 roamTarget;
    private bool hasRoamTarget = false;
    private float roamTimer = 0f;
    private float stuckTimer = 0f;
    private Vector2 lastPosition;

    private void Awake()
    {
        // Find the "Quill" GameObject in the scene and store its Transform for later use
        Quill = GameObject.Find("Quill").transform;
        startPosition = transform.position;
        lastPosition = transform.position;
    }

    private void Update()
    {
        // If Quill is not found, log a warning and exit the method to prevent errors
        if (Quill == null)
        {
            Debug.Log("Quill is NULL!");
            return;
        }

        // Calculate the distance to Quill and determine behavior based on that distance
        float distanceToQuill = Vector2.Distance(transform.position, Quill.position);
        Debug.Log($"Distance: {distanceToQuill}, SightRange: {sightRange}");

        // If Quill is within touch range, trigger the touch interaction
        if (distanceToQuill <= touchRange)
        {
            OnTouchQuill();
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
        if (Vector2.Distance(transform.position, lastPosition) < 0.01f)
        {
            // Increment the stuck timer if the NPC is not moving
            stuckTimer += Time.deltaTime;
            if (stuckTimer > 3f)
            {
                // Pick a new random roam target if stuck for more than 3 seconds
                float randomX = Random.Range(-roamRange, roamRange);
                float randomY = Random.Range(-roamRange, roamRange);
                roamTarget = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
                hasRoamTarget = true;
                roamTimer = 0f;
                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }

        lastPosition = transform.position;
    }

    private Vector2 GetSteeringDirection(Vector2 desiredDirection)
    {
        // Check for obstacles in the desired direction using a raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, desiredDirection, obstacleDetectRange);

        // If an obstacle is detected, try to find an alternative direction by rotating the desired direction in increments of 45 degrees
        if (hit.collider != null && hit.collider.gameObject != gameObject && hit.collider.gameObject != Quill.gameObject)
        {
            for (int angle = 45; angle <= 360; angle += 45)
            {
                // Rotate the desired direction by the current angle and check for obstacles in that direction
                Vector2 newDir = Quaternion.Euler(0, 0, angle) * desiredDirection;
                RaycastHit2D newHit = Physics2D.Raycast(transform.position, newDir, obstacleDetectRange);

                if (newHit.collider == null)
                    return newDir;
            }
        }

        return desiredDirection;
    }

    private void ChasePlayer()
    {
        // Move towards Quill while avoiding obstacles
        Vector2 direction = (Quill.position - transform.position).normalized;
        direction = GetSteeringDirection(direction);
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, moveSpeed * Time.deltaTime);
    }

    private void Roam()
    {
        if (!hasRoamTarget)
        {
            roamTimer -= Time.deltaTime;
            if (roamTimer <= 0f)
            {
                // Pick a random point within the roam range around the starting position as the new roam target
                float randomX = Random.Range(-roamRange, roamRange);
                float randomY = Random.Range(-roamRange, roamRange);
                roamTarget = new Vector2(startPosition.x + randomX, startPosition.y + randomY);
                hasRoamTarget = true;
            }
        }
        else
        {
            // Move towards the roam target while avoiding obstacles
            Vector2 direction = (roamTarget - (Vector2)transform.position).normalized;
            direction = GetSteeringDirection(direction);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, (moveSpeed * 0.5f) * Time.deltaTime);

            // Check if the NPC has reached the roam target and if so, reset the roaming state
            if (Vector2.Distance(transform.position, roamTarget) < 1.5f)
            {
                hasRoamTarget = false;
                roamTimer = roamWaitTime;
            }
        }
    }

    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
    }

    private void OnDrawGizmosSelected()
    {   
        // Visualize sight and touch ranges in the editor for debugging purposes
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, touchRange);
    }
}