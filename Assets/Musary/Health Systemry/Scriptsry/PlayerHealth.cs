using UnityEngine;


// Attach to an empty gameObject 
//To initialize script on a new scene, add updateHealth() in the Awake or Start Method of your player
//Then just use this script in your OnCollision method using thisScrpt.Health --

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthContainer1, HealthContainer2, HealthContainer3;
    public GameObject[] Sprites;
    // Declares a public array of components that will be enabled, disabled, or swapped
    
    [SerializeField] private GameObject gameOver;
    //A private variable to keep between scenes
    int health = 3;

    // Now we define Get / Set methods for health
    // In case we Set health to a different value we want to update UI

    public int Health
    {
       get { return health; }
       set
       {
            int newHealth = Mathf.Clamp(value, 0, 3);

            if (health != newHealth)
            {
                health = newHealth;
                updateHealthUI();
                
                if (health <= 0)
                {
                    Die();
                }
            }
       }
    }
        
           

    public void TakeDamage(int damage) // this value will be sent from the enemy's script.
    {
       Health -= damage; 
    }

    private void updateHealthUI()
    {
        for (int i = 0; i < Sprites.Length; i++)
        {
            //Hide all images superior to the newHealth
            // i changed the images into sprites 
            if (Sprites[i] != null)
            {
                Sprites[i].SetActive(i < health);
            }   
        }
    }

    private void Awake()
    {
        Sprites = new GameObject[]
        {
            HealthContainer1,
            HealthContainer2,
            HealthContainer3
        };

        updateHealthUI();

    }

    private void Die()
    {
        if (gameOver != null)
           gameOver.SetActive(true);

        Destroy(gameObject);
    }
}
