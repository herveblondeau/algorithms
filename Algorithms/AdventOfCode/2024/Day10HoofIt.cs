// https://adventofcode.com/2024/day/10

using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day10HoofIt
{
    #region Part 1

    public long CalculateSumOfScores(int[][] map)
    {
        int width = map[0].Length;
        int height = map.Length;

        int sum = 0;
        for (byte i = 0; i < height; i++)
        {
            for (byte j = 0; j < width; j++)
            {
                var reachableNines = _findReachableNines(i, j, 0, map);
                sum += reachableNines.Count;
            }
        }

        return sum;
    }

    private HashSet<(int Row, int Column)> _findReachableNines(int row, int column, int expectedValue, int[][] map)
    {
        if (row < 0 || row >= map.Length | column < 0 || column >= map[0].Length)
        {
            return new();
        }

        if (map[row][column] != expectedValue)
        {
            return new();
        }

        HashSet<(int Row, int Column)> reachableNines = new();
        if (expectedValue == 9)
        {
            reachableNines.Add((row, column));
        }
        else
        {
            _addNines(reachableNines, _findReachableNines(row - 1, column, expectedValue + 1, map));
            _addNines(reachableNines, _findReachableNines(row + 1, column, expectedValue + 1, map));
            _addNines(reachableNines, _findReachableNines(row, column - 1, expectedValue + 1, map));
            _addNines(reachableNines, _findReachableNines(row, column + 1, expectedValue + 1, map));
        }

        return reachableNines;
    }

    private void _addNines(HashSet<(int Row, int Column)> source, HashSet<(int Row, int Column)> newNines)
    {
        foreach (var nine in newNines)
        {
            source.Add(nine);
        }
    }

    #endregion

    #region Part 2

    public long CalculateSumOfRatings(int[][] map)
    {
        int width = map[0].Length;
        int height = map.Length;

        int sum = 0;
        for (byte i = 0; i < height; i++)
        {
            for (byte j = 0; j < width; j++)
            {
                sum += _calculateRating(i, j, 0, map);
            }
        }

        return sum;
    }

    private int _calculateRating(int row, int column, int expectedValue, int[][] map)
    {
        if (row < 0 || row >= map.Length | column < 0 || column >= map[0].Length)
        {
            return 0;
        }

        if (map[row][column] != expectedValue)
        {
            return 0;
        }

        if (expectedValue == 9)
        {
            return 1;
        }

        return _calculateRating(row - 1, column, expectedValue + 1, map)
            + _calculateRating(row + 1, column, expectedValue + 1, map)
            + _calculateRating(row, column - 1, expectedValue + 1, map)
            + _calculateRating(row, column + 1, expectedValue + 1, map);
    }

    #endregion
}
