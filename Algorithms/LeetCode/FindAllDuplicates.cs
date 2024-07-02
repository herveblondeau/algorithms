// https://leetcode.com/problems/find-all-duplicates-in-an-array/

using System;
using System.Collections.Generic;

namespace LeetCode.FindAllDuplicates;

public class ArrayDuplicates
{
    // O(n) time, O(1) space
    // The only drawback is that it modifies the initial array (but we can easily make another O(n) pass to restore the initial values)
    public static int[] FindAllDuplicates(int[] values)
    {
        // We use the given information that every element is strictly positive and lower than or equal to the array length
        List<int> duplicates = new();

        for (int i = 0; i < values.Length; i++)
        {
            // We use the current value (n) as an index. If the nth element is positive, we switch it to its negative value. If the nth element is negative, it means that it has been switched before, therefore n is a duplicate.

            int index = Math.Abs(values[i]) - 1;
            if (values[index] < 0)
            {
                duplicates.Add(Math.Abs(values[i]));
            }
            else
            {
                values[index] = -values[index];
            }
        }
        return duplicates.ToArray();
    }

    //// O(n) time, O(n) space
    //public static int[] FindAllDuplicates(int[] values)
    //{
    //    HashSet<int> visitedValues = new HashSet<int>();
    //    List<int> duplicates = new List<int>();

    //    foreach (var value in values)
    //    {
    //        if (visitedValues.Contains(value))
    //        {
    //            duplicates.Add(value);
    //        }
    //        else
    //        {
    //            visitedValues.Add(value);
    //        }

    //    }
    //    return duplicates.ToArray();
    //}
}
