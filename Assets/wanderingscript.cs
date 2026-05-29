using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class wanderingscript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    public Transform Quill;
    public float sightRange;
    public float touchRange;
    public float roamRange;
    public float roamWaitTime;
    public float obstacleDetectRange;
    public float stuckTimeThreshold;
    public float distanceToQuill;
    

    private Vector2 startPosition;
    private Vector2 roamTarget;
    private bool hasRoamTarget = false;
    private float roamTimer;
    private float stuckTimer;
    private Vector2 lastPosition;

    Rigidbody2D rb;
    CapsuleCollider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude < 0.1f)
        {   // If the NPC is not moving, pick a random direction and move
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.linearVelocity = randomDirection * moveSpeed;  
        }

        else
        {
            // Check for obstacles in the direction of movement and change direction if an obstacle is detected
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.linearVelocity.normalized, obstacleDetectRange);
            if (hit.collider != null && hit.collider != col)
            {
                Vector2 randomDirection = Random.insideUnitCircle.normalized;
                rb.linearVelocity = randomDirection * moveSpeed;  
            }
        }

        if (distanceToQuill <= touchRange)
        {
            TouchQuill();
        }
        else if (distanceToQuill <= sightRange)
        {
            ChasePlayer();
        }
        else
        {
            Roam();
        }

    }

    private void FixedUpdate()
    {
        FaceMovementDirection();

        // Check for obstacles in the direction of movement and change direction if an obstacle is detected
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.linearVelocity.normalized, 0.5f);
        if (hit.collider != null && hit.collider != col)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.linearVelocity = randomDirection * moveSpeed;  
        }
    }

    private void FaceMovementDirection()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle (rb.rotation, targetAngle, Time.deltaTime * rotationSpeed);
            rb.rotation = angle;
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    private void ChasePlayerWithObstacleAvoidance()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;

        // Check for obstacles in the direction of movement and change direction if an obstacle is detected
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f);
        if (hit.collider != null && hit.collider != col)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.linearVelocity = randomDirection * moveSpeed;  
        }
        else
        {
            rb.linearVelocity = direction * moveSpeed;
        }
    }


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

            rb.linearVelocity = Vector2.zero;
            return;

        }

        Vector2 direction = (roamTarget - rb.position).normalized;
        rb.linearVelocity = direction * moveSpeed * 0.5f;  
    }

    private void TouchQuill()
    {
        // Implement what happens when the NPC touches Quill (e.g., damage, dialogue, etc.)
    }



}
