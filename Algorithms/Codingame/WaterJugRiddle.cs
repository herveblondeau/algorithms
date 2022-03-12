// https://www.codingame.com/training/expert/the-water-jug-riddle-from-die-hard-3
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.WaterJugRiddle
{
    public class WaterJugRiddle
    {

        Dictionary<Position, int> _positionDistances = new Dictionary<Position, int>();
        Queue<Position> _positionsToProcess = new Queue<Position>();

        public int GetDistance(int[] capacities, int goal)
        {
            // Initial position
            int[] quantities = capacities.Select(c => 0).ToArray();
            Position current = new Position(capacities, quantities);
            _positionDistances.Add(current, 0);

            int distance = 0;
            Position next;
            while (true)
            {
                distance++;

                // Add all reachable positions that haven't already been visited to the queue
                for (int i = 0; i < capacities.Length; i++)
                {
                    // Fill
                    next = current.Fill(i);
                    if (!IsVisited(next))
                    {
                        if (next.HasReached(goal))
                        {
                            return distance;
                        }
                        _positionDistances.Add(next, distance);
                        _positionsToProcess.Enqueue(next);
                    }

                    // Empty
                    next = current.Empty(i);
                    if (!IsVisited(next))
                    {
                        if (next.HasReached(goal))
                        {
                            return distance;
                        }
                        _positionDistances.Add(next, distance);
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
                            if (next.HasReached(goal))
                            {
                                return distance;
                            }
                            _positionDistances.Add(next, distance);
                            _positionsToProcess.Enqueue(next);
                        }
                    }
                }

                current = _positionsToProcess.Dequeue();
                distance = _positionDistances[current];
            }
        }

        private bool IsVisited(Position p)
        {
            return _positionDistances.ContainsKey(p);
        }

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

            public Position Empty(int n)
            {
                Position p = new Position(Capacities, Quantities);
                p.Quantities[n] = 0;
                return p;
            }

            public Position Fill(int n)
            {
                Position p = new Position(Capacities, Quantities);
                p.Quantities[n] = Capacities[n];
                return p;
            }

            public Position Pour(int source, int target)
            {
                Position p = new Position(Capacities, Quantities);
                int delta = Math.Min(Quantities[source], Capacities[target] - Quantities[target]);
                p.Quantities[source] -= delta;
                p.Quantities[target] += delta;
                return p;
            }

            public bool HasReached(int goal)
            {
                return Quantities.Contains(goal);
            }

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
}
