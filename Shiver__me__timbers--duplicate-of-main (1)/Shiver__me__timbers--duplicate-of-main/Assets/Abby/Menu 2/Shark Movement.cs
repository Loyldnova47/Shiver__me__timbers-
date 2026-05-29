using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public Transform _Target; //Move towards 
    public float _speed; // Units of movement each Second 

    // Update is called once per frame
    void Update()
    {
        // Move object towards Target by x amount of unites per second 
        transform.position = Vector3.MoveTowards(transform.position, _Target.position, _speed * Time.deltaTime);
    }
}
