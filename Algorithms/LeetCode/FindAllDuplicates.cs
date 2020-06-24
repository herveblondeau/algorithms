// https://leetcode.com/problems/find-all-duplicates-in-an-array/
using System.Collections.Generic;

namespace LeetCode.FindAllDuplicates
{
    public class ArrayDuplicates
    {
        // O(n) time, O(n) space
        public static int[] FindAllDuplicates(int[] values)
        {
            HashSet<int> visitedValues = new HashSet<int>();
            List<int> duplicates = new List<int>();

            foreach (var value in values)
            {
                if (visitedValues.Contains(value))
                {
                    duplicates.Add(value);
                }
                else
                {
                    visitedValues.Add(value);
                }

            }
            return duplicates.ToArray();
        }
    }
}
