// https://leetcode.com/problems/container-with-most-water/

using System;
using System.Collections.Generic;

namespace LeetCode.ContainerWithMostWater;

public class ContainerWithMostWater
{
    public int ComputeAmount(int[] heights)
    {
        int left = 0;
        int right = heights.Length - 1;

        int maxAmount = _getAmount(heights, left, right);

        while (left != right)
        {
            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                right--;
            }
            maxAmount = Math.Max(maxAmount, _getAmount(heights, left, right));
        }

        return maxAmount;
    }

    private int _getAmount(int[] heights, int left, int right)
    {
        return (right - left) * Math.Min(heights[left], heights[right]);
    }
}
