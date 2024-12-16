// https://www.codingame.com/training/expert/squares-order
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Expert.SquaresOrder;

public class SquaresOrder
{
    public List<(int Number, int Size)> GetOrder(int[][] map, int nbSquares)
    {
        var order = new List<(int Number, int Size)>();

        // Identify top square
        for (int n = 1; n <= nbSquares; n++)
        {
            var square = _findSquare(map, n, new());
            if (square is not null)
            {
                order.Add((n, square.Value.Size));
                break;
            }
        }

        order.Reverse();
        return order;
    }

    private (int number, int StartRow, int StartColumn, int Size)? _findSquare(int[][] map, int square, HashSet<int> overlappingSquares)
    {
        bool isTopLeftCornerFound = false;
        int startRow;
        int startColumn;

        for (int row = 0; row < map.Length; row++)
        {
            for (int column = 0; column < map[0].Length; column++)
            {
                if (map[row][column] == square)
                {
                    if (!isTopLeftCornerFound)
                    {
                        isTopLeftCornerFound = true;
                        startRow = row;
                        startColumn = column;
                        var size = _getSize(map, square, overlappingSquares, row, column);
                        return size.HasValue ? (square, startRow, startColumn, size.Value) : null;
                    }
                }
            }
        }

        return null;
    }

    private int? _getSize(int[][] map, int square, HashSet<int> overlappingSquares, int startRow, int startColumn)
    {
        // Compute size on one side
        int size = 0;
        while (startRow + size < map.Length && map[startRow + size][startColumn] == square)
        {
            size++;
        }

        if (size <= 1)
        {
            return null;
        }

        // Check that the other sides are complete
        for (int column = startColumn; column < startColumn + size; column++)
        {
            if (map[startRow][column] != square)
            {
                return null;
            }
        }
        for (int column = startColumn; column < startColumn + size; column++)
        {
            if (map[startRow + size - 1][column] != square)
            {
                return null;
            }
        }
        for (int row = startRow; row < startRow + size; row++)
        {
            if (map[row][startColumn + size - 1] != square)
            {
                return null;
            }
        }

        return size;
    }
}
