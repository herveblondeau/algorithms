// https://www.codingame.com/training/hard/the-hungry-duck---part-1
// https://www.codingame.com/training/hard/the-hungry-duck---part-2
using System;

namespace Codingame.Hard.HungryDuck;

public class HungryDuck
{

    // O(nm) time and space
    public int GetMaximumFoodAmount(int[][] foods)
    {
        int height = foods.Length;
        int width = foods[0].Length;

        // Create another array to store the maximums
        int[][] maximums = new int[height][];
        for (int i = 0; i < height; i++)
        {
            maximums[i] = new int[width];
            for (int j = 0; j < width; j++)
            {
                maximums[i][j] = -1;
            }
        }

        // Fill the first row and column, which give the maximum food amounts that the duck can eat when going only right or only down
        maximums[0][0] = foods[0][0];
        if (height > 1)
        {
            for (int i = 1; i < height; i++)
            {
                maximums[i][0] = maximums[i - 1][0] + foods[i][0];
            }
        }
        if (width > 1)
        {
            for (int i = 1; i < width; i++)
            {
                maximums[0][i] = maximums[0][i - 1] + foods[0][i];
            }
        }

        // Compute the other maximum amounts
        // Each cell can be reached from the left or the top, so the maximum possible total is obtained by comparing these two cells
        for (int i = 1; i < width; i++)
        {
            for (int j = 1; j < height; j++)
            {
                maximums[j][i] = Math.Max(maximums[j][i - 1], maximums[j-1][i]) + foods[j][i];
            }
        }

        // The requested distance is in the bottom right cell
        return maximums[height - 1][width - 1];
    }
}