using System;
using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day6GuardGallivant
{
    public int CalculateNbPositionsBeforeExiting(string[] map)
    {
        (int row, int column, char direction) = _findGuard(map);
        HashSet<(int, int)> visited = [(row, column)];

        int nbPositionsBeforeExiting = 1;
        while (true)
        {
            char next = _getNext(map, row, column, direction);

            if (next == 'X')
            {
                return nbPositionsBeforeExiting;
            }
            else if (next == '.' || next == '^')
            {
                (row, column) = _move(row, column, direction);
                if (!visited.Contains((row, column)))
                {
                    visited.Add((row, column));
                    nbPositionsBeforeExiting++;
                }
            }
            else
            {
                direction = _turn(direction);
            }
        }
    }

    private (int, int, char) _findGuard(string[] map)
    {
        for (int row = 0; row < map.Length; row++)
        {
            for (int column = 0; column < map[row].Length; column++)
            {
                // In the sample and the test, the initial direction is always up. We would adapt this part if other initial directions were allowed.
                if (map[row][column] == '^')
                {
                    return (row, column, 'U');
                }
            }
        }

        throw new ArgumentException("Guard not found");
    }

    private char _getNext(string[] map, int row, int column, char direction)
    {
        int width = map[0].Length;
        int height = map.Length;

        switch (direction)
        {
            case 'U':
                if (row == 0)
                {
                    return 'X';
                }
                return map[row - 1][column];

            case 'D':
                if (row == height - 1)
                {
                    return 'X';
                }
                return map[row + 1][column];

            case 'L':
                if (column == 0)
                {
                    return 'X';
                }
                return map[row][column - 1];

            case 'R':
                if (column == width - 1)
                {
                    return 'X';
                }
                return map[row][column + 1];

            default:
                throw new ArgumentException($"Invalid direction {direction}");
        }
    }

    private (int, int) _move (int row, int column, char direction)
    {
        switch (direction)
        {
            case 'U':
                return (row - 1, column);

            case 'D':
                return (row + 1, column);

            case 'L':
                return (row, column - 1);

            case 'R':
                return (row, column + 1);

            default:
                throw new ArgumentException($"Invalid direction {direction}");
        }
    }

    private char _turn (char direction)
    {
        switch (direction)
        {
            case 'U':
                return 'R';

            case 'D':
                return 'L';

            case 'L':
                return 'U';

            case 'R':
                return 'D';

            default:
                throw new ArgumentException($"Invalid direction {direction}");
        }
    }
}
