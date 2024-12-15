// https://adventofcode.com/2024/day/15

using System;

namespace Algorithms.AdventOfCode._2024;

public class Day15WarehouseWoes
{

    #region Part 1

    public int CalculateGpsCoordinatesSum(string[] initialWarehouse, string moves)
    {
        (int X, int Y) robotPosition = default;

        char[][] currentWarehouse = new char[initialWarehouse.Length][];
        for (int row = 0; row < initialWarehouse.Length; row++)
        {
            currentWarehouse[row] = new char[initialWarehouse[row].Length];
            for (int column = 0; column < initialWarehouse[0].Length; column++)
            {
                currentWarehouse[row][column] = initialWarehouse[row][column];
                if (initialWarehouse[row][column] == '@')
                {
                    robotPosition = (row, column);
                    currentWarehouse[row][column] = '.';
                }
            }
        }

        foreach (char move in moves)
        {
            robotPosition = _move(currentWarehouse, robotPosition, move);
        }

        for (int row = 0; row < currentWarehouse.Length; row++)
        {
            for (int column = 0; column < currentWarehouse[0].Length; column++)
            {
                if (robotPosition == (row, column))
                {
                    Console.Write('@');
                }
                else
                {
                    Console.Write(currentWarehouse[row][column]);
                }
            }
            Console.WriteLine();
        }

        return _sumGpsCoordinates(currentWarehouse);
    }

    private (int Row, int Column) _move(char[][] warehouse, (int row, int column) robotPosition, char move)
    {
        switch (move)
        {
            case '^':
                return _moveUp(warehouse, robotPosition);

            case 'v':
                return _moveDown(warehouse, robotPosition);

            case '<':
                return _moveLeft(warehouse, robotPosition);

            case '>':
                return _moveRight(warehouse, robotPosition);

            default:
                throw new ArgumentOutOfRangeException("Unknown move");
        }
    }

    private (int Row, int Column) _moveUp(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        int currentRow = robotPosition.Row - 1;
        (int Row, int Column)? FirstAvailableSlot = null;

        while (currentRow >= 0 && warehouse[currentRow][robotPosition.Column] != '#')
        {
            if (warehouse[currentRow][robotPosition.Column] == '.')
            {
                FirstAvailableSlot = (currentRow, robotPosition.Column);
                break;
            }
            currentRow--;
        }

        if (FirstAvailableSlot is null)
        {
            return robotPosition;
        }

        for (int i = currentRow; i < robotPosition.Row; i++)
        {
            warehouse[i][robotPosition.Column] = warehouse[i + 1][robotPosition.Column];
            warehouse[i + 1][robotPosition.Column] = '.';
        }
        robotPosition = (robotPosition.Row - 1, robotPosition.Column);

        return robotPosition;
    }

    private (int Row, int Column) _moveDown(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        int currentRow = robotPosition.Row + 1;
        (int Row, int Column)? FirstAvailableSlot = null;

        while (currentRow < warehouse.Length && warehouse[currentRow][robotPosition.Column] != '#')
        {
            if (warehouse[currentRow][robotPosition.Column] == '.')
            {
                FirstAvailableSlot = (currentRow, robotPosition.Column);
                break;
            }
            currentRow++;
        }

        if (FirstAvailableSlot is null)
        {
            return robotPosition;
        }

        for (int i = currentRow; i > robotPosition.Row; i--)
        {
            warehouse[i][robotPosition.Column] = warehouse[i - 1][robotPosition.Column];
            warehouse[i - 1][robotPosition.Column] = '.';
        }
        robotPosition = (robotPosition.Row + 1, robotPosition.Column);

        return robotPosition;
    }

    private (int Row, int Column) _moveLeft(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        int currentColumn = robotPosition.Column - 1;
        (int Row, int Column)? FirstAvailableSlot = null;

        while (currentColumn >= 0 && warehouse[robotPosition.Row][currentColumn] != '#')
        {
            if (warehouse[robotPosition.Row][currentColumn] == '.')
            {
                FirstAvailableSlot = (robotPosition.Row, currentColumn);
                break;
            }
            currentColumn--;
        }

        if (FirstAvailableSlot is null)
        {
            return robotPosition;
        }

        for (int i = currentColumn; i < robotPosition.Column; i++)
        {
            warehouse[robotPosition.Row][i] = warehouse[robotPosition.Row][i + 1];
            warehouse[robotPosition.Row][i + 1] = '.';
        }
        robotPosition = (robotPosition.Row, robotPosition.Column - 1);

        return robotPosition;
    }

    private (int Row, int Column) _moveRight(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        int currentColumn = robotPosition.Column + 1;
        (int Row, int Column)? FirstAvailableSlot = null;

        while (currentColumn < warehouse[0].Length && warehouse[robotPosition.Row][currentColumn] != '#')
        {
            if (warehouse[robotPosition.Row][currentColumn] == '.')
            {
                FirstAvailableSlot = (robotPosition.Row, currentColumn);
                break;
            }
            currentColumn++;
        }

        if (FirstAvailableSlot is null)
        {
            return robotPosition;
        }

        for (int i = currentColumn; i > robotPosition.Column; i--)
        {
            warehouse[robotPosition.Row][i] = warehouse[robotPosition.Row][i - 1];
            warehouse[robotPosition.Row][i - 1] = '.';
        }
        robotPosition = (robotPosition.Row, robotPosition.Column + 1);

        return robotPosition;
    }

    private int _sumGpsCoordinates(char[][] warehouse)
    {
        int sum = 0;

        for (int row = 0; row < warehouse.Length; row++)
        {
            for (int column = 0; column < warehouse[0].Length; column++)
            {
                if (warehouse[row][column] == 'O')
                {
                    sum = sum + 100 * row + column;
                }
            }
        }

        return sum;
    }

    #endregion
}
