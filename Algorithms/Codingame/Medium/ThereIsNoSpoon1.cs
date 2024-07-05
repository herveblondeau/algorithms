// https://www.codingame.com/training/medium/there-is-no-spoon-episode-1

using System.Collections.Generic;

namespace Codingame.Medium.ThereIsNoSpoon1;

public class ThereIsNoSpoon1
{
    public List<string> GetNodes(int[,] grid)
    {
        List<string> nodes = new();
        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        // Nested loop to find all nodes
        // Then, for each node, we loop again along both axes to find the nearest right and bottom nodes
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Found a node
                if (grid[x, y] == 1)
                {
                    string node = x + " " + y + " ";

                    // Look for a right node
                    bool rightNodeFound = false;
                    int i = x;
                    while (++i < width)
                    {
                        if (grid[i, y] == 1)
                        {
                            rightNodeFound = true;
                            break;
                        }
                    }
                    if (rightNodeFound)
                    {
                        node += i + " " + y + " ";
                    }
                    else
                    {
                        node += "-1 -1 ";
                    }

                    // Look for a bottom node
                    bool bottomNodeFound = false;
                    int j = y;
                    while (++j < height)
                    {
                        if (grid[x, j] == 1)
                        {
                            bottomNodeFound = true;
                            break;
                        }
                    }
                    if (bottomNodeFound)
                    {
                        node += x + " " + j;
                        nodes.Add(node);
                    }
                    else
                    {
                        node += "-1 -1";
                        nodes.Add(node);
                    }
                }
            }
        }

        return nodes;
    }
}
