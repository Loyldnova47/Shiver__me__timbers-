using UnityEngine;

public class Lives : MonoBehaviour
{
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    // these are the Red hearts you see
    private GameObject gameOver;
    int deathCounter;
    //important for displaying the Black hearts
    private void Awoke()
    {
        heart1 = GameObject.Find("Heart Container 1");
        heart2 = GameObject.Find("Heart Container 2");
        heart3 = GameObject.Find("Heart Container 3");

        gameOver = GameObject.Find("Death screen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 respawner = new Vector3(0, 0, 0);
        // this respawns the player in the dead center this needs to be altered 

        //the following can be altered to add damage towards the player to trigger the death counter and eventual
        if (collision.collider.gameObject.CompareTag("RespawnTrigger"))
        {
            deathCounter += 1;
            transform.position = respawner;
        //When the repawntrigger is triggered then plus 1 is added on the Death counter 
        }

        if (deathCounter == 1)
        {
            Destroy(heart1);
        }

        if (deathCounter == 2)
        {
            Destroy(heart2);
        }

        if (deathCounter == 3)
        {
            Destroy(heart3);
        }

        if (deathCounter == 3)
        // one deathcount means that one red heart gets destroyed
        {
            Destroy(gameObject);
            Instantiate(gameOver, respawner, Quaternion.identity);
        }
    }

    // The script was done with the assistance of https://www.youtube.com/watch?v=Dg-6qoZ2JqI&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=3

}
