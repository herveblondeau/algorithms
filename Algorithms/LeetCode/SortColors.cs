// https://leetcode.com/problems/find-all-duplicates-in-an-array/
using System;
using System.Collections.Generic;

namespace LeetCode.SortColors
{
    public class SortColors
    {
        // O(n) time, O(1) space
        // Instead of colors, we assume that the array contains values between 0 and 2
        public static int[] Sort(int[] values)
        {

            int i = 0;
            int nextZeroPosition = 0;
            int nextTwoPosition = values.Length - 1;

            // The idea is to loop through the array and:
            // - push every 0 as far to the left as possible
            // - push every 2 as far to the right as possible

            // We use three pointers:
            // - i keeps track of the current element
            // - nextZeroPosition is the position to which the next 0 should be pushed: it starts at zero and is incremented every time a 0 is found
            // - nextTwoPosition is the position to which the next 2 should be pushed: it starts at the the last index and is decremented every time a 2 is found
            while (i <= nextTwoPosition) // No need to go further than this limit, since the items behind have already been processed (they have been pushed to the right)
            {
                // Narrow down the sides
                while (nextZeroPosition < values.Length && values[nextZeroPosition] == 0)
                    nextZeroPosition++;
                if (nextZeroPosition == values.Length)
                    break;

                while (nextTwoPosition >= 0 && values[nextTwoPosition] == 2)
                    nextTwoPosition--;
                if (nextTwoPosition == -1)
                    break;

                // Update i
                i = Math.Max(i, nextZeroPosition);
                if (i >= values.Length)
                    break;

                // Push 2 to the right
                if (values[i] == 2)
                {
                    values[i] = values[nextTwoPosition];
                    values[nextTwoPosition] = 2;
                    nextTwoPosition--;
                }

                // Push 0 to the left
                if (values[i] == 0)
                {
                    values[i] = values[nextZeroPosition];
                    values[nextZeroPosition] = 0;
                    nextZeroPosition++;
                }

                // Move to the next element
                i++;
            }

            return values;
        }
    }
}
