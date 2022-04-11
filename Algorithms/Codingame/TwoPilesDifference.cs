// 

using ByTheme.Combinations;
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

            int difference = int.MaxValue;
            foreach (var valuesToSquare in Combinations.GetCombinations(values, values.Length / 2))
            {
                int[] valuesToMultiply = _getValuesToMultiply(values, valuesToSquare);
                difference = Math.Min(difference, _computeDifference(valuesToSquare, valuesToMultiply));
            }

            return difference;
        }

        private int[] _getValuesToMultiply(int[] values, int[] valuesToSquare)
        {
            var allValues = new Dictionary<int, int>();
            for (int i = 0; i < values.Length; i++)
            {
                if (allValues.ContainsKey(values[i]))
                {
                    allValues[values[i]]++;
                }
                else
                {
                    allValues.Add(values[i], 1);
                }
            }

            foreach (var value in valuesToSquare)
            {
                if (allValues[value] > 1)
                {
                    allValues[value]--;
                }
                else
                {
                    allValues.Remove(value);
                }
            }

            int[] valuesToMultiply = new int[valuesToSquare.Length];
            int j = 0;
            foreach (var value in allValues.Keys)
            {
                for (int i = 0; i < allValues[value]; i++)
                {
                    valuesToMultiply[j++] = value;
                }
            }

            return valuesToMultiply;
        }

        private int _computeDifference(int[] numbersToSquare, int[] numbersToMultiply)
        {
            int sum = 0;
            for (int i = 0; i < numbersToSquare.Length; i++) sum += numbersToSquare[i];

            int product = 1;
            for (int i = 0; i < numbersToMultiply.Length; i++) product *= numbersToMultiply[i];

            return Math.Abs(sum * sum - product);
        }
    }

}