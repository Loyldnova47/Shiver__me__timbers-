using UnityEngine;

public class RoamingScript : MonoBehaviour
{
    public Transform Quill; // MUST be assigned in Inspector
    public float moveSpeed = 3f;
    public float sightRange = 10f;
    public float touchRange = 0.5f;
    public float roamRange = 3f;
    public float roamWaitTime = 2f;

    private Rigidbody2D rb;

    private Vector2 startPosition;
    private Vector2 roamTarget;
    private bool hasRoamTarget = false;
    private float roamTimer = 0f;
    private float stuckTimer = 0f;
    private Vector2 lastPosition;

    private Vector2 currentVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = rb.position;
        lastPosition = rb.position;

        roamTimer = roamWaitTime;
    }

    private void Update()
    {
        if (Quill == null)
        {
            Debug.LogError("Quill is NOT assigned in Inspector!");
            return;
        }

        float distanceToQuill = Vector2.Distance(rb.position, (Vector2)Quill.position);
        // Debug.Log("Distance: " + distanceToQuill);

        if (distanceToQuill <= touchRange)
        {
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

        HandleStuckDetection();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = currentVelocity;
    }

    // ---------------- WALL AVOIDANCE ----------------
    private Vector2 GetWallAvoidance()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            rb.position,
            0.3f,
            Vector2.zero,
            0f,
            LayerMask.GetMask("Obstacle")
        );

        if (hit.collider != null)
        {
            Vector2 pushDir = ((Vector2)rb.position - hit.point).normalized;
            return pushDir * moveSpeed;
        }

        return Vector2.zero;
    }

    // ---------------- CHASE ----------------
    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        Vector2 avoid = GetWallAvoidance();

        currentVelocity = (direction * moveSpeed + avoid).normalized * moveSpeed;
    }

    // ---------------- ROAM ----------------
    private void Roam()
    {
        if (!hasRoamTarget)
        {
            roamTimer -= Time.deltaTime;

            if (roamTimer <= 0f)
            {
                Vector2 randomOffset = Random.insideUnitCircle * roamRange;
                roamTarget = startPosition + randomOffset;
                hasRoamTarget = true;
            }

            currentVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (roamTarget - rb.position).normalized;
        Vector2 avoid = GetWallAvoidance();

        currentVelocity = (direction * (moveSpeed * 0.5f) + avoid).normalized * (moveSpeed * 0.5f);

        if (Vector2.Distance(rb.position, roamTarget) < 0.5f)
        {
            hasRoamTarget = false;
            roamTimer = roamWaitTime;
        }
    }

    // ---------------- STUCK DETECTION ----------------
    private void HandleStuckDetection()
    {
        if (Vector2.Distance(rb.position, lastPosition) < 0.01f)
        {
            stuckTimer += Time.deltaTime;

            if (stuckTimer > 1f)
            {
                Vector2 randomOffset = Random.insideUnitCircle * roamRange;
                roamTarget = rb.position + randomOffset;

                hasRoamTarget = true;
                roamTimer = 0f;
                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }

        lastPosition = rb.position;
    }

    // ---------------- TOUCH ----------------
    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
    }
}