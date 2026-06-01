using UnityEngine;

public class SharkAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastPosition;

    private const int DIR_LEFT  = 0;
    private const int DIR_RIGHT = 1;
    private const int DIR_UP    = 2;
    private const int DIR_DOWN  = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void FixedUpdate()  // ← changed from Update to FixedUpdate
    {
        Vector2 moveDir = (Vector2)transform.position - lastPosition;

        Debug.Log("MoveDir: " + moveDir + " Magnitude: " + moveDir.magnitude);

        if (moveDir.magnitude > 0.001f)
        {
            SetDirectionAnimation(moveDir);
        }

        lastPosition = transform.position;
    }

    void SetDirectionAnimation(Vector2 moveDir)
    {
        if (Mathf.Abs(moveDir.x) >= Mathf.Abs(moveDir.y))
        {
            if (moveDir.x < 0)
                animator.SetInteger("direction", DIR_LEFT);
            else
                animator.SetInteger("direction", DIR_RIGHT);
        }
        else
        {
            if (moveDir.y < 0)
                animator.SetInteger("direction", DIR_DOWN);
            else
                animator.SetInteger("direction", DIR_UP);
        }
    }
}