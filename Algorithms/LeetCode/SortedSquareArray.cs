// https://leetcode.com/problems/squares-of-a-sorted-array/

using System;

namespace LeetCode.SortedSquareArray;

public class SortedSquareArray
{
    // O(n) time, O(1) space
    public static int[] SortSquares(int[] numbers)
    {
        int[] results = new int[numbers.Length];

        // Because the input array is sorted, the nearer a value is to an extremity, the higher its produced square will be
        // Therefore we can get a O(n) complexity by using a classic two-pointer strategy, starting from both ends and moving towards each other. At each step, we take the number that has the highest square, place it at the last available slot in the result array and move the corresponding pointer towards the other
        int leftIndex = 0;
        int rightIndex = results.Length - 1;
        int targetIndex = results.Length - 1; // for placement in the result array

        int leftSquare;
        int rightSquare;
        while (leftIndex != rightIndex)
        {
            leftSquare = (int)Math.Pow(numbers[leftIndex], 2);
            rightSquare = (int)Math.Pow(numbers[rightIndex], 2);

            if (leftSquare > rightSquare)
            {
                results[targetIndex] = leftSquare;
                leftIndex++;
            }
            else
            {
                results[targetIndex] = rightSquare;
                rightIndex--;
            }

            targetIndex--;
        }

        // One final step when both pointers target the same slot
        leftSquare = (int)Math.Pow(numbers[leftIndex], 2);
        rightSquare = (int)Math.Pow(numbers[rightIndex], 2);
        results[targetIndex] = Math.Max(leftSquare, rightSquare);

        return results;
    }
}
