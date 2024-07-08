// https://www.codingame.com/training/easy/rectangle-partition

using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Easy.RectanglePartition;

public class RectanglePartition
{
    public int GetNbSquares(List<int> xMeasurements, List<int> yMeasurements)
    {
        Dictionary<int, int> widths = GetAllPossibleSizes(xMeasurements);
        Dictionary<int, int> heights = GetAllPossibleSizes(yMeasurements);

        // Compute the number of squares
        return widths.Keys.Where(heights.ContainsKey) // keep only sizes that exist for both width and height
            .Select(key => widths[key] * heights[key]) // multiply (if a size is present 3 times on the width and 2 times on the height, it makes 6 squares)
            .Sum();
    }

    // Given intermediate line positions and the total size, returns a dictionary where keys are the size and values are the number of occurrences
    private Dictionary<int, int> GetAllPossibleSizes(List<int> inputs)
    {
        // Build a list containing each size. For the nth position, there are n sizes: the current one minus each of the (n-1) previous ones, plus the current one
        // For instance with 2, 3, 5 and 10:
        // - 2: just 2
        // - 3: 3 minus 2, 3
        // - 5: 5 minus 3, 5 minus 2, 5
        // - 10: 10 minus 5, 10 minus 3, 10 minus 2, 10
        // => 2, 1, 3, 2, 3, 5, 5, 7, 8, 10
        List<int> sizes = new List<int>();
        for (int i = 0; i < inputs.Count; i++)
        {
            int n = inputs[i];
            sizes.AddRange(inputs.Take(i).Select(x => n - x).ToList());
            sizes.Add(n);
        }

        // Count by size
        // => (1:1), (2:2), (3:2), (5:2), (7:1), (8:1), (10:1)
        return sizes.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    }
}
