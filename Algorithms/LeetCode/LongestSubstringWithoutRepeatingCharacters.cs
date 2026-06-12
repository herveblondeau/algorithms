// https://leetcode.com/problems/longest-substring-without-repeating-characters/

using System;
using System.Collections.Generic;

namespace LeetCode.LongestSubstringWithoutRepeatingCharacters;

public class LongestSubstringWithoutRepeatingCharacters
{
    // Time O(n), space O(n)
    public int GetLength(string s)
    {
        int result = 0;
        int left = 0;
        Dictionary<char, int> lastPositions = new();

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];

            if (lastPositions.TryGetValue(current, out int lastPos) && lastPos >= left)
            {
                left = lastPos + 1;
            }

            lastPositions[current] = i;
            result = Math.Max(result, i - left + 1);
        }

        return result;
    }
}
