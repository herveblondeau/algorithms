using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day9DiskFragmenter
{
    #region Part 1

    public long CalculateChecksum(string diskMap)
    {
        var decompressedDiskMap = _decompress(diskMap);
        var defragmentedDiskMap = _defragment(decompressedDiskMap);
        return _calculateChecksum(defragmentedDiskMap);
    }

    private List<int> _decompress(string diskMap)
    {
        List<int> decompressedDiskMap = new();
        bool isCurrentBlockFile = true;
        int currentFileId = 0;

        foreach (var c in diskMap)
        {
            int currentLength = (int)char.GetNumericValue(c);
            int currentValue = isCurrentBlockFile ? currentFileId : -1;
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

    private List<int> _defragment(List<int> decompressedDiskMap)
    {
        List<int> defragmentedDiskMap = new();

        int forwardIndex = 0;
        int backwardIndex = decompressedDiskMap.Count - 1;
        while (decompressedDiskMap[backwardIndex] == -1)
        {
            backwardIndex--;
        }

        while (forwardIndex <= backwardIndex)
        {
            if (decompressedDiskMap[forwardIndex] == -1)
            {
                defragmentedDiskMap.Add(decompressedDiskMap[backwardIndex]);
                backwardIndex--;
                while (decompressedDiskMap[backwardIndex] == -1)
                {
                    backwardIndex--;
                }
            }
            else
            {
                defragmentedDiskMap.Add(decompressedDiskMap[forwardIndex]);
            }

            forwardIndex++;
        }

        return defragmentedDiskMap;
    }

    private long _calculateChecksum(List<int> defragmentedDiskMap)
    {
        long sum = 0;

        for (int i = 0; i < defragmentedDiskMap.Count; i++)
        {
            sum = sum + i * defragmentedDiskMap[i];
        }

        return sum;
    }

    #endregion
}
