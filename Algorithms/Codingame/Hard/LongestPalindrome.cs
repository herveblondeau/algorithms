// https://www.codingame.com/training/hard/longest-palindrome

using System.Collections.Generic;

namespace Codingame.Hard.LongestPalindrome;

public class LongestPalindrome
{
    // Time O(n²) (one loop to list the starting characters, the other to find the corresponding palindromes)
    public List<string> GetLongestPalindromes(string input)
    {
        int longestLength = 0;
        List<string> longestPalindromes = new();
        // We look for a palindrome starting at every position
        for (int i = 0; i < input.Length; i++)
        {
            // Each position can actually be a character (odd-length palindromes such as ABCBA) or be between two characters (even-length palindromes such as ABCCBA)
            for (int j = 0; j <= 1; j++)
            {
                string longestPalindrome = _getLongestPalindrome(input, i, i + j);

                if (longestPalindrome?.Length > longestLength)
                {
                    longestPalindromes.Clear();
                    longestLength = longestPalindrome.Length;
                    longestPalindromes.Add(longestPalindrome);
                }
                else if (longestPalindrome?.Length == longestLength)
                {
                    longestPalindromes.Add(longestPalindrome);
                }
            }
        }
        return longestPalindromes;
    }

    // Look for a palindrome by starting at the given extremities and trying to expand towards the sides
    private string _getLongestPalindrome(string input, int start, int end)
    {
        if (start <= 0 || end >= input.Length || input[start] != input[end])
        {
            return null;
        }

        while (start >= 0 && end < input.Length && input[start] == input[end])
        {
            start--;
            end++;
        }
        start++;
        end--;
        return input.Substring(start, end - start + 1);
    }
}