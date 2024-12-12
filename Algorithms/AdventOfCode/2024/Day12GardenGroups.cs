// https://adventofcode.com/2024/day/12

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day12GardenGroups
{
    #region Part 1

    public long CalculateTotalPrice(string[] map)
    {
        long totalPrice = 0;

        int width = map[0].Length;
        int height = map.Length;
        HashSet<(int Row, int Column)> visited = new();
        Dictionary<(int Row, int Column), (long Area, long Perimeter)> regions = new();

        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                if (visited.Contains((row, column)))
                {
                    continue;
                }

                regions.Add((row, column), _parseRegion(row, column, map, map[row][column], visited));
            }
        }

        totalPrice = regions.Values.Sum(r => r.Perimeter * r.Area);

        return totalPrice;
    }

    private (long Area, long Perimeter) _parseRegion(int row, int column, string[] map, char expectedValue, HashSet<(int Row, int Column)> visited)
    {
        // Exit conditions
        if (visited.Contains((row, column)))
        {
            return (0, 0);
        }

        int width = map[0].Length;
        int height = map.Length;

        if (row < 0 || row >= height || column < 0 || column >= width)
        {
            return (0, 0);
        }

        if (map[row][column] != expectedValue)
        {
            return (0, 0);
        }

        // Current area and perimeter
        long area = 1;
        long perimeter = 0;
        if (row == 0 || map[row][column] != map[row - 1][column])
        {
            perimeter++;
        }
        if (row == height - 1 || map[row][column] != map[row + 1][column])
        {
            perimeter++;
        }
        if (column == 0 || map[row][column] != map[row][column - 1])
        {
            perimeter++;
        }
        if (column == width - 1 || map[row][column] != map[row][column + 1])
        {
            perimeter++;
        }

        // Mark as visited
        visited.Add((row, column));

        // Recursively calculate area and perimeter for neighbors
        var left = _parseRegion(row, column - 1, map, expectedValue, visited);
        area += left.Area;
        perimeter += left.Perimeter;

        var right = _parseRegion(row, column + 1, map, expectedValue, visited);
        area += right.Area;
        perimeter += right.Perimeter;

        var up = _parseRegion(row - 1, column, map, expectedValue, visited);
        area += up.Area;
        perimeter += up.Perimeter;

        var down = _parseRegion(row + 1, column, map, expectedValue, visited);
        area += down.Area;
        perimeter += down.Perimeter;

        return (area, perimeter);
    }

    #endregion
}
