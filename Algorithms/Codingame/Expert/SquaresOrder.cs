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
        HashSet<int> availableIds = new(Enumerable.Range(1, nbSquares));
        HashSet<int> processedIds = new();

        int iteration = 1;
        while (availableIds.Count > 0)
        {
            bool squareFound = false;
            foreach (var id in availableIds)
            {
                var square = _findSquare(map, id, processedIds);
                if (square is not null)
                {
                    order.Add((id, square.Value.Size));
                    availableIds.Remove(id);
                    processedIds.Add(id);
                    squareFound = true;
                    iteration++;
                    break;
                }
            }
            if (!squareFound)
            {
                throw new Exception($"No square found on iteration {iteration}");
            }
        }

        order.Reverse();
        return order;
    }

    private (int Id, int StartRow, int StartColumn, int Size)? _findSquare(int[][] map, int id, HashSet<int> overlappingIds)
    {
        (int startRow, int startColumn) = _findFirstVisibleBlock(map, id);

        int size = 0;

        var currentSize = _getSize(map, id, overlappingIds, startRow, startColumn);
        if (currentSize.HasValue && currentSize.Value > size)
        {
            size = currentSize.Value;
        }

        var currentRow = startRow - 1;
        while (currentRow >= 0 && overlappingIds.Contains(map[currentRow][startColumn]))
        {
            currentSize = _getSize(map, id, overlappingIds, currentRow, startColumn);
            if (currentSize.HasValue && currentSize.Value > size)
            {
                size = currentSize.Value;
            }
            currentRow--;
        }

        var currentColumn = startColumn - 1;
        while (currentColumn >= 0 && overlappingIds.Contains(map[startRow][currentColumn]))
        {
            currentSize = _getSize(map, id, overlappingIds, startRow, currentColumn);
            if (currentSize.HasValue && currentSize.Value > size)
            {
                size = currentSize.Value;
            }
            currentColumn--;
        }

        return size > 0 ? (id, startRow, startColumn, size) : null;
    }

    private (int Row, int Column) _findFirstVisibleBlock(int[][] map, int id)
    {
        for (int row = 0; row < map.Length; row++)
        {
            for (int column = 0; column < map[0].Length; column++)
            {
                if (map[row][column] == id)
                {
                    return (row, column);
                }
            }
        }

        throw new Exception($"No block found for id {id}");
    }

    private int? _getSize(int[][] map, int id, HashSet<int> overlappingIds, int startRow, int startColumn)
    {
        int minimumSize = 2;
        int potentialSize = 1;
        int currentSize = 2;

        // Check down
        while (startRow + currentSize - 1 < map.Length)
        {
            if (map[startRow + currentSize - 1][startColumn] == id)
            {
                minimumSize = currentSize;
                currentSize++;
            }
            else if (overlappingIds.Contains(map[startRow + currentSize - 1][startColumn]))
            {
                potentialSize = currentSize;
                currentSize++;
            }
            else
            {
                break;
            }
        }
        if (potentialSize < minimumSize)
        {
            potentialSize = minimumSize;
        }

        if (minimumSize <= 1)
        {
            return null;
        }

        for (int size = potentialSize; size >= minimumSize; size--)
        {
            if (_isSizePossible(map, [..overlappingIds, id], startRow, startColumn, size))
            {
                return size;
            }
        }

        return null;

    }

    private bool _isSizePossible(int[][] map, HashSet<int> allowedIds, int startRow, int startColumn, int size)
    {
        if (startRow + size - 1 >= map.Length || startColumn + size - 1 >= map[0].Length)
        {
            return false;
        }

        // Check that all sides are complete
        for (int row = startRow; row < startRow + size; row++)
        {
            if (!allowedIds.Contains(map[row][startColumn]))
            {
                return false;
            }
        }
        for (int row = startRow; row < startRow + size; row++)
        {
            if (!allowedIds.Contains(map[row][startColumn + size - 1]))
            {
                return false;
            }
        }
        for (int column = startColumn; column < startColumn + size; column++)
        {
            if (!allowedIds.Contains(map[startRow][column]))
            {
                return false;
            }
        }
        for (int column = startColumn; column < startColumn + size; column++)
        {
            if (!allowedIds.Contains(map[startRow + size - 1][column]))
            {
                return false;
            }
        }

        return true;
    }
}
