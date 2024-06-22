// https://practice.geeksforgeeks.org/problems/inversion-of-array/0/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GeeksForGeeks.InversionOfArray
{
    public class InversionOfArray
    {
        // O(nlogn) time, O(n) space
        public int GetInversionCount(int[] values)
        {
            int inversionCount = 0;
            List<int> reverseOrderedValues = new(); // keeps track of all values that have already been processed, keeping them in reverse order

            // For each element, do a 0(logn) search to find where it would fit in a reverse ordered list composed of the previous items: this is equivalent to counting how many previous items are greater
            foreach(int value in values)
            {
                int position = GetReverseOrderPosition(reverseOrderedValues, value);
                reverseOrderedValues.Insert(position, value);
                inversionCount += position;
            }
            return inversionCount;
        }

        private int GetReverseOrderPosition(List<int> reverseOrderedValues, int value)
        {
            return GetReverseOrderPositionInRange(reverseOrderedValues, value, 0, Math.Max(reverseOrderedValues.Count - 1, 0));
        }

        private int GetReverseOrderPositionInRange(List<int> reverseOrderedValues, int value, int start, int end)
        {
            // Base cases
            if (reverseOrderedValues.Count == 0 && start == 0 && end == 0)
            {
                return 0;
            }

            if (start >= reverseOrderedValues.Count || end >= reverseOrderedValues.Count)
            {
                return -1;
            }

            if (start == end)
            {
                return value >= reverseOrderedValues[start] ? start : start + 1;
            }

            // Recursion
            int position = start + (end - start) / 2;
            if (value > reverseOrderedValues[position])
            {
                return GetReverseOrderPositionInRange(reverseOrderedValues, value, start, position);
            }
            else if (value < reverseOrderedValues[position])
            {
                return GetReverseOrderPositionInRange(reverseOrderedValues, value, position + 1, end);
            }
            else
            {
                return position;
            }
        }

        //// O(n2) time, O(1) space
        //public int GetInversionCount(int[] elements)
        //{
        //    int inversionCount = 0;

        //    // Just count, for each element, the number of elements before it that are greater
        //    for (int i = 0; i < elements.Length; i++)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            if (elements[i] < elements[j])
        //            {
        //                inversionCount++;
        //            }
        //        }
        //    }
        //    return inversionCount;
        //}
    }
}
