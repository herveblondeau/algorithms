// https://adventofcode.com/2024/day/12

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

                regions.Add((row, column), _parseAreaAndPerimeter(row, column, map, map[row][column], visited));
            }
        }

        totalPrice = regions.Values.Sum(r => r.Perimeter * r.Area);

        return totalPrice;
    }

    private (long Area, long Perimeter) _parseAreaAndPerimeter(int row, int column, string[] map, char expectedValue, HashSet<(int Row, int Column)> visited)
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
        var left = _parseAreaAndPerimeter(row, column - 1, map, expectedValue, visited);
        area += left.Area;
        perimeter += left.Perimeter;

        var right = _parseAreaAndPerimeter(row, column + 1, map, expectedValue, visited);
        area += right.Area;
        perimeter += right.Perimeter;

        var up = _parseAreaAndPerimeter(row - 1, column, map, expectedValue, visited);
        area += up.Area;
        perimeter += up.Perimeter;

        var down = _parseAreaAndPerimeter(row + 1, column, map, expectedValue, visited);
        area += down.Area;
        perimeter += down.Perimeter;

        return (area, perimeter);
    }

    #endregion

    #region Part 2

    public long CalculateBulkDiscountPrice(string[] map)
    {
        long totalPrice = 0;

        int width = map[0].Length;
        int height = map.Length;
        HashSet<(int Row, int Column)> visited = new();
        Dictionary<(int Row, int Column), (long Area, long Sides)> regions = new();

        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                if (visited.Contains((row, column)))
                {
                    continue;
                }

                regions.Add((row, column), _parseAreaAndSides(row, column, map, map[row][column], visited));
            }
        }

        totalPrice = regions.Values.Sum(r => r.Sides * r.Area);

        return totalPrice;
    }

    private (long Area, long Sides) _parseAreaAndSides(int row, int column, string[] map, char expectedValue, HashSet<(int Row, int Column)> visited)
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

        // Current area and sides
        // For the sides, we just need to observe that the number of sides of a shape is equal to the number of direction changes when following its path, which is exactly the number of its corners, which is much easier to calculate
        long area = 1;
        long sides = _countCorners(row, column, map);

        // Mark as visited
        visited.Add((row, column));

        // Recursively calculate area and perimeter for neighbors
        var left = _parseAreaAndSides(row, column - 1, map, expectedValue, visited);
        area += left.Area;
        sides += left.Sides;

        var right = _parseAreaAndSides(row, column + 1, map, expectedValue, visited);
        area += right.Area;
        sides += right.Sides;

        var up = _parseAreaAndSides(row - 1, column, map, expectedValue, visited);
        area += up.Area;
        sides += up.Sides;

        var down = _parseAreaAndSides(row + 1, column, map, expectedValue, visited);
        area += down.Area;
        sides += down.Sides;

        return (area, sides);
    }

    private int _countCorners(int row, int column, string[] map)
    {
        int corners = 0;

        // We distinguish two types of corners: outside, which "stick out", and inside, which "retract"
        // The following picture illustrates both cases:
        //  outside--->┌─
        //  outside->┌─┘<-inside
        //  outside->└─┐<-inside

        if (_isOutsideTopLeftCorner(row, column, map)) corners++;
        if (_isOutsideBottomLeftCorner(row, column, map)) corners++;
        if (_isOutsideTopRightCorner(row, column, map)) corners++;
        if (_isOutsideBottomRightCorner(row, column, map)) corners++;
        if (_isInsideTopLeftCorner(row, column, map)) corners++;
        if (_isInsideBottomLeftCorner(row, column, map)) corners++;
        if (_isInsideTopRightCorner(row, column, map)) corners++;
        if (_isInsideBottomRightCorner(row, column, map)) corners++;

        return corners;
    }

    private bool _isOutsideBottomLeftCorner(int row, int column, string[] map)
    {
        var height = map.Length;
        if (row == height - 1 && column == 0)
        {
            return true;
        }
        else if (row == height - 1 && column != 0)
        {
            return map[row][column] != map[row][column - 1];
        }
        else if (row != height - 1 && column == 0)
        {
            return map[row][column] != map[row + 1][column];
        }
        else
        {
            return map[row][column] != map[row][column - 1]
                && map[row][column] != map[row + 1][column];
        }
    }

    private bool _isOutsideBottomRightCorner(int row, int column, string[] map)
    {
        var height = map.Length;
        var width = map[0].Length;
        if (row == height - 1 && column == width - 1)
        {
            return true;
        }
        else if (row == height - 1 && column != width - 1)
        {
            return map[row][column] != map[row][column + 1];
        }
        else if (row != height - 1 && column == width - 1)
        {
            return map[row][column] != map[row + 1][column];
        }
        else
        {
            return map[row][column] != map[row][column + 1]
                && map[row][column] != map[row + 1][column];
        }
    }

    private bool _isOutsideTopLeftCorner(int row, int column, string[] map)
    {
        if (row == 0 && column == 0)
        {
            return true;
        }
        else if (row == 0 && column != 0)
        {
            return map[row][column] != map[row][column - 1];
        }
        else if (row != 0 && column == 0)
        {
            return map[row][column] != map[row - 1][column];
        }
        else
        {
            return map[row][column] != map[row][column - 1]
                && map[row][column] != map[row - 1][column];
        }
    }

    private bool _isOutsideTopRightCorner(int row, int column, string[] map)
    {
        var width = map[0].Length;
        if (row == 0 && column == width - 1)
        {
            return true;
        }
        else if (row == 0 && column != width - 1)
        {
            return map[row][column] != map[row][column + 1];
        }
        else if (row != 0 && column == width - 1)
        {
            return map[row][column] != map[row - 1][column];
        }
        else
        {
            return map[row][column] != map[row][column + 1]
                && map[row][column] != map[row - 1][column];
        }
    }

    private bool _isInsideBottomRightCorner(int row, int column, string[] map)
    {
        var height = map.Length;
        var width = map[0].Length;
        if (row == height - 1 || column == width - 1)
        {
            return false;
        }
        else
        {
            return map[row][column] == map[row + 1][column]
                && map[row][column] == map[row][column + 1]
                && map[row][column] != map[row + 1][column + 1];
        }
    }

    private bool _isInsideTopRightCorner(int row, int column, string[] map)
    {
        var width = map[0].Length;
        if (row == 0 || column == width - 1)
        {
            return false;
        }
        else
        {
            return map[row][column] == map[row - 1][column]
                && map[row][column] == map[row][column + 1]
                && map[row][column] != map[row - 1][column + 1];
        }
    }

    private bool _isInsideBottomLeftCorner(int row, int column, string[] map)
    {
        var height = map.Length;
        if (row == height - 1 || column == 0)
        {
            return false;
        }
        else
        {
            return map[row][column] == map[row + 1][column]
                && map[row][column] == map[row][column - 1]
                && map[row][column] != map[row + 1][column - 1];
        }
    }

    private bool _isInsideTopLeftCorner(int row, int column, string[] map)
    {
        if (row == 0 || column == 0)
        {
            return false;
        }
        else
        {
            return map[row][column] == map[row - 1][column]
                && map[row][column] == map[row][column - 1]
                && map[row][column] != map[row - 1][column - 1];
        }
    }

    #endregion
}
