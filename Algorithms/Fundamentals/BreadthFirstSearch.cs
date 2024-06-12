using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.BreadthFirstSearch;

public class BreadthFirstSearch<T> where T : IEquatable<T>
{
    public Dictionary<T, List<T>> Graph = null!;

    public BreadthFirstSearch(Dictionary<T, List<T>> graph)
    {
        Graph = graph;
    }

    public bool HasPath(T from, T to)
    {
        HashSet<T> visited = new();
        Queue<T> queue = new();

        var node = from;
        while (node is not null)
        {
            if (node.Equals(to))
            {
                return true;
            }

            if (Graph.ContainsKey(node))
            {
                foreach (var neighbor in Graph[node].Where(n => !visited.Contains(n)))
                {
                    queue.Enqueue(neighbor);
                }
            }

            visited.Add(node);
            queue.TryDequeue(out node);
        }

        return false;
    }

    public List<T> GetShortestPath(T from, T to)
    {
        return new();
    }
}
