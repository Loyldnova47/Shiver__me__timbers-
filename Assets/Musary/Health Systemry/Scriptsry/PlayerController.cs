using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // Variable related to player character movement
    public InputAction MoveAction;
    public float speed = 3.0f;

    private Rigidbody2D rigidbody2d;
    private Vector2 move;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        MoveAction.Enable();
    }

    void OnDisable()
    {
        MoveAction.Disable();
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }

    //void FixedUpdate()
    //{
    //    Vector2 position = rigidbody2d;
    //}

}