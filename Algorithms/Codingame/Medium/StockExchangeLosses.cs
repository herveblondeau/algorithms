// https://www.codingame.com/training/medium/stock-exchange-losses

using System;

namespace Codingame.Medium.StockExchangeLosses;

public class StockExchangeLosses
{
    public int FindMaxPossibleLoss(int[] values)
    {
        int maxLoss = 0;
        int currentValue = 0;
        int currentMax = 0;

        for (int i = 0; i < values.Length; i++)
        {
            currentValue = values[i];

            // This check ensures that we keep track of the absolute maximum, and not the local maximums. For instance, in the sequence 6 4 5 2 3 1, it ensures that the losses are computed against the value 6 (and not the local maximums 5 and 3)
            if (currentValue > currentMax)
            {
                currentMax = currentValue;
            }

            maxLoss = Math.Max(maxLoss, currentMax - currentValue);
        }

        return -maxLoss;
    }
}