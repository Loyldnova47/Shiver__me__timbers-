using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public Node cameFrom;
    public List<Node> connections;

    public float gScore;
    public float hScore;

    public float FScore
    {
        get
        {
            return gScore + hScore;
        }
    }
   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Node node in connections)
        {
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}
