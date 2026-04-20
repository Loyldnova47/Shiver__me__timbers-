using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
   
    public GameObject projectile ;

    private float distance;

   public bool isDistracted = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //projectile = GameObject.Find("projectile").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //FindPlayer();
        CheckForDistractions();
        if (!isDistracted)
        {
            FindPlayer();
            Debug.Log("NOT Distarcted");
        }
        else
        {
            Debug.Log("Distarcted");
            
        }




    }

    void FindPlayer()
    {

        distance = Vector2.Distance(transform.position, player.transform.position);
        //this function gets the between the enemy and the player
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();// it will keep its direction but it will set the length to 1
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        // Moves towards a given position
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        //rotates to face a specific direction

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            //enemy will only chase within a particular parametre 
        }

        if (distanceBetween > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

    }
    void CheckForDistractions()
    {
        projectile = GameObject.FindWithTag("projectile");
        if (projectile == null)
        {
            isDistracted = false;
            return;


        }
        else
        {
            Debug.Log("Projectile is " + projectile.name);
            isDistracted = true; 
            GoToDistraction();


        }
    }
    void GoToDistraction()
    {
        projectile = GameObject.FindWithTag("projectile");
        if (projectile == null)
        {
            return;


        }
        else
        {
            Debug.Log("Projectile is " + projectile.name);
            distance = Vector2.Distance(transform.position, projectile.transform.position);
            //this function gets the between the enemy and the player
            Vector2 direction = projectile.transform.position - transform.position;
            direction.Normalize();// it will keep its direction but it will set the length to 1
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


            transform.position = Vector2.MoveTowards(this.transform.position, projectile.transform.position, speed * Time.deltaTime);
            // Moves towards a given position
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            //rotates to face a specific direction

            //if (distance < distanceBetween)
            //{
            //    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            //    //enemy will only chase within a particular parametre 
            //}

            //if (distanceBetween > 0)
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            //}
        }


    }

}

