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
}
