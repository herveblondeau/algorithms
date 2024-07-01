// https://www.codingame.com/training/hard/levenshtein-distance
using System;
using System.Collections.Generic;

namespace Codingame.LevenshteinDistance
{
    public class LevenshteinDistance
    {
        /**
         * The textbook algorithm uses dynamic programming, by computing the distance between longer and longer substrings of the two words
         * The basic idea is that, if we want to compute the distance between "OVAL" and "RADIO" and we already know the distances between all shortened versions of these words, we can either:
         * - start from "OVAL"->"RADI" and add "O" to "RADIO"
         * - start from "OVA"->"RADIO" and add "L" to "OVAL" ; note: in the "official" explanation, this is seen as a letter dropped, which better reflects the reality but is less intuitive in terms of the algorithm
         * - start from "OVA"->"RADI" and add a "L"->"O" conversion at the end ; note: a conversion is not even necessary when the letters are the same (for instance when going from "TES/TEX" to "TEST/TEXT")
         * The "OVAL"->"RADIO" distance is the minimum of these 3 options.
         * 
         * The algorithm builds a matrix, starting from the distance from an empty string to another empty string, which is zero, then computing the distances cell by cell, taking the minimum distance of the three options listed above
         */
        public int GetDistance(string source, string target)
        {
            int distance = 0;

            // 1) Same length -> straightforward O(n) time, O(1) space character by character comparison
            if (source.Length == target.Length)
            {

                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] != target[i]) distance++;
                }
                return distance;
            }

            // 2) Different length -> textbook dynamic programming algorithm (O(nm) time and space)
            // Initialize the matrix
            int[][] distances = new int[source.Length + 1][];
            for (int i = 0; i <= source.Length; i++)
            {
                distances[i] = new int[target.Length + 1];
            }

            // Fill the first row and column, which basically give the distances from an empty string to the source and target words
            for (int i = 0; i <= source.Length; i++)
            {
                distances[i][0] = i;
            }
            for (int i = 0; i <= target.Length; i++)
            {
                distances[0][i] = i;
            }

            // Compute the other cells
            for (int i = 1; i <= source.Length; i++)
            {
                for (int j = 1; j <= target.Length; j++)
                {
                    // Letter add/drop
                    distances[i][j] = Math.Min(distances[i - 1][j] + 1, distances[i][j - 1] + 1);

                    // Conversion
                    int adjustment = source[i - 1] != target[j - 1] ? 1 : 0;
                    distances[i][j] = Math.Min(distances[i][j], distances[i - 1][j - 1] + adjustment);
                }
            }

            // The requested distance is in the bottom right cell
            return distances[source.Length][target.Length];
        }
    }
}