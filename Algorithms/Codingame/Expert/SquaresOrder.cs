// https://www.codingame.com/training/expert/squares-order
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Expert.SquaresOrder;

// The algorithm does not cover all possibles cases, but it is enough to pass all Codingame tests (and more)
// It could be completed or rewritten to handle additional, more extreme cases
// TODO: probably implement a more bruteforce strategy that would write the expected result for a number of combinations, and find the only one matching the input
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
                var squareFromBeginning = _findSquareFromBeginning(map, id, processedIds);
                var squareFromEnd = _findSquareFromEnd(map, id, processedIds);
                if (squareFromBeginning is not null || squareFromEnd is not null)
                {
                    var maxSize = Math.Max(squareFromBeginning is not null ? squareFromBeginning.Value.Size : 0, squareFromEnd is not null ? squareFromEnd.Value.Size : 0);
                    order.Add((id, maxSize));
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

    private (int Id, int Size)? _findSquareFromBeginning(int[][] map, int id, HashSet<int> overlappingIds)
    {
        (int startRow, int startColumn) = _findFirstBlockFromBeginning(map, id);

        bool sizeFound = false;
        int size = _getMinimumSize(map, id) - 1;

        var currentSize = _getMaximumSizeFromBeginning(map, id, overlappingIds, startRow, startColumn);
        if (currentSize.HasValue && currentSize.Value > size)
        {
            size = currentSize.Value;
            sizeFound = true;
        }

        var currentRow = startRow - 1;
        while (currentRow >= 0 && overlappingIds.Contains(map[currentRow][startColumn]))
        {
            currentSize = _getMaximumSizeFromBeginning(map, id, overlappingIds, currentRow, startColumn);
            if (currentSize.HasValue && currentSize.Value > size)
            {
                size = currentSize.Value;
                sizeFound = true;
            }
            currentRow--;
        }

        var currentColumn = startColumn - 1;
        while (currentColumn >= 0 && overlappingIds.Contains(map[startRow][currentColumn]))
        {
            currentSize = _getMaximumSizeFromBeginning(map, id, overlappingIds, startRow, currentColumn);
            if (currentSize.HasValue && currentSize.Value > size)
            {
                size = currentSize.Value;
                sizeFound = true;
            }
            currentColumn--;
        }

        return sizeFound ? (id, size) : null;
    }

    private (int Row, int Column) _findFirstBlockFromBeginning(int[][] map, int id)
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

    private int? _getMaximumSizeFromBeginning(int[][] map, int id, HashSet<int> overlappingIds, int startRow, int startColumn)
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
            if (_isSizePossibleFromBeginning(map, id, overlappingIds, startRow, startColumn, size))
            {
                return size;
            }
        }

        return null;

    }

    private (int Id, int Size)? _findSquareFromEnd(int[][] map, int id, HashSet<int> overlappingIds)
    {
        (int endRow, int endColumn) = _findFirstBlockFromEnd(map, id);

        bool sizeFound = false;
        int size = _getMinimumSize(map, id) - 1;

        var currentSize = _getMaximumSizeFromEnd(map, id, overlappingIds, endRow, endColumn);
        if (currentSize.HasValue && currentSize.Value > size)
        {
            size = currentSize.Value;
            sizeFound = true;
        }

        var currentRow = endRow + 1;
        while (currentRow < map.Length && overlappingIds.Contains(map[currentRow][endColumn]))
        {
            currentSize = _getMaximumSizeFromEnd(map, id, overlappingIds, currentRow, endColumn);
            if (currentSize.HasValue && currentSize.Value > size)
            {
                size = currentSize.Value;
                sizeFound = true;
            }
            currentRow++;
        }

        var currentColumn = endColumn + 1;
        while (currentColumn < map[0].Length && overlappingIds.Contains(map[endRow][currentColumn]))
        {
            currentSize = _getMaximumSizeFromEnd(map, id, overlappingIds, endRow, currentColumn);
            if (currentSize.HasValue && currentSize.Value > size)
            {
                size = currentSize.Value;
                sizeFound = true;
            }
            currentColumn++;
        }

        return sizeFound ? (id, size) : null;
    }

    private bool _isSizePossibleFromBeginning(int[][] map, int id, HashSet<int> overlappingIds, int startRow, int startColumn, int size)
    {
        if (startRow + size - 1 >= map.Length || startColumn + size - 1 >= map[0].Length)
        {
            return false;
        }

        // Check that all sides are complete
        bool idFound = false;
        for (int row = startRow; row < startRow + size; row++)
        {
            if (id != map[row][startColumn] && !overlappingIds.Contains(map[row][startColumn]))
            {
                return false;
            }
            if (id == map[row][startColumn])
            {
                idFound = true;
            }
        }
        for (int row = startRow; row < startRow + size; row++)
        {
            if (id != map[row][startColumn + size - 1] && !overlappingIds.Contains(map[row][startColumn + size - 1]))
            {
                return false;
            }
            if (id == map[row][startColumn + size - 1])
            {
                idFound = true;
            }
        }
        for (int column = startColumn; column < startColumn + size; column++)
        {
            if (id != map[startRow][column] && !overlappingIds.Contains(map[startRow][column]))
            {
                return false;
            }
            if (id == map[startRow][column])
            {
                idFound = true;
            }
        }
        for (int column = startColumn; column < startColumn + size; column++)
        {
            if (id != map[startRow + size - 1][column] && !overlappingIds.Contains(map[startRow + size - 1][column]))
            {
                return false;
            }
            if (id == map[startRow + size - 1][column])
            {
                idFound = true;
            }
        }

        return idFound; // at least one block with the given id must be found
    }

    private (int Row, int Column) _findFirstBlockFromEnd(int[][] map, int id)
    {
        for (int row = map.Length - 1; row >= 0; row--)
        {
            for (int column = map[0].Length - 1; column >= 0; column--)
            {
                if (map[row][column] == id)
                {
                    return (row, column);
                }
            }
        }

        throw new Exception($"No block found for id {id}");
    }

    private int? _getMaximumSizeFromEnd(int[][] map, int id, HashSet<int> overlappingIds, int endRow, int endColumn)
    {
        int minimumSize = 2;
        int potentialSize = 1;
        int currentSize = 2;

        // Check down
        while (endRow - currentSize + 1 >= 0)
        {
            if (map[endRow - currentSize + 1][endColumn] == id)
            {
                minimumSize = currentSize;
                currentSize++;
            }
            else if (overlappingIds.Contains(map[endRow - currentSize + 1][endColumn]))
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
            if (_isSizePossibleFromEnd(map, id, overlappingIds, endRow, endColumn, size))
            {
                return size;
            }
        }

        return null;

    }

    private bool _isSizePossibleFromEnd(int[][] map, int id, HashSet<int> overlappingIds, int endRow, int endColumn, int size)
    {
        if (endRow - size + 1 < 0 || endColumn - size + 1 < 0)
        {
            return false;
        }

        // Check that all sides are complete
        bool idFound = false;
        for (int row = endRow; row > endRow - size; row--)
        {
            if (id != map[row][endColumn] && !overlappingIds.Contains(map[row][endColumn]))
            {
                return false;
            }
            if (id == map[row][endColumn])
            {
                idFound = true;
            }
        }
        for (int row = endRow; row > endRow - size; row--)
        {
            if (id != map[row][endColumn - size + 1] && !overlappingIds.Contains(map[row][endColumn - size + 1]))
            {
                return false;
            }
            if (id == map[row][endColumn - size + 1])
            {
                idFound = true;
            }
        }
        for (int column = endColumn; column > endColumn - size; column--)
        {
            if (id != map[endRow][column] && !overlappingIds.Contains(map[endRow][column]))
            {
                return false;
            }
            if (id == map[endRow][column])
            {
                idFound = true;
            }
        }
        for (int column = endColumn; column > endColumn - size; column--)
        {
            if (id != map[endRow - size + 1][column] && !overlappingIds.Contains(map[endRow - size + 1][column]))
            {
                return false;
            }
            if (id == map[endRow - size + 1][column])
            {
                idFound = true;
            }
        }

        return idFound;
    }

    // Determines the minimum possible size for a square
    // It does so by finding the largest distance between two blocks of the given id, by parsing each row and column
    private int _getMinimumSize(int[][] map, int id)
    {
        // Parse rows
        int left = int.MaxValue;
        int right = -1;
        int top = int.MaxValue;
        int bottom = -1;
        for (int row = 0; row < map.Length; row++)
        {
            for (int column = 0; column < map[0].Length; column++)
            {
                if (map[row][column] == id)
                {
                    if (row < top)
                    {
                        top = row;
                    }
                    if (row > bottom)
                    {
                        bottom = row;
                    }
                    if (column < left)
                    {
                        left = column;
                    }
                    if (column > right)
                    {
                        right = column;
                    }
                }
            }
        }

        return Math.Max(right - left + 1, bottom - top + 1);
    }
}
