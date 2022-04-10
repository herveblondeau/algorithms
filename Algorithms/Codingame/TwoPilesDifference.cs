// https://www.codingame.com/training/medium/stock-exchange-losses

using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame.TwoPilesDifference
{
    public class TwoPilesDifference
    {
        public int FindMinDifference(int[] values)
        {
            if (values.Length % 2 != 0)
            {
                throw new ArgumentException("The list must contain an even number of values");
            }

            HashSet<string> visited = new HashSet<string>();
            int[] numbersToSquare = new int[values.Length / 2];
            int[] numbersToMultiply = new int[values.Length / 2];
            for (int i = 0; i < values.Length / 2; i++)
            {
                numbersToSquare[i] = values[i];
            }
            for (int i = 0; i < values.Length / 2; i++)
            {
                numbersToMultiply[i] = values[values.Length / 2 + i];
            }

            int difference = _computeDifference(numbersToSquare, numbersToMultiply);

            while (_swap(numbersToSquare, numbersToMultiply, visited, difference))
            {
                difference = _computeDifference(numbersToSquare, numbersToMultiply);
            }

            return difference;
        }

        private bool _swap(int[] numbersToSquare, int[] numbersToMultiply, HashSet<string> visited, int difference)
        {
            for (int i = 0; i < numbersToSquare.Length; i++)
            {
                for (int j = 0; j < numbersToMultiply.Length; j++)
                {
                    (numbersToSquare[i], numbersToMultiply[j]) = (numbersToMultiply[j], numbersToSquare[i]);
                    string currentDistribution = _toString(numbersToSquare, numbersToMultiply);
                    if (visited.Contains(currentDistribution))
                    {
                        (numbersToSquare[i], numbersToMultiply[j]) = (numbersToMultiply[j], numbersToSquare[i]);
                        continue;
                    }

                    int nextDifference = _computeDifference(numbersToSquare, numbersToMultiply);
                    if (nextDifference < difference)
                    {
                        return true;
                    }
                    else
                    {
                        (numbersToSquare[i], numbersToMultiply[j]) = (numbersToMultiply[j], numbersToSquare[i]);
                    }
                    visited.Add(currentDistribution);
                }
            }

            return false;
        }

        private int _computeDifference(int[] numbersToSquare, int[] numbersToMultiply)
        {
            int sum = 0;
            for (int i = 0; i < numbersToSquare.Length; i++) sum += numbersToSquare[i];

            int product = 1;
            for (int i = 0; i < numbersToMultiply.Length; i++) product *= numbersToMultiply[i];

            return Math.Abs(sum * sum - product);
        }

        private string _toString(int[] numbersToSquare, int[] numbersToMultiply)
        {
            StringBuilder result = new StringBuilder();

            result.Append(numbersToSquare[0]);
            for (int i = 1; i < numbersToSquare.Length; i++)
            {
                result.Append("-");
                result.Append(numbersToSquare[i]);
            }
            for (int i = 0; i < numbersToMultiply.Length; i++)
            {
                result.Append("-");
                result.Append(numbersToMultiply[i]);
            }

            return result.ToString();
        }
    }
}