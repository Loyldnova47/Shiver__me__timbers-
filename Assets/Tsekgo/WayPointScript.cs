using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float rotationSpeed = 5f;
    


    [Header("Detection")]
    public float sightRange;
    public float touchRange;
    public Transform Quill;
    [SerializeField] public float chaseBreakDistance; //This has to be a value greater than the sight range

    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private int waypointIndex = 0;
    private int patrolDirection = 1;

    private enum State { Patrolling, Chasing, Touching }
    private State currentState = State.Patrolling;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (waypoints.Length > 0)
            transform.position = waypoints[0].position;
    }

   private void Update()
{
    if (Quill == null)
    {
        Debug.Log("Quill is NULL!");
        return;
    }

    float distanceToQuill = Vector2.Distance(transform.position, Quill.position);
    bool canSee = CanSeeQuill(distanceToQuill);

    // State transitions
    if (distanceToQuill <= touchRange)
    {
        currentState = State.Touching;
    }
    else if (canSee && currentState != State.Chasing)
    {
        currentState = State.Chasing;
    }
    else if (currentState == State.Chasing && (!canSee || distanceToQuill >= chaseBreakDistance))
    {
        currentState = State.Patrolling;
    }
    else if (currentState == State.Touching && distanceToQuill > touchRange)
    {
        currentState = State.Patrolling;
    }

    // Execute behavior
    switch (currentState)
    {
        case State.Patrolling:
            Patrol();
            break;
        case State.Chasing:
            ChasePlayer();
            break;
        case State.Touching:
            currentVelocity = Vector2.zero;
            OnTouchQuill();
            break;
    }
}

    private void FixedUpdate()
    {
        rb.linearVelocity = currentVelocity;
        WallAvoidance();
        
    }
    //Patroling between waypoints in enlisted order, then reverse direction at the end of the list
    private void Patrol()
    {
        if (waypoints.Length == 0) return;

        Vector2 target = waypoints[waypointIndex].position;
        Vector2 direction = (target - rb.position).normalized;
        currentVelocity = direction * moveSpeed;

        if (Vector2.Distance(rb.position, target) < 0.1f)
            AdvanceWaypoint();
    }
    //Movement logic for patroling between the waypoints
    private void AdvanceWaypoint()
    {
        int next = waypointIndex + patrolDirection;

        if (next >= waypoints.Length || next < 0)
        {
            patrolDirection *= -1;
            next = waypointIndex + patrolDirection;
        }

        waypointIndex = next;
    }
    //Avoid obstacles (game objects) while chasing Quill
    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        currentVelocity = direction * chaseSpeed;
    }
   

    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
    }

    private bool CanSeeQuill(float distanceToQuill)
    {
        if (distanceToQuill > sightRange) return false;
        
        Vector2 directionToQuill = ((Vector2)Quill.position - rb.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(
            rb.position, 
            directionToQuill,
            sightRange,
            LayerMask.GetMask("Seaweed")
        );

        if (hit.collider !=null)
        {
            Debug.DrawRay(rb.position, directionToQuill * sightRange, Color.red);
            return false;
        }
        Debug.DrawRay(rb.position, directionToQuill * sightRange, Color.green);
        return true;
    }

    private void WallAvoidance()
    {
        // Cast rays in multiple directions to detect obstacles and adjust movement accordingly
        Vector2[] rayDirections = new Vector2[]
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right,
            (Vector2.up + Vector2.right).normalized,
            (Vector2.up + Vector2.left).normalized,
            (Vector2.down + Vector2.right).normalized,
            (Vector2.down + Vector2.left).normalized
        };

        foreach (var dir in rayDirections)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, LayerMask.GetMask("Seaweed"));
            if (hit.collider != null)
            {
                // If an obstacle is detected, steer away from it
                currentVelocity += -dir * moveSpeed;
            }
        }
    }
}