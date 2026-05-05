using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public Transform Quill;
    public float moveSpeed = 3f;
    public float sightRange = 10f;
    public float touchRange = 1f;
    public float roamRange = 5f;
    public float roamWaitTime = 2f;

    private Vector2 roamTarget;
    private bool hasRoamTarget = false;
    private float roamTimer = 0f;

    private void Awake()
    {
        Quill = GameObject.Find("Quill").transform;
    }

    private void Update()
    {
        float distanceToQuill = Vector2.Distance(transform.position, Quill.position);

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
    }

    private void ChasePlayer()
    {
        Vector2 direction = (Quill.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Roam()
    {
        // Wait at current spot before picking new target
        if (!hasRoamTarget)
        {
            roamTimer -= Time.deltaTime;
            if (roamTimer <= 0f)
            {
                // Pick a random nearby point
                float randomX = Random.Range(-roamRange, roamRange);
                float randomY = Random.Range(-roamRange, roamRange);
                roamTarget = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
                hasRoamTarget = true;
            }
        }
        else
        {
            // Move toward roam target
            Vector2 direction = (roamTarget - (Vector2)transform.position).normalized;
            transform.Translate(direction * (moveSpeed * 0.5f) * Time.deltaTime);

            // Check if reached target
            if (Vector2.Distance(transform.position, roamTarget) < 0.5f)
            {
                hasRoamTarget = false;
                roamTimer = roamWaitTime; // Wait before roaming again
            }
        }
    }

    private void OnTouchQuill()
    {
        Debug.Log("Touched Quill!");
        // Add your touch logic here
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, touchRange);
    }
}