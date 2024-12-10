// https://adventofcode.com/2024/day/9

using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day9DiskFragmenter
{
    #region Part 1

    public long CalculateChecksumWithBlockDefragmentation(string diskMap)
    {
        var decompressedDiskMap = _decompress(diskMap);
        _defragmentBlocks(decompressedDiskMap);
        return _calculateChecksum(decompressedDiskMap);
    }

    private void _defragmentBlocks(List<int?> decompressedDiskMap)
    {
        var currentEmptyBlockIndex = _getNextEmptyBlockIndex(decompressedDiskMap, -1);
        var currentFileBlockIndex = _getPreviousFileBlockIndex(decompressedDiskMap, decompressedDiskMap.Count);

        while (currentEmptyBlockIndex is not null && currentFileBlockIndex is not null
            && currentEmptyBlockIndex < currentFileBlockIndex)
        {
            decompressedDiskMap[currentEmptyBlockIndex.Value] = decompressedDiskMap[currentFileBlockIndex.Value];
            decompressedDiskMap[currentFileBlockIndex.Value] = null;

            currentEmptyBlockIndex = _getNextEmptyBlockIndex(decompressedDiskMap, -1);
            currentFileBlockIndex = _getPreviousFileBlockIndex(decompressedDiskMap, decompressedDiskMap.Count);
        }
    }

    private int? _getNextEmptyBlockIndex(List<int?> decompressedDiskMap, int currentIndex)
    {
        currentIndex++;
        while (currentIndex < decompressedDiskMap.Count && decompressedDiskMap[currentIndex] is not null)
        {
            currentIndex++;
        }
        return currentIndex < decompressedDiskMap.Count ? currentIndex : null;
    }

    private int? _getPreviousFileBlockIndex(List<int?> decompressedDiskMap, int currentIndex)
    {
        currentIndex--;
        while (currentIndex >= 0 && decompressedDiskMap[currentIndex] is null)
        {
            currentIndex--;
        }
        return currentIndex >= 0 ? currentIndex : null;
    }

    #endregion

    #region Part 2

    public long CalculateChecksumWithFileDefragmentation(string diskMap)
    {
        var decompressedDiskMap = _decompress(diskMap);
        _defragmentFiles(decompressedDiskMap);
        return _calculateChecksum(decompressedDiskMap);
    }

    private void _defragmentFiles(List<int?> decompressedDiskMap)
    {
        var files = _getAllFiles(decompressedDiskMap);

        for (int i = files.Count - 1; i >= 0; i--)
        {
            var file = files[i];

            (int StartIndex, int Size)? empty = _getFirstEmpty(decompressedDiskMap, file.Size, file.StartIndex);
            if (empty is not null)
            {
                _moveFile(decompressedDiskMap, file, empty.Value);
            }
        }
    }

    private (int StartIndex, int Size)? _getFirstEmpty(List<int?> decompressedDiskMap, int size, int belowIndex)
    {
        bool isEmpty = false;
        int startIndex = -1;
        int availableSpace = 0;

        for (int i = 0; i < belowIndex; i++)
        {
            if (decompressedDiskMap[i] is not null)
            {
                isEmpty = false;
                continue;
            }

            if (!isEmpty)
            {
                startIndex = i;
                availableSpace = 1;
            }
            else
            {
                availableSpace++;
            }

            if (availableSpace == size)
            {
                return (startIndex, size);
            }

            isEmpty = true;
        }

        return null;
    }

    private List<(int Id, int StartIndex, int Size)> _getAllFiles(List<int?> decompressedDiskMap)
    {
        List<(int Id, int StartIndex, int Size)> files = new();

        bool isFile = false;
        int id = -1;
        int startIndex = -1;
        int size = 0;
        for (int i = 0; i < decompressedDiskMap.Count; i++)
        {
            // Empty
            if (decompressedDiskMap[i] is null)
            {
                if (isFile)
                {
                    files.Add((id, startIndex, size));
                    id = -1;
                }

                isFile = false;
                continue;
            }

            isFile = true;
            // Same file
            if (decompressedDiskMap[i] == id)
            {
                size++;
            }
            // New file
            else
            {
                if (id != -1)
                {
                    files.Add((id, startIndex, size));
                }
                id = decompressedDiskMap[i]!.Value;
                startIndex = i;
                size = 1;
            }
        }

        if (isFile)
        {
            files.Add((id, startIndex, size));
        }

        return files;
    }

    private void _moveFile(List<int?> decompressedDiskMap, (int Id, int StartIndex, int Size) file, (int StartIndex, int Size) empty)
    {
        for (int i = 0; i < file.Size; i++)
        {
            decompressedDiskMap[empty.StartIndex + i] = file.Id;
            decompressedDiskMap[file.StartIndex + i] = null;
        }
    }

    #endregion

    #region Common

    private List<int?> _decompress(string diskMap)
    {
        List<int?> decompressedDiskMap = new();
        bool isCurrentBlockFile = true;
        int currentFileId = 0;

        foreach (var c in diskMap)
        {
            int currentLength = (int)char.GetNumericValue(c);
            int? currentValue = isCurrentBlockFile ? currentFileId : null;
            for (int i = 0; i < currentLength; i++)
            {
                decompressedDiskMap.Add(currentValue);
            }

            if (isCurrentBlockFile)
            {
                currentFileId++;
            }

            isCurrentBlockFile = !isCurrentBlockFile;
        }

        return decompressedDiskMap;
    }

    private long _calculateChecksum(List<int?> defragmentedDiskMap)
    {
        long sum = 0;

        for (int i = 0; i < defragmentedDiskMap.Count; i++)
        {
            if (defragmentedDiskMap[i] is null)
            {
                continue;
            }
            sum = sum + i * defragmentedDiskMap[i]!.Value;
        }

        return sum;
    }

    #endregion
}
