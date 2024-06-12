using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.Dijkstra;

public class Dijkstra<T> where T : IEquatable<T>
{
    public List<T>? GetShortestPath(Dictionary<T, List<T>> graph, T from, T to)
    {
        // Exit conditions
        if (from is null)
        {
            return null;
        }

        if (from.Equals(to))
        {
            return [from];
        }

        // Initialization
        Dictionary<T, int> costs = new();
        foreach (var n in graph.Keys)
        {
            costs[n] = int.MaxValue;
        }
        Dictionary<T, T?> parents = new();
        HashSet<T> processed = new();

        foreach (var neighbor in graph[from])
        {
            costs[neighbor] = 1;
            parents[neighbor] = from;
        }
        costs[from] = 0;
        parents[from] = default;
        processed.Add(from);

        // Processing
        T? closestUnprocessedNode = _getClosestUnprocessedNode(graph, costs, processed);
        while (closestUnprocessedNode is not null)
        {
            foreach (var neighbor in graph[closestUnprocessedNode])
            {
                var newNeighborCost = costs[closestUnprocessedNode] + 1;
                if (newNeighborCost < costs[neighbor])
                {
                    costs[neighbor] = newNeighborCost;
                    parents[neighbor] = closestUnprocessedNode;
                }
            }

            processed.Add(closestUnprocessedNode);
            closestUnprocessedNode = _getClosestUnprocessedNode(graph, costs, processed);
        }

        // Return path
        List<T> path = new();
        T? node = to;
        while (node is not null)
        {
            path.Insert(0, node);
            node = parents.ContainsKey(node) ? parents[node] : default;
        }
        return path;
    }

    private T? _getClosestUnprocessedNode(Dictionary<T, List<T>> graph, Dictionary<T, int> costs, HashSet<T> processed)
    {
        int lowestCost = int.MaxValue;
        T? lowestCostNode = default;
        foreach (var node in graph.Keys.Where(n => !processed.Contains(n)))
        {
            if (costs[node] < lowestCost)
            {
                lowestCostNode = node;
                lowestCost = costs[node];
            }
        }

        return lowestCostNode;
    }
}
