using UnityEngine;

public class Collisonwiththeobjects : MonoBehaviour
{
    // This runs when a solid collision happens
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("PPlayer"))
        {
            Debug.Log("Player bumped into the solid object!");
            SoundEffectManager.PlaySoundEffect("PlayerBump");

            // Add your custom logic here
        }
    }
}
