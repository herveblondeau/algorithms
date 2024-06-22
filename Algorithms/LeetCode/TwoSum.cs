// https://leetcode.com/problems/two-sum/
using System.Collections.Generic;

namespace LeetCode.TwoSum
{
    public class TwoSum
    {
        // O(n) time, O(n) space
        public static int[] Find(int[] numbers, int target)
        {
            int index1 = -1;
            int index2 = -1;

            // We create a dictionary containing the numbers as keys and the positions at which they can be found as values
            Dictionary<int, int> numberIndexes = new();
            for (int i = 0; i < numbers.Length; i++)
            {
                // Upsert the index
                // If the same number appears multiple times, only the last index is stored. This is OK because:
                // - if the number is part of the solution, it will appear twice in total (because the problem states in bold that "Only one valid answer exists"). So when we loop through the array below and get to the first occurrence, we only need to find the second one
                // - otherwise, we don't need it anyway
                if (numberIndexes.ContainsKey(numbers[i]))
                {
                    numberIndexes[numbers[i]] = i;
                }
                else
                {
                    numberIndexes.Add(numbers[i], i);
                }
            }

            // For each number, we look up its match's position in the dictionary
            for (int i = 0; i < numbers.Length; i++)
            {
                int match = target - numbers[i];
                if (numberIndexes.ContainsKey(match)
                    && i != numberIndexes[match])
                {
                    index1 = i;
                    index2 = numberIndexes[match];
                    break;
                }
            }

            return new int[] { index1, index2 };
        }
    }
}
