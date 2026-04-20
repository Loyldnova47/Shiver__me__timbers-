    using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarManager : MonoBehaviour
{
    // Singleton instance of the AStarManager to allow global access to pathfinding functionality
    public static AStarManager instance;
    // List to hold all nodes in the scene for pathfinding purposes
    public List<Node> nodes = new List<Node>();
    // Ensure that there is only one instance of the AStarManager in the scene and provide a global access point to it
    private void Awake () 

    {
        // If there is no existing instance of the AStarManager, set this instance as the singleton instance; otherwise, if an instance already exists, log a warning to indicate that multiple instances are not allowed
        if (instance == null)
        {
            // Set this instance as the singleton instance of the AStarManager to allow global access to pathfinding functionality
            instance = this;
        }
    }
        // Generate a path from the start node to the end node using the A* algorithm and return it as a list of nodes
        public List<Node> GeneratePath(Node start, Node end)
    {
        // List to keep track of nodes that are yet to be evaluated in the A* algorithm
        List<Node> openSet = new List<Node>();

        // Initialize all nodes in the scene by setting their gScore to infinity, calculating their hScore as the distance to the end node, and clearing their cameFrom reference
       foreach (Node node in Object.FindObjectsByType<Node>(FindObjectsSortMode.None))

        {
            // The gScore represents the cost from the start node to the current node, and is initialized to infinity for all nodes except the start node
            node.gScore = Mathf.Infinity;
            // The hScore is calculated as the straight-line distance from the node to the end node, which serves as a heuristic for estimating the cost to reach the goal
            node.hScore = Vector3.Distance(node.transform.position, end.transform.position);
            // Clear the cameFrom reference for all nodes to ensure a fresh pathfinding calculation
            node.cameFrom = null;
        }
        // The gScore for the start node is set to 0 since it is the starting point of the path, and the start node is added to the open set to begin the A* algorithm
        start.gScore = 0;
        openSet.Add(start);

        // The main loop of the A* algorithm continues until there are no more nodes to evaluate in the open set
        while (openSet.Count > 0)
        {
            // Find the node in the open set with the lowest fScore (gScore + hScore) to evaluate next
            Node currentNode = openSet[0];
            foreach (Node node in openSet)
            {
                // The fScore is calculated as the sum of gScore and hScore, and the node with the lowest fScore is selected as the current node for evaluation
                if (node.FScore < currentNode.FScore)
                {
                    currentNode = node;
                }
            }

            // If the current node is the end node, a path has been found and the path is reconstructed by tracing back through the cameFrom references from the end node to the start node
            if (currentNode == end)
            {
                // Reconstruct the path by tracing back through the cameFrom references from the end node to the start node and return it as a list of nodes
                List<Node> path = new List<Node>();
                while (currentNode != null)
                {
                    // Add the current node to the path and move to the next node in the path by following the cameFrom reference until reaching the start node (which has a null cameFrom)
                    path.Add(currentNode);
                    currentNode = currentNode.cameFrom;
                }
                // Reverse the path to get the correct order from start to end and return it as a list of nodes
                path.Reverse();
                return path;
            }
            //prevents infinite loop 
            openSet.Remove(currentNode);

            // Iterate through each of the current node's connected nodes (neighbors) and calculate a tentative gScore for each neighbor based on the distance from the start node to the neighbor through the current node
            foreach (Node connectedNode in currentNode.connections)
            {
                // The tentative gScore is calculated as the gScore of the current node plus the distance from the current node to the connected node. If this tentative gScore is less than the existing gScore of the connected node, it means a more efficient path to that neighbor has been found through the current node, and the cameFrom reference for that neighbor is updated to point to the current node, its gScore is updated to the new lower value, and if it is not already in the open set, it is added to be evaluated in future iterations of the A* algorithm
                float tentativeGScore = currentNode.gScore + Vector3.Distance(currentNode.transform.position, connectedNode.transform.position);
                // If the tentative gScore is less than the existing gScore of the connected node, it means a more efficient path to that neighbor has been found through the current node, and the cameFrom reference for that neighbor is updated to point to the current node, its gScore is updated to the new lower value, and if it is not already in the open set, it is added to be evaluated in future iterations of the A* algorithm
                if (tentativeGScore < connectedNode.gScore)
                {
                    // Update the cameFrom reference for the connected node to point to the current node, update its gScore to the new lower value, and add it to the open set if it's not already there
                    connectedNode.cameFrom = currentNode;
                    connectedNode.gScore = tentativeGScore;
                    
                    // If the connected node is not already in the open set, add it to be evaluated in future iterations of the A* algorithm
                    if (!openSet.Contains(connectedNode))
                    {
                        // Add the connected node to the open set to be evaluated in future iterations of the A* algorithm
                        openSet.Add(connectedNode);
                    }
                }
            }
        }
        // If the open set is empty and the end node has not been reached, it means there is no path from the start node to the end node, and null is returned to indicate that no path was found
        return null; // Now correctly placed inside the method
    }
}
