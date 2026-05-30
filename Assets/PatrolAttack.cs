using UnityEngine;

public class SharkController : MonoBehaviour
{
    // ── References ──────────────────────────────────────────────────────────
    public Transform Quill;

    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;

    // ── Tuning ───────────────────────────────────────────────────────────────
    [Header("Speed")]
    public float moveSpeed      = 3f;
    public float waypointSpeed  = 2f;   // slower while patrolling

    [Header("Ranges")]
    public float sightRange = 10f;      // Quill detected → start chasing
    public float loseRange  = 13f;      // Quill lost     → return to waypoints (should be > sightRange)
    public float touchRange = 0.5f;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 5f;

    // ── Internal state ───────────────────────────────────────────────────────
    private enum State { Waypoint, Chase, Touch }
    private State currentState = State.Waypoint;

    private Rigidbody2D rb;
    private int   waypointIndex  = 0;
    private float stuckTimer     = 0f;
    private Vector2 lastPosition;
    private Vector2 currentVelocity;

    // ── Unity lifecycle ──────────────────────────────────────────────────────
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPosition = rb.position;

        // Snap to first waypoint on spawn (mirrors original FollowThePath)
        if (waypoints != null && waypoints.Length > 0)
            rb.position = waypoints[0].position;
    }

    private void Update()
    {
        if (Quill == null)
        {
            Debug.LogError("Quill is NOT assigned in the Inspector!");
            return;
        }

        float distToQuill = Vector2.Distance(rb.position, (Vector2)Quill.position);

        // ── State transitions ────────────────────────────────────────────────
        switch (currentState)
        {
            case State.Waypoint:
                if (distToQuill <= touchRange)        currentState = State.Touch;
                else if (distToQuill <= sightRange)   currentState = State.Chase;
                break;

            case State.Chase:
                if (distToQuill <= touchRange)        currentState = State.Touch;
                else if (distToQuill > loseRange)
                {
                    // Return to the closest waypoint
                    waypointIndex = GetClosestWaypointIndex();
                    currentState  = State.Waypoint;
                }
                break;

            case State.Touch:
                // Re-evaluate every frame so the shark can resume chasing/patrolling
                if (distToQuill > touchRange)
                    currentState = distToQuill <= sightRange ? State.Chase : State.Waypoint;
                break;
        }

        // ── State behaviour ──────────────────────────────────────────────────
        switch (currentState)
        {
            case State.Waypoint: FollowWaypoints(); break;
            case State.Chase:    ChasePlayer();     break;
            case State.Touch:    OnTouchQuill();
                                 currentVelocity = Vector2.zero; break;
        }

        HandleStuckDetection();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = currentVelocity;
    }

    // ── Behaviours ───────────────────────────────────────────────────────────

    private void FollowWaypoints()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        // Loop back to start when the last waypoint is reached
        if (waypointIndex >= waypoints.Length)
            waypointIndex = 0;

        Vector2 target    = waypoints[waypointIndex].position;
        Vector2 direction = (target - rb.position).normalized;
        Vector2 avoid     = GetWallAvoidance();

        Vector2 targetVel = (direction + avoid).normalized * waypointSpeed;
        currentVelocity   = Vector2.Lerp(currentVelocity, targetVel, Time.deltaTime * 3f);

        // Rotate to face movement direction
        float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * rotationSpeed);

        if (Vector2.Distance(rb.position, target) < 0.2f)
            waypointIndex++;
    }

    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        Vector2 avoid     = GetWallAvoidance();

        currentVelocity = (direction * moveSpeed + avoid).normalized * moveSpeed;

        float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * rotationSpeed);
    }

    private void OnTouchQuill()
    {
        Debug.Log("Shark touched Quill!");
        // Add damage / game-over logic here
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    /// <summary>Wall avoidance using a CircleCast against the Obstacle layer.</summary>
    private Vector2 GetWallAvoidance()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            rb.position, 0.3f, Vector2.zero, 0f,
            LayerMask.GetMask("Obstacle"));

        if (hit.collider != null)
        {
            Vector2 pushDir = ((Vector2)rb.position - hit.point).normalized;
            return pushDir * moveSpeed;
        }
        return Vector2.zero;
    }

    /// <summary>Returns the index of the waypoint closest to the shark's current position.</summary>
    private int GetClosestWaypointIndex()
    {
        int   closest = 0;
        float minDist = float.MaxValue;

        for (int i = 0; i < waypoints.Length; i++)
        {
            float d = Vector2.Distance(rb.position, waypoints[i].position);
            if (d < minDist) { minDist = d; closest = i; }
        }
        return closest;
    }

    /// <summary>Nudges the shark if it hasn't moved for ~1 second.</summary>
    private void HandleStuckDetection()
    {
        if (Vector2.Distance(rb.position, lastPosition) < 0.01f)
        {
            stuckTimer += Time.deltaTime;
            if (stuckTimer > 1f)
            {
                // Only nudge during waypoint patrol; chasing handles itself
                if (currentState == State.Waypoint)
                    waypointIndex = GetClosestWaypointIndex();

                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }
        lastPosition = rb.position;
    }

    // ── Gizmos ───────────────────────────────────────────────────────────────
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        // Sight range (yellow)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        // Lose range (orange)
        Gizmos.color = new Color(1f, 0.5f, 0f);
        Gizmos.DrawWireSphere(transform.position, loseRange);

        // Touch range (red)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, touchRange);

        // Waypoint path
        if (waypoints == null || waypoints.Length < 2) return;
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null) continue;
            Gizmos.DrawSphere(waypoints[i].position, 0.15f);
            Gizmos.DrawLine(
                waypoints[i].position,
                waypoints[(i + 1) % waypoints.Length].position);
        }
    }
#endif
}