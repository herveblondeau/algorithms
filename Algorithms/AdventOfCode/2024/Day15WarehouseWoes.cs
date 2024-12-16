// https://adventofcode.com/2024/day/15

using System;
using System.Collections.Generic;

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

        // for (int row = 0; row < currentWarehouse.Length; row++)
        // {
        //     for (int column = 0; column < currentWarehouse[0].Length; column++)
        //     {
        //         if (robotPosition == (row, column))
        //         {
        //             Console.Write('@');
        //         }
        //         else
        //         {
        //             Console.Write(currentWarehouse[row][column]);
        //         }
        //     }
        //     Console.WriteLine();
        // }

        return _sumGpsCoordinates(currentWarehouse);
    }

    #endregion

    #region Part 2

    public int CalculateExtendedGpsCoordinatesSum(string[] initialWarehouse, string moves)
    {
        (int X, int Y) robotPosition = default;

        char[][] extendedWarehouse = new char[initialWarehouse.Length][];
        for (int row = 0; row < initialWarehouse.Length; row++)
        {
            extendedWarehouse[row] = new char[initialWarehouse[row].Length * 2];
            for (int column = 0; column < initialWarehouse[0].Length; column++)
            {
                switch (initialWarehouse[row][column])
                {
                    case '#':
                        extendedWarehouse[row][column * 2] = '#';
                        extendedWarehouse[row][column * 2 + 1] = '#';
                        break;

                    case '.':
                        extendedWarehouse[row][column * 2] = '.';
                        extendedWarehouse[row][column * 2 + 1] = '.';
                        break;

                    case 'O':
                        extendedWarehouse[row][column * 2] = '[';
                        extendedWarehouse[row][column * 2 + 1] = ']';
                        break;

                    case '@':
                        extendedWarehouse[row][column * 2] = '.';
                        extendedWarehouse[row][column * 2 + 1] = '.';
                        robotPosition = (row, column * 2);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Unknown move");
                }
            }
        }

        // for (int row = 0; row < extendedWarehouse.Length; row++)
        // {
        //     for (int column = 0; column < extendedWarehouse[0].Length; column++)
        //     {
        //         if (robotPosition == (row, column))
        //         {
        //             Console.Write('@');
        //         }
        //         else
        //         {
        //             Console.Write(extendedWarehouse[row][column]);
        //         }
        //     }
        //     Console.WriteLine();
        // }
        // Console.WriteLine();

        // int n = 1;
        foreach (char move in moves)
        {
            // Console.WriteLine($"Move {n++}");
            robotPosition = _move(extendedWarehouse, robotPosition, move);
            // for (int row = 0; row < extendedWarehouse.Length; row++)
            // {
            //     for (int column = 0; column < extendedWarehouse[0].Length; column++)
            //     {
            //         if (robotPosition == (row, column))
            //         {
            //             Console.Write('@');
            //         }
            //         else
            //         {
            //             Console.Write(extendedWarehouse[row][column]);
            //         }
            //     }
            //     Console.WriteLine();
            // }
            // Console.WriteLine();
        }

        // for (int row = 0; row < extendedWarehouse.Length; row++)
        // {
        //     for (int column = 0; column < extendedWarehouse[0].Length; column++)
        //     {
        //         if (robotPosition == (row, column))
        //         {
        //             Console.Write('@');
        //         }
        //         else
        //         {
        //             Console.Write(extendedWarehouse[row][column]);
        //         }
        //     }
        //     Console.WriteLine();
        // }

        return _sumGpsCoordinates(extendedWarehouse);
    }

    #endregion

    #region Common

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
        // Wall
        if (robotPosition.Row == 0 || warehouse[robotPosition.Row - 1][robotPosition.Column] == '#')
        {
            return (robotPosition.Row, robotPosition.Column);
        }
        // Empty slot
        if (warehouse[robotPosition.Row - 1][robotPosition.Column] == '.')
        {
            return (robotPosition.Row - 1, robotPosition.Column);
        }

        // Box
        HashSet<(int Row, int Column)> visited = new();
        var warehouseCopy = _copy(warehouse);
        if (_pushUp(warehouseCopy, robotPosition.Row - 1, robotPosition.Column, visited))
        {
            _copyValues(warehouseCopy, warehouse);
            return (robotPosition.Row - 1, robotPosition.Column);
        }
        else
        {
            return (robotPosition.Row, robotPosition.Column);
        }
    }

    private bool _pushUp(char[][] warehouse, int row, int column, HashSet<(int Row, int Column)> visited)
    {
        // Wall
        if (row == 0 || warehouse[row - 1][column] == '#')
        {
            return false;
        }

        if (visited.Contains((row, column)))
        {
            return true;
        }
        visited.Add((row, column));

        // Large box
        if (warehouse[row][column] == '[')
        {
            if (!_pushUp(warehouse, row, column + 1, visited))
            {
                return false;
            }
        }
        else if (warehouse[row][column] == ']')
        {
            if (!_pushUp(warehouse, row, column - 1, visited))
            {
                return false;
            }
        }

        // Empty slot
        if (warehouse[row - 1][column] == '.')
        {
            warehouse[row - 1][column] = warehouse[row][column];
            warehouse[row][column] = '.';
            return true;
        }

        // Box
        if (!_pushUp(warehouse, row - 1, column, visited))
        {
            return false;
        }

        warehouse[row - 1][column] = warehouse[row][column];
        warehouse[row][column] = '.';
        return true;
    }

    private (int Row, int Column) _moveDown(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        // Wall
        if (robotPosition.Row == warehouse.Length - 1 || warehouse[robotPosition.Row + 1][robotPosition.Column] == '#')
        {
            return (robotPosition.Row, robotPosition.Column);
        }
        // Empty slot
        if (warehouse[robotPosition.Row + 1][robotPosition.Column] == '.')
        {
            return (robotPosition.Row + 1, robotPosition.Column);
        }

        // Box
        HashSet<(int Row, int Column)> visited = new();
        var warehouseCopy = _copy(warehouse);
        if (_pushDown(warehouseCopy, robotPosition.Row + 1, robotPosition.Column, visited))
        {
            _copyValues(warehouseCopy, warehouse);
            return (robotPosition.Row + 1, robotPosition.Column);
        }
        else
        {
            return (robotPosition.Row, robotPosition.Column);
        }
    }

    private bool _pushDown(char[][] warehouse, int row, int column, HashSet<(int Row, int Column)> visited)
    {
        // Wall
        if (row == 0 || warehouse[row + 1][column] == '#')
        {
            return false;
        }

        if (visited.Contains((row, column)))
        {
            return true;
        }
        visited.Add((row, column));

        // Large box
        if (warehouse[row][column] == '[')
        {
            if (!_pushDown(warehouse, row, column + 1, visited))
            {
                return false;
            }
        }
        else if (warehouse[row][column] == ']')
        {
            if (!_pushDown(warehouse, row, column - 1, visited))
            {
                return false;
            }
        }

        // Empty slot
        if (warehouse[row + 1][column] == '.')
        {
            warehouse[row + 1][column] = warehouse[row][column];
            warehouse[row][column] = '.';
            return true;
        }

        // Box
        if (!_pushDown(warehouse, row + 1, column, visited))
        {
            return false;
        }

        warehouse[row + 1][column] = warehouse[row][column];
        warehouse[row][column] = '.';
        return true;
    }

    private (int Row, int Column) _moveLeft(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        // Wall
        if (robotPosition.Column == 0 || warehouse[robotPosition.Row][robotPosition.Column - 1] == '#')
        {
            return (robotPosition.Row, robotPosition.Column);
        }
        // Empty slot
        if (warehouse[robotPosition.Row][robotPosition.Column - 1] == '.')
        {
            return (robotPosition.Row, robotPosition.Column - 1);
        }

        // Box
        HashSet<(int Row, int Column)> visited = new();
        var warehouseCopy = _copy(warehouse);
        if (_pushLeft(warehouseCopy, robotPosition.Row, robotPosition.Column - 1, visited))
        {
            _copyValues(warehouseCopy, warehouse);
            return (robotPosition.Row, robotPosition.Column - 1);
        }
        else
        {
            return (robotPosition.Row, robotPosition.Column);
        }
    }

    private bool _pushLeft(char[][] warehouse, int row, int column, HashSet<(int Row, int Column)> visited)
    {
        // Wall
        if (row == 0 || warehouse[row][column - 1] == '#')
        {
            return false;
        }

        if (visited.Contains((row, column)))
        {
            return true;
        }
        visited.Add((row, column));

        // Empty slot
        if (warehouse[row][column - 1] == '.')
        {
            warehouse[row][column - 1] = warehouse[row][column];
            warehouse[row][column] = '.';
            return true;
        }

        // Box
        if (!_pushLeft(warehouse, row, column - 1, visited))
        {
            return false;
        }

        warehouse[row][column - 1] = warehouse[row][column];
        warehouse[row][column] = '.';
        return true;
    }

    private (int Row, int Column) _moveRight(char[][] warehouse, (int Row, int Column) robotPosition)
    {
        // Wall
        if (robotPosition.Column == warehouse[0].Length - 1 || warehouse[robotPosition.Row][robotPosition.Column + 1] == '#')
        {
            return (robotPosition.Row, robotPosition.Column);
        }
        // Empty slot
        if (warehouse[robotPosition.Row][robotPosition.Column + 1] == '.')
        {
            return (robotPosition.Row, robotPosition.Column + 1);
        }

        // Box
        HashSet<(int Row, int Column)> visited = new();
        var warehouseCopy = _copy(warehouse);
        if (_pushRight(warehouseCopy, robotPosition.Row, robotPosition.Column + 1, visited))
        {
            _copyValues(warehouseCopy, warehouse);
            return (robotPosition.Row, robotPosition.Column + 1);
        }
        else
        {
            return (robotPosition.Row, robotPosition.Column);
        }
    }

    private bool _pushRight(char[][] warehouse, int row, int column, HashSet<(int Row, int Column)> visited)
    {
        // Wall
        if (row == 0 || warehouse[row][column + 1] == '#')
        {
            return false;
        }

        if (visited.Contains((row, column)))
        {
            return true;
        }
        visited.Add((row, column));

        // Empty slot
        if (warehouse[row][column + 1] == '.')
        {
            warehouse[row][column + 1] = warehouse[row][column];
            warehouse[row][column] = '.';
            return true;
        }

        // Box
        if (!_pushRight(warehouse, row, column + 1, visited))
        {
            return false;
        }

        warehouse[row][column + 1] = warehouse[row][column];
        warehouse[row][column] = '.';
        return true;
    }

    private char[][] _copy(char[][] warehouse)
    {
        char[][] copy = new char[warehouse.Length][];
        for (int row = 0; row < warehouse.Length; row++)
        {
            copy[row] = new char[warehouse[row].Length];
            for (int column = 0; column < warehouse[0].Length; column++)
            {
                copy[row][column] = warehouse[row][column];
            }
        }
        return copy;
    }

    private void _copyValues(char[][] source, char[][] target)
    {
        for (int row = 0; row < source.Length; row++)
        {
            for (int column = 0; column < source[0].Length; column++)
            {
                target[row][column] = source[row][column];
            }
        }
    }

    private int _sumGpsCoordinates(char[][] warehouse)
    {
        int sum = 0;

        for (int row = 0; row < warehouse.Length; row++)
        {
            for (int column = 0; column < warehouse[0].Length; column++)
            {
                if (warehouse[row][column] == 'O' || warehouse[row][column] == '[')
                {
                    sum = sum + 100 * row + column;
                }
            }
        }

        return sum;
    }

    #endregion
}
