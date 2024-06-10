using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.BreadthFirstSearch;

public class BreadthFirstSearch
{
    public bool HasPath<T>(Node<T> from, Node<T> to) where T : IEquatable<T>
    {
        HashSet<Node<T>> visited = new();
        Queue<Node<T>> queue = new();

        var node = from;
        while (node is not null)
        {
            if (node == to)
            {
                return true;
            }

            foreach (var neighbor in node.Destinations.Where(n => !visited.Contains(n)))
            {
                queue.Enqueue(neighbor);
            }

            visited.Add(node);
            queue.TryDequeue(out node);
        }

        return false;
    }
}

public class Node<T> : IEquatable<Node<T>> where T : IEquatable<T>
{
    public T Value { get; set; }
    public List<Node<T>> Destinations { get; set; } = null!;

    public Node(T value)
    {
        Value = value;
        Destinations = new();
    }

    public Node<T> AddNeighbors(List<Node<T>> neighbors)
    {
        Destinations.AddRange(neighbors);
        return this;
    }

    public Node<T> AddNeighbor(Node<T> neighbor)
    {
        Destinations.Add(neighbor);
        return this;
    }

    public bool Equals(Node<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        return Value.Equals(other.Value);
    }
}
