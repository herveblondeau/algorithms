// https://www.codingame.com/training/hard/chess-cavalry

using System.Collections.Generic;
using System.Linq;

namespace Codingame.ChessCavalry
{
    public class ChessCavalry
    {
        private Dictionary<(int, int), int> _visited = new();
        private Queue<(int, int)> _toProcess = new();
        private static (int, int)[] _allowedMoves = new (int, int)[8]
        {
            (-1, 2),
            (1, 2),
            (-2, 1),
            (2, 1),
            (-2, -1),
            (2, -1),
            (-1, -2),
            (1, -2),
        };

        // This is basically a BFS algorithm
        public int GetDistance(int width, int height, (int, int) start, (int, int) target, (int, int)[] obstacles)
        {
            if (start == target)
            {
                return 0;
            }

            _visited.Add(start, 0);
            _toProcess.Enqueue(start);
            (int, int) current;
            (int, int) next;
            int distance;
            while (_toProcess.Any())
            {
                current = _toProcess.Dequeue();
                distance = _visited[current] + 1;

                // Try all possible and non already visited moves
                // If a move leads to the target, immediately return the corresponding distance. Otherwise, add that position to the queue if it hasn't already been visited
                foreach (var move in _allowedMoves)
                {
                    next = (current.Item1 + move.Item1, current.Item2 + move.Item2);
                    if (IsValid(next, width, height, obstacles) && !IsVisited(next))
                    {
                        if (next == target)
                        {
                            return distance;
                        }
                        _toProcess.Enqueue(next);
                        _visited.Add(next, distance);
                    }
                }

            }

            return -1;
        }

        private bool IsValid((int, int) position, int width, int height, (int, int)[] obstacles)
        {
            return position.Item1 >= 0
                && position.Item2 >= 0
                && position.Item1 < width
                && position.Item2 < height
                && !obstacles.Contains(position);
        }

        private bool IsVisited((int, int) position)
        {
            return _visited.ContainsKey(position);
        }
    }
}
