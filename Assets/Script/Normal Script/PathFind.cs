using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind
{
    public List<Node> Pathfinding(Node start, Node end)
    {
        List<Node> search = new List<Node>() { start };
        List<Node> passed = new List<Node>();
        while (search.Count > 0)
        {
            var currentNode = search[0];
            foreach (var n in search)
                if (n.F < currentNode.F || n.F == currentNode.F && n.H < currentNode.H) currentNode = n;
            passed.Add(currentNode);
            search.Remove(currentNode);
            if (currentNode == end)
            {
                return GetFinishedPath(start, end);
            }
            var neighbourNode = Neighbouring(currentNode);
            foreach (var n in neighbourNode)
            {
                if (n.blocked || passed.Contains(n))
                {
                    continue;
                }
                n.G = Distance(n, start);
                n.H = Distance(n, end);
                n.previous = currentNode;
                if (!search.Contains(n))
                {
                    search.Add(n);
                }
            }
        }
        return new List<Node>();
    }

    public List<Node> GetFinishedPath(Node start, Node end)
    {
        List<Node> finishedPath = new List<Node>();
        var current = end;
        while (current != start)
        {
            finishedPath.Add(current);
            current = current.previous;
        }
        finishedPath.Reverse();
        return finishedPath;
    }

    private int Distance(Node n, Node start)
    {
        return Mathf.RoundToInt(Vector2.Distance(n.transform.position, start.transform.position) * 10);
    }

    private List<Node> Neighbouring(Node current)
    {
        var neigbor = new List<Node>();
        var nodes = NodeGenerator.nodes;
        foreach (var n in nodes)
        {
            var neighbourDistance = Mathf.RoundToInt(Vector2.Distance(current.transform.position, n.transform.position) * 10);
            if (neighbourDistance <= 10)
            {
                neigbor.Add(n);
            }
        }
        return neigbor;
    }
}
