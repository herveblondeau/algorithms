// https://www.codingame.com/training/easy/largest-number

using System;
using System.Collections.Generic;

namespace Codingame.Easy.LargestNumber;

public class LargestNumber
{
    public int GetLargest(int number, int divisor)
    {
        // Remove 0 digit
        if (number % divisor == 0)
        {
            return number;
        }

        List<int> digits = new();
        var n = number;
        while (n > 0)
        {
            digits.Insert(0, n % 10);
            n /= 10;
        }

        int largestNumber = 0;

        // Remove 1 digit
        for (int i = 0; i < digits.Count; i++)
        {
            n = _removeDigit(number, digits.Count, i);
            if (n % divisor == 0 && n > largestNumber)
            {
                largestNumber = n;
            }
        }

        // Remove 2 digits
        for (int i = 0; i < digits.Count; i++)
        {
            for (int j = i + 1; j < digits.Count; j++)
            {
                n = _removeDigit(number, digits.Count, j);
                n = _removeDigit(n, digits.Count - 1, i);
                if (n % divisor == 0 && n > largestNumber)
                {
                    largestNumber = n;
                }
            }
        }

        // No solution
        return largestNumber;
    }

    private int _removeDigit(int number, int nbDigits, int position)
    {
        // Method 1: via string parsing
        // return int.Parse(number.ToString().Remove(position, 1));

        // Method 2: by splitting the number into parts on both sides of the digit to remove
        // Example with 47532, where we want to remove the 5 (position 2):
        // The goal is to arrive at 4700 + 32
        // Left part: 47532 / 10^3 = 47, then 47 * 10^2 = 4700
        // Right part: 47532 % 10^2 = 32
        var left = number / (int)Math.Pow(10, nbDigits - position) * (int)Math.Pow(10, nbDigits - position - 1);
        var right = number % (int)Math.Pow(10, nbDigits - position - 1);
        return left + right;
    }
}
