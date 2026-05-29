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

        if (distanceToQuill <= touchRange)
        {
            currentState = State.Touching;
        }
        else if (distanceToQuill <= sightRange)
        {
            currentState = State.Chasing;
        }
        else
        {
            currentState = State.Patrolling;
        }

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
        FaceMovementDirection();
    }

    private void Patrol()
    {
        if (waypoints.Length == 0) return;

        Vector2 target = waypoints[waypointIndex].position;
        Vector2 direction = (target - rb.position).normalized;
        currentVelocity = direction * moveSpeed;

        if (Vector2.Distance(rb.position, target) < 0.1f)
            AdvanceWaypoint();
    }

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

    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        currentVelocity = direction * chaseSpeed;
    }

    private void FaceMovementDirection()
    {
        if (currentVelocity.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * rotationSpeed);
        }
    }

    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
    }
}