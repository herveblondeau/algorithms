using System.Collections.Generic;
using System.Linq;

namespace ByTheme.Combinations
{
    public class Combinations
    {
        // Returns all the combinations of k elements in the supplied values
        public static IEnumerable<int[]> GetCombinations(int[] values, int k)
        {
            List<int[]> combinations = new List<int[]>();

            int[] currentIndexes = new int[k];
            for (int i = 0; i < k; i++)
            {
                currentIndexes[i] = i;
            }
            combinations.Add(currentIndexes.Select(i => values[i]).ToArray());

            currentIndexes = _nextIndexes(currentIndexes, values);
            while (currentIndexes != null)
            {
                combinations.Add(currentIndexes.Select(i => values[i]).ToArray());
                currentIndexes = _nextIndexes(currentIndexes, values);
            }

            return combinations;
        }

        // Find the next indexes
        private static int[] _nextIndexes(int[] currentIndexes, int[] values)
        {
            int[] nextIndexes = new int[currentIndexes.Length];
            for (int i = 0; i < currentIndexes.Length; i++)
            {
                nextIndexes[i] = currentIndexes[i];
            }

            int n = values.Length - 1;
            int k = nextIndexes.Length - 1;

            bool numberChanged = false;
            for (int i = k; !numberChanged && i > -1; i--)
            {
                if (nextIndexes[i] < n - (k - i))
                {
                    nextIndexes[i]++;
                    for (int j = i + 1; j <= k; j++)
                    {
                        nextIndexes[j] = nextIndexes[j - 1] + 1;
                    }
                    numberChanged = true;
                }
            }

            return numberChanged ? nextIndexes : null;
        }
    }
}