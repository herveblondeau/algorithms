// https://www.codingame.com/training/medium/network-cabling

using System;
using System.Collections.Generic;
using System.Linq;

public class NetworkCabling
{
    public long GetMinimumCableLength(long[] xPositions, long[] yPositions)
    {
        var width = xPositions.Max() - xPositions.Min();

        yPositions = yPositions.OrderBy(y => y).ToArray();
        var medianIndex = Convert.ToInt64(Math.Ceiling(Convert.ToDouble(yPositions.Length) / 2) - 1);
        var medianY = yPositions[medianIndex];
        return width + yPositions.Sum(y => Math.Abs(medianY - y));
    }

}
