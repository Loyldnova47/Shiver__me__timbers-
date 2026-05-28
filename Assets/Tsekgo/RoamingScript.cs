using UnityEngine;

public class RoamingScript : MonoBehaviour
{
    public Transform Quill;
    public float moveSpeed;
    public float sightRange;
    public float touchRange;
    public float roamRange;
    public float roamWaitTime;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 roamTarget;
    private bool hasRoamTarget = false;
    private float roamTimer = 0f;
    private float stuckTimer = 0f;
    private Vector2 lastPosition;
    private Vector2 currentVelocity;

    [SerializeField] private float rotationSpeed = 5f;

    private enum NPCState { Roaming, Chasing, Touched }
    private NPCState state = NPCState.Roaming;

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

        // Lock the NPC permanently once touched
        if (state == NPCState.Touched)
        {
            currentVelocity = Vector2.zero;
            return;
        }

        float distanceToQuill = Vector2.Distance(rb.position, (Vector2)Quill.position);
        Debug.Log($"State: {state} | Distance: {distanceToQuill} | Touch: {touchRange} | Sight: {sightRange}");

        if (distanceToQuill <= touchRange)
        {
            state = NPCState.Touched;
            currentVelocity = Vector2.zero;
            OnTouchQuill();
        }
        else if (distanceToQuill <= sightRange)
        {
            state = NPCState.Chasing;
            ChasePlayer();
        }
        else
        {
            state = NPCState.Roaming;
            Roam();
        }

        HandleStuckDetection();

    }

    private void FaceMovementDirection()
    {
        if (currentVelocity.sqrMagnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(rb.rotation, targetAngle, Time.deltaTime * rotationSpeed);
            rb.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = currentVelocity;
        FaceMovementDirection();
    }

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

    private void ChasePlayer()
    {
        Vector2 direction = ((Vector2)Quill.position - rb.position).normalized;
        Vector2 avoid = GetWallAvoidance();
        currentVelocity = (direction * moveSpeed + avoid).normalized * moveSpeed;

       
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

            currentVelocity = Vector2.zero;
            return;

        }

        Vector2 direction = (roamTarget - rb.position).normalized;
        Vector2 avoid = GetWallAvoidance();
        Vector2 targetVelocity = (direction + avoid).normalized * (moveSpeed * 0.5f);
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, Time.deltaTime * 3f);

        if (Vector2.Distance(rb.position, roamTarget) < 0.5f)
        {
            hasRoamTarget = false;
            roamTimer = roamWaitTime;
        }
    }

    private void HandleStuckDetection()
    {
        if (state != NPCState.Roaming)
        {
            lastPosition = rb.position;
            return;
        }

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

    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
    }

    public void ResetAfterTouch()
    {
        state = NPCState.Roaming;
        roamTimer = roamWaitTime;
        hasRoamTarget = false;
    }
}