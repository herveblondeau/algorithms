using System.Collections.Generic;
using System.Linq;

namespace CrackingTheCodeInterview.TreesAndGraphs.RouteBetweenNodes;

// Source: "Cracking the coding interview" book (4.1 - Route between nodes)
public class RouteBetweenNodes
{
    public static bool AreConnected(Node start, Node end)
    {
        if (start.Equals(end))
        {
            return true;
        }

        // This is basically a breadth-first search
        Queue<Node> toVisit = new();

        Node current;

        toVisit.Enqueue(start);
        while (toVisit.Count > 0)
        {
            current = toVisit.Dequeue();
            foreach (Node neighbor in current.Neighbors.Where(n => !n.IsVisited))
            {
                if (neighbor.Equals(end))
                {
                    return true;
                }
                toVisit.Enqueue(neighbor);
            }
            current.IsVisited = true;
        }

        return false;
    }
}

// Basic graph/node implementation for the purpose of the problem
public class Graph
{
    public Node[] Nodes { get; set; }
}

public class Node
{
    public int Id { get; private set; }

    public bool IsVisited { get; set; }

    public List<Node> Neighbors { get; set; }

    public Node(int id)
    {
        Id = id;
        Neighbors = new List<Node>();
    }

    public void ConnectTo(Node node)
    {
        Neighbors.Add(node);
    }

    public override bool Equals(object obj)
    {
        return Id == ((Node)obj).Id;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}
