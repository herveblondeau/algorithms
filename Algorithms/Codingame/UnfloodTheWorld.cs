// 

namespace Codingame.UnfloodTheWorld
{
    public class UnfloodTheWorld
    {
        public int GetNumberOfDrains(int[,] map)
        {
            int nbDrains = 0;
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }

                    if (!_isAreaLowestInItsNeighborhood(i, j, map[i, j], map, visited))
                    {
                        continue;
                    }

                    nbDrains++;
                }
            }

            return nbDrains;
        }

        // Recursively visit all adjacent squares of the given starting position
        // - if a square has the same height as the initial square (base height), it is marked as visited, so that the whole area of the same height is mapped
        // - otherwise, the exploration stops but we compare the square height with the base height
        // Returns true if the area is the lowest in its neighborhood
        private bool _isAreaLowestInItsNeighborhood(int x, int y, int baseHeight, int[,] map, bool[,] visited)
        {
            // Out of map
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1))
            {
                return true;
            }

            // Already visited
            if ((visited[x, y] && map[x, y] == baseHeight))
            {
                return true;
            }

            // Square of a different height
            if (map[x, y] != baseHeight)
            {
                return map[x, y] > baseHeight;
            }

            // At this point, we know we are on a square of the specified height that hasn't been visited yet
            // Mark the current square as visited
            visited[x, y] = true;

            // Visit its neighbors
            // We need to store the results in variables before making the final test with the && operator, otherwise the first method returning false would prevent the other neighbors from being visited
            bool above = _isAreaLowestInItsNeighborhood(x - 1, y, baseHeight, map, visited);
            bool below = _isAreaLowestInItsNeighborhood(x + 1, y, baseHeight, map, visited);
            bool left  = _isAreaLowestInItsNeighborhood(x, y - 1, baseHeight, map, visited);
            bool right = _isAreaLowestInItsNeighborhood(x, y + 1, baseHeight, map, visited);

            return above && below && left && right;

        }
    }
}
