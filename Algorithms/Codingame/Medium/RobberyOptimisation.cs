// https://www.codingame.com/training/medium/robbery-optimisation
using System;
using System.Collections.Generic;

namespace Codingame.Medium.RobberyOptimisation;

public class RobberyOptimisation
{
    private Dictionary<int, long> _maxAmountFromIndex;

    public long GetMaximumAmount(long[] values)
    {
        _maxAmountFromIndex = new Dictionary<int, long>();

        return RecursiveSolve(values, 0);
    }

    private long RecursiveSolve(long[] values, int startIndex)
    {
        // Return best amount if already known
        if (_maxAmountFromIndex.ContainsKey(startIndex))
        {
            return _maxAmountFromIndex[startIndex];
        }

        // Otherwise compute...
        long maxAmount;
        switch (values.Length - startIndex)
        {
            case 0:
                maxAmount = 0;
                break;

            case 1:
                maxAmount = values[startIndex];
                break;

            case 2:
                maxAmount = Math.Max(values[startIndex], values[startIndex + 1]);
                break;

            default:
                maxAmount = Math.Max(values[startIndex] + RecursiveSolve(values, startIndex + 2), RecursiveSolve(values, startIndex + 1));
                break;
        }

        // ...avoid trapped houses...
        if (maxAmount < 0)
        {
            maxAmount = 0;
        }

        // ...and store
        _maxAmountFromIndex.Add(startIndex, maxAmount);

        return maxAmount;
    }

}