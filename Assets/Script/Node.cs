using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int G;
    public int H;
    public int F => G + H;
    public Node previous;
    public bool blocked;

    public static Node startNode;
    public static Node endNode;

    PathFind path;
    private void Start()
    {
        path = new PathFind();
    }
    private void OnMouseDown()
    {
        if (startNode == null)
        {
            startNode = this;
        }
        else if (startNode != null && endNode == null)
        {
            endNode = this;
            var nodes = path.Pathfinding(startNode, endNode);
        }
    }

    private void OnMouseEnter()
    {

    }

}
