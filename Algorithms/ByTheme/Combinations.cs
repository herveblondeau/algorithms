using System.Collections.Generic;

namespace ByTheme.Combinations
{
    public class Combinations
    {
        public static IEnumerable<int[]> GetCombinations(int[] values, int k)
        {
            List<int[]> combinations = new List<int[]>();

            int[] currentCombination = new int[k];
            for (int i = 0; i < k; i++)
            {
                //currentCombination[i] = values[i];
                currentCombination[i] = i;
            }
            combinations.Add(currentCombination);

            currentCombination = _nextCombination(currentCombination, values);
            while (currentCombination != null)
            {
                combinations.Add(currentCombination);
                currentCombination = _nextCombination(currentCombination, values);
            }

            return combinations;
        }

        private static int[] _nextCombination(int[] currentCombination, int[] values)
        {
            int[] nextCombination = new int[currentCombination.Length];
            for (int i = 0; i < currentCombination.Length; i++)
            {
                nextCombination[i] = currentCombination[i];
            }

            int n = values.Length - 1;
            int k = nextCombination.Length - 1;

            bool numberChanged = false;
            for (int i = k; !numberChanged && i > -1; i--)
            {
                if (nextCombination[i] < n - (k - i))
                {
                    nextCombination[i]++;
                    for (int j = i + 1; j <= k; j++)
                    {
                        nextCombination[j] = nextCombination[j - 1] + 1;
                    }
                    numberChanged = true;
                }
            }

            return numberChanged ? nextCombination : null;
        }
    }
}