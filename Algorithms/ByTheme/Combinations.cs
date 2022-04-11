using System.Collections.Generic;
using System.Linq;

namespace ByTheme.Combinations
{
    public class Combinations
    {
        // Returns all the combinations of k elements in the supplied values, i.e. C(n, k)
        public static IEnumerable<int[]> GetCombinations(int[] values, int k)
        {
            List<int[]> combinations = new List<int[]>();
            int n = values.Length;

            // Initialize the indexes and add the first combination
            int[] currentIndexes = new int[k];
            for (int i = 0; i < k; i++)
            {
                currentIndexes[i] = i;
            }
            combinations.Add(currentIndexes.Select(i => values[i]).ToArray());

            // Iteratively build the next indexes and add the corresponding combinations
            currentIndexes = _nextIndexes(currentIndexes, n);
            while (currentIndexes != null)
            {
                combinations.Add(currentIndexes.Select(i => values[i]).ToArray());
                currentIndexes = _nextIndexes(currentIndexes, n);
            }

            return combinations;
        }

        // Find the next indexes
        /*
         * From a given set of indexes and the value of n, we can compute the next set of indexes.
         * 
         * For instance, here is the sequence of index combinations for C(6, 3):
         * 0 1 2 3 4 5
         * O O O       -> 0,1,2
         * O O   O     -> 0,1,3
         * O O     O   -> 0,1,4
         * O O       O -> 0,1,5
         * O   O O     -> 0,2,3
         * O   O   O   -> 0,2,4
         * O   O     O -> 0,2,5
         * O     O O   -> 0,3,4
         * O     O   O -> 0,3,5
         * O       O O -> 0,4,5
         *   O O O     -> 1,2,3
         *   O O   O   -> 1,2,4
         *   O O     O -> 1,2,5
         *   O   O O   -> 1,3,4
         *   O   O   O -> 1,3,5
         *   O     O O -> 1,4,5
         *     O O O   -> 2,3,4
         *     O O   O -> 2,3,5
         *     O   O O -> 2,4,5
         *       O O O -> 3,4,5
         * 
         * We start by trying to increment the rightmost index. If it already contains the maximum possible value, we then try incrementing its left neighbor. If that neighbor is maxed out, then we try its left neighbord, and so on. We return null if all indexes are maxed out.
         * Note: the maximum value depends on the index position. In the above example, the rightmost index can go up to 5, the center index up to 4, and the left index up to 3. This is because 
         */
        private static int[] _nextIndexes(int[] currentIndexes, int n)
        {
            // Instantiate an array to hold the next indexes
            int[] nextIndexes = new int[currentIndexes.Length];
            for (int i = 0; i < currentIndexes.Length; i++)
            {
                nextIndexes[i] = currentIndexes[i];
            }

            int k = nextIndexes.Length;

            bool indexHasChanged = false;
            for (int i = k - 1; !indexHasChanged && i >= 0; i--)
            {
                // If the current index can be incremented
                if (nextIndexes[i] < n - k + i) // as stated above, the maximum allowed value for the current index depends on the index position. It is n-1 for the rightmost index, then n-2 and so on until n-k
                {
                    // Increment the current index
                    nextIndexes[i]++;

                    // Then reset its right neighbors
                    // This happens for instance in the following transitions:
                    // // - 0,1,5 -> 0,2,3 (incrementing from 1 to 2 requires resetting 5 to 3)
                    // // - 1,4,5 -> 2,3,4 (incrementing from 1 to 2 requires resetting 4 and 5 to 3 and 4)
                    for (int j = i + 1; j < k; j++)
                    {
                        nextIndexes[j] = nextIndexes[j - 1] + 1;
                    }

                    indexHasChanged = true;
                }
            }

            return indexHasChanged ? nextIndexes : null;
        }
    }
}