using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    // Public variables for pathfinding and movement
    public Node currentNode;
    public List<Node> path = new List<Node>();
    // Public variable to control movement speed of the NPC
    public float moveSpeed = 2f;

    private void Start()
    {
        // Get reference to Rigidbody2D component and find the closest node to start pathfinding
        rb = GetComponent<Rigidbody2D>();
        currentNode = GetClosestNode();

        //Prevent rotation from physics interactions
        rb.freezeRotation = true; 
    }

    // Handle interactions with Quill when colliding with it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for interaction with Quill when colliding
        if (other.gameObject.name == "Quill")
        {
            Debug.Log("Interacting with Quill!");
            // Tsekgo put in interaction code here
        }
    }

    private void Update()
    {
        // If there is a path to follow, move along it; otherwise, generate a new path
        if (path != null && path.Count > 0)
        {
            MoveAlongPath();
        }
        else
        {
            GenerateNewPath();
        }
    }

    void MoveAlongPath()
    {   // Move towards the next node in the path and rotate to face it
        Debug.Log("Moving towards: " + path[0].transform.position);

        // Move towards the next node in the path
        rb.MovePosition(Vector2.MoveTowards(rb.position, path[0].transform.position, moveSpeed * Time.deltaTime));

        // Calculate the target rotation to face the next node in the path
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, path[0].transform.position - transform.position);
        // Rotate towards the target rotation smoothly using MoveRotation
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, moveSpeed * 100 * Time.deltaTime).eulerAngles.z);
        
        // Calculate the direction and angle to the next node for debugging purposes
        Vector3 directionToNode = path[0].transform.position - transform.position;
        // Calculate the angle to rotate towards the next node and log it for debugging purposes
        float angleToNode = Mathf.Atan2(directionToNode.y, directionToNode.x) * Mathf.Rad2Deg;


        // Rotate to face the next node
        Vector2 direction = (path[0].transform.position - transform.position).normalized;
        if (direction != Vector2.zero)
        {
            // Calculate the angle to rotate towards the next node and apply it to the Rigidbody2D
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }

        // If close enough to the next node, move to the next one in the path
        if (Vector2.Distance(transform.position, path[0].transform.position) < 0.1f)
        {
            // Set the current node to the next one in the path
            currentNode = path[0];
            // Remove the reached node from the path
            path.RemoveAt(0);
        }
    }

    // Generate a new path to a random target node using the A* algorithm
    void GenerateNewPath()
    {
        if (currentNode == null) return;
        // Find all nodes in the scene and select a random target node to generate a new path to
       Node[] nodes = Object.FindObjectsOfType<Node>();

        // Log the number of nodes found and the current node for debugging purposes
        Debug.Log(gameObject.name + " found " + nodes.Length + " nodes. Current node: " + currentNode.name);
        
        if (nodes.Length > 0)
        {
            // Select a random target node from the list of nodes
            Node randomTarget = nodes[Random.Range(0, nodes.Length)];

            // If the random target is the same as the current node, do not generate a path and return
            if (randomTarget == currentNode) return;

            // Generate a new path from the current node to the random target node using the A* algorithm
            path = AStarManager.instance.GeneratePath(currentNode, randomTarget);

            // Log the generated path for debugging purposes
            if (path == null || path.Count == 0)
            {
                Debug.LogWarning("Path not found!");
            }
        }
    }

    Node GetClosestNode()
    {
        // Find all nodes in the scene and determine which one is closest to the NPC's current position
        Node[] nodes = Object.FindObjectsOfType<Node>();
        // Log the number of nodes found for debugging purposes
        Node closest = null;
        // Iterate through all nodes to find the one closest to the NPC's current position
        float minDist = Mathf.Infinity;

        // Log the current position of the NPC for debugging purposes
        foreach (Node node in nodes)
        {
            // Calculate the distance from the NPC to the current node and check if it's the closest one found so far
            float dist = Vector3.Distance(transform.position, node.transform.position);
            // Log the distance to the current node for debugging purposes
            if (dist < minDist)
            {
                minDist = dist;
                closest = node;
            }
        }
     
    // Log the closest node found for debugging purposes
    return closest;
    }
}