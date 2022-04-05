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

                    if (!_processArea(i, j, map, visited, map[i, j]))
                    {
                        continue;
                    }

                    nbDrains++;
                }
            }

            return nbDrains;
        }

        // Returns true if the area is the lowest in its neighborhood
        private bool _processArea(int x, int y, int[,] map, bool[,] visited, int height)
        {
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1) || (visited[x, y] && map[x, y] == height))
            {
                return true;
            }

            if (map[x, y] < height)
            {
                return false;
            }
            else if (map[x, y] == height)
            {
                visited[x, y] = true;
            }
            else
            {
                return true;
            }

            // We need to store the results in variables, otherwise the first method returning false would prevent the other ones from being run
            bool b1 = _processArea(x - 1, y, map, visited, height);
            bool b2 = _processArea(x + 1, y, map, visited, height);
            bool b3 = _processArea(x, y - 1, map, visited, height);
            bool b4 = _processArea(x, y + 1, map, visited, height);

            return b1 && b2 && b3 && b4;

        }
    }
}
