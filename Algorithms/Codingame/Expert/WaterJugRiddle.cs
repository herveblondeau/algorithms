// https://www.codingame.com/training/expert/the-water-jug-riddle-from-die-hard-3
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Expert.WaterJugRiddle;

public class WaterJugRiddle
{

    private Dictionary<Position, int> _visited = new();
    private Queue<Position> _positionsToProcess = new();

    public int GetDistance(int[] capacities, int target)
    {
        if (target == 0)
        {
            return 0;
        }

        // Initial position
        int[] quantities = capacities.Select(c => 0).ToArray();
        Position current = new(capacities, quantities);
        _visited.Add(current, 0);

        // This is essentially a BFS algorithm
        // On top of the Codingame requirements, it also handles impossible cases (for instance, trying to reach a quantity above the highest capacity)
        int distance = 0;
        Position next;
        while (current != null)
        {
            distance++;

            // For each jug, try all possible moves
            // If a move leads to the target, immediately return the corresponding distance. Otherwise, add that position to the queue if it hasn't already been visited
            for (int i = 0; i < capacities.Length; i++)
            {
                // Fill
                next = current.Fill(i);
                if (!IsVisited(next))
                {
                    if (next.Contains(target))
                    {
                        return distance;
                    }
                    _visited.Add(next, distance);
                    _positionsToProcess.Enqueue(next);
                }

                // Empty
                next = current.Empty(i);
                if (!IsVisited(next))
                {
                    if (next.Contains(target))
                    {
                        return distance;
                    }
                    _visited.Add(next, distance);
                    _positionsToProcess.Enqueue(next);
                }

                // Pour into other jar
                for (int j = 0; j < capacities.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    next = current.Pour(i, j);
                    if (!IsVisited(next))
                    {
                        if (next.Contains(target))
                        {
                            return distance;
                        }
                        _visited.Add(next, distance);
                        _positionsToProcess.Enqueue(next);
                    }
                }
            }

            current = _positionsToProcess.Any() ? _positionsToProcess.Dequeue() : null;
            distance = current != null ? _visited[current] : -1;
        }

        return distance;
    }

    private bool IsVisited(Position p)
    {
        return _visited.ContainsKey(p);
    }

    // A Position object represents a complete state of the jugs and is immutable
    private class Position
    {
        public int[] Capacities{ get; set; }
        public int[] Quantities { get; set; }

        public Position(int[] capacities, int[] quantities)
        {
            Capacities = new int[capacities.Length];
            capacities.CopyTo(Capacities, 0);
            Quantities = new int[quantities.Length];
            quantities.CopyTo(Quantities, 0);
        }

        // Returns the position after emptying a given jug
        public Position Empty(int n)
        {
            Position p = new(Capacities, Quantities);
            p.Quantities[n] = 0;
            return p;
        }

        // Returns the position after filling a given jug
        public Position Fill(int n)
        {
            Position p = new(Capacities, Quantities);
            p.Quantities[n] = Capacities[n];
            return p;
        }

        // Returns the position after pouring the contents of a given jug into another
        public Position Pour(int source, int target)
        {
            Position p = new(Capacities, Quantities);
            int delta = Math.Min(Quantities[source], Capacities[target] - Quantities[target]);
            p.Quantities[source] -= delta;
            p.Quantities[target] += delta;
            return p;
        }

        // Checks whether one of the jugs contains the given amount
        public bool Contains(int goal)
        {
            return Quantities.Contains(goal);
        }

        // These two methods are implemented for position comparison purposes
        public override int GetHashCode()
        {
            return string.Join('-', Quantities).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == ((Position)obj).GetHashCode();
        }
    }
}
