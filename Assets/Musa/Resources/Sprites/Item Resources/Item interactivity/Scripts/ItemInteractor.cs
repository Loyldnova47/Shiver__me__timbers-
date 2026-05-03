using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{

    //we need to tie this in a bit more
    
    public void Interact()
    {
        PickUp();
    }

    public void OnNotTouchingPlayer() 
    { 
        
    }

    public void OnTouchingPlayer()
    {
            
    }

    void PickUp()
    {
        Destroy(gameObject);
        // this will "pick up the object"
        // the code does not link to the inventory system
    }

    // this code was developed with the assisstance of Unity Unlocked:
    //https://www.youtube.com/watch?v=OVPrdB5WsOc&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=4
}
