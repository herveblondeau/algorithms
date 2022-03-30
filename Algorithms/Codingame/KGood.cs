// https://www.codingame.com/training/hard/kgood

using System;
using System.Collections.Generic;

namespace Codingame.KGood
{
    public class KGood
    {
        // Gets the length of the longest KGood substring included anywhere in the given input
        public int GetLongestKSubstringLength(string input, int k)
        {
            // This algorithm computes the longest KGood substring starting at every character change in the input
            // For instance, with "aabbcaaddeeeeeffgh" and k=3:
            // - "aabbcaaddeeeeeffgh"   -> "aabbcaa"   : length 7
            // - "bbcaaddeeeeeffgh"     -> "bbcaa"     : length 5
            // - "caaddeeeeeffgh"       -> "caadd"     : length 5
            // - "aaddeeeeeffgh"        -> "aaddeeeee" : length 9
            // - "ddeeeeeffgh"          -> "ddeeeeeff" : length 9
            // - "eeeeeffgh"            -> "eeeeeffg"  : length 8
            // - "ffgh"                 -> "ffgh"      : length 4
            // - "gh"                   -> "gh"        : length 2
            // - "h"                    -> "h"         : length 1
            // The first and final characters are read once whereas the "center" characters are read k times. But even assuming that every character is read k times, the time complexity is O(nk), which is acceptable because k<=26. It also keeps the algorithm extremely simple
            // If k wasn't limited, we would have to find a more efficient algorithm, trading space to reach O(n) time
            int longest = 0;
            char previous = '-';
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current != previous)
                {
                    longest = Math.Max(longest, _getLongestKStartLength(input.Substring(i), k));
                }
            }

            return longest;
        }

        // Gets the length of the longest KGood substring starting at the beginning of the given input
        private int _getLongestKStartLength(string input, int k)
        {
            HashSet<char> letters = new HashSet<char>(); // keeps track of the "known" letters - we use a set for constant lookup time

            // Add every new character to the set unless it leads to the set containing more than K characters
            // When that happens, we have reached the maximum KGood substring
            int index = -1;
            while (++index < input.Length)
            {
                char current = input[index];
                if (!letters.Contains(current))
                {
                    if (letters.Count == k) break;

                    letters.Add(current);
                }
            }

            return index;
        }
    }
}