using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
// this is what makes the interaction sysytem what it is 
{
    void Interact();
    void OnTouchingPlayer();
    void OnNotTouchingPlayer();

    //
}

public class Interactor : MonoBehaviour
{
    private IInteractable currentInteractable;
    void Update()
    {
        if (Mouse.current.leftButton.IsActuated() && currentInteractable != null)
        {
            currentInteractable.Interact(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {
           currentInteractable = interactable;
           currentInteractable.OnTouchingPlayer();
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable.OnNotTouchingPlayer();
            currentInteractable = interactable;
            
        }
        // This means that objects that are interactable via their collision components can be picked up using the left Mouse key 
    }



    // this script was constructed with assistence from Unity Unlocked:
    //https://www.youtube.com/watch?v=OVPrdB5WsOc&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=4
}
