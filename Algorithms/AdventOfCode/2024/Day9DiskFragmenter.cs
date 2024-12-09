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

    // public long CalculateChecksumWithFileDefragmentation(string diskMap)
    // {
    //     var decompressedDiskMap = _decompress(diskMap);
    //     var defragmentedDiskMap = _defragmentFiles(decompressedDiskMap);
    //     return _calculateChecksum(defragmentedDiskMap);
    // }

    // private List<int> _defragmentFiles(List<int> decompressedDiskMap)
    // {
    //     var blockStartIndexes

    //     List<int> defragmentedDiskMap = new();

    //     var nextEmptyBlock = _getNextEmptyBlock(decompressedDiskMap, -1);
    //     var nextFileToMove = _getPreviousFile(decompressedDiskMap, decompressedDiskMap.Count);

    //     while (nextEmptyBlock.StartIndex < nextFileToMove.StartIndex)
    //     {
    //         while (nextFileToMove.Size > nextEmptyBlock.Size)
    //         {
    //             nextFileToMove = _getPreviousFile(decompressedDiskMap, decompressedDiskMap.Count);
    //         }

    //         _moveFile(nextFileToMove, nextEmptyBlock);

    //         nextEmptyBlock = _getNextEmptyBlock(decompressedDiskMap, -1);
    //         nextFileToMove = _getPreviousFile(decompressedDiskMap, decompressedDiskMap.Count);
    //     }

    //     return defragmentedDiskMap;
    // }

    // private (int StartIndex, int Size) _getNextEmptyBlock(List<int> decompressedDiskMap, int currentIndex)
    // {
    //     currentIndex++;
    //     while (decompressedDiskMap[currentIndex] != -1)
    //     {
    //         currentIndex++;
    //     }

    //     var startIndex = currentIndex;
    //     var fileSize = 0;
    //     while (decompressedDiskMap[currentIndex] == -1)
    //     {
    //         fileSize++;
    //         currentIndex++;
    //     }

    //     return (startIndex, fileSize);
    // }

    // private (int Id, int StartIndex, int Size) _getPreviousFile(List<int> decompressedDiskMap, int currentIndex)
    // {
    //     currentIndex--;
    //     while (decompressedDiskMap[currentIndex] == -1)
    //     {
    //         currentIndex--;
    //     }

    //     var fileId = decompressedDiskMap[currentIndex];
    //     var fileSize = 0;
    //     while (decompressedDiskMap[currentIndex] == fileId)
    //     {
    //         fileSize++;
    //         currentIndex--;
    //     }

    //     return (fileId, currentIndex, fileSize);
    // }

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

        int i = 0;
        while (i < defragmentedDiskMap.Count && defragmentedDiskMap[i] is not null)
        {
            sum = sum + i * defragmentedDiskMap[i]!.Value;
            i++;
        }

        return sum;
    }

    #endregion
}
