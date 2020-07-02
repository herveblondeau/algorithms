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
            int previousTwoPosition = values.Length - 1;

            while (i <= previousTwoPosition)
            {
                // Narrow down
                while (nextZeroPosition < values.Length && values[nextZeroPosition] == 0)
                    nextZeroPosition++;
                if (nextZeroPosition == values.Length)
                    break;
                while (previousTwoPosition >= 0 && values[previousTwoPosition] == 2)
                    previousTwoPosition--;
                if (previousTwoPosition == -1)
                    break;

                // Update i
                i = Math.Max(i, nextZeroPosition);
                if (i >= values.Length)
                    break;

                // Swap 2
                if (values[i] == 2)
                {
                    values[i] = values[previousTwoPosition];
                    values[previousTwoPosition] = 2;
                    previousTwoPosition--;
                }

                // Swap 0
                if (values[i] == 0)
                {
                    values[i] = values[nextZeroPosition];
                    values[nextZeroPosition] = 0;
                    nextZeroPosition++;
                }

                i++;
            }

            //int nextZeroPosition = 0;
            //while (values[nextZeroPosition] == 0)
            //{
            //    nextZeroPosition++;
            //}

            //int previousTwoPosition = values.Length - 1;
            //while (values[previousTwoPosition] == 2)
            //{
            //    previousTwoPosition--;
            //}

            //for (int i = 0; i < values.Length; i++)
            //{
            //    if (values[i] == 0)
            //    {
            //        if (i > nextZeroPosition)
            //        {
            //            values[i] = 1;
            //            values[nextZeroPosition++] = 0;
            //        }
            //    }
            //    else if (values[i] == 2)
            //    {
            //        if (i < previousTwoPosition)
            //        {
            //            values[i] = 1;
            //            values[previousTwoPosition--] = 2;
            //        }
            //    }
            //}

            return values;
        }
    }
}
