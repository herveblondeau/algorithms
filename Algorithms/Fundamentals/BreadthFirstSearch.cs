using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.BreadthFirstSearch;

public class BreadthFirstSearch<T> where T : IEquatable<T>
{
    public bool HasPath(Dictionary<T, List<T>> graph, T from, T to)
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

            if (graph.ContainsKey(node))
            {
                foreach (var neighbor in graph[node].Where(n => !visited.Contains(n)))
                {
                    queue.Enqueue(neighbor);
                }
            }

            visited.Add(node);
            queue.TryDequeue(out node);
        }

        return false;
    }
}
