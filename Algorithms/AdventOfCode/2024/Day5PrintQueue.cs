using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day5PrintQueue
{
    public int CalculateCorrectlyOrderedMiddlePageNumbers(List<(int From, int To)> paths, List<int[]> updates)
    {
        // Based on the description, we just need to check that each element of an update is:
        // - on the right side of an order with each element that preceeds it
        // - on the left side of an order with each element that follows it
        // In practice, only one of these conditions must be checked, since it implies the other, so we arbitrarily just check the second one
        Dictionary<int, HashSet<int>> pathsOut = new();
        foreach (var path in paths)
        {
            if (!pathsOut.ContainsKey(path.From))
            {
                pathsOut.Add(path.From, new());
            }
            pathsOut[path.From].Add(path.To);
        }

        int middlePageNumbersSum = 0;

        foreach (var update in updates)
        {
            bool isOrdered = true;
            for (int i = 0; i < update.Length - 1; i++)
            {
                // Check that the current element has a path going to each following element
                for (int j = i + 1; j < update.Length; j++)
                {
                    if (!pathsOut.ContainsKey(update[i]) || !pathsOut[update[i]].Contains(update[j]))
                    {
                        isOrdered = false;
                        break;
                    }
                }
                if (!isOrdered)
                {
                    break;
                }
            }

            if (isOrdered)
            {
                middlePageNumbersSum += update[(update.Length - 1) / 2];
            }
        }

        return middlePageNumbersSum;
    }

    public int FixOrdersAndCalculateMiddlePageNumbers(List<(int From, int To)> paths, List<int[]> updates)
    {
        // See comments in previous method
        Dictionary<int, HashSet<int>> pathsOut = new();
        foreach (var path in paths)
        {
            if (!pathsOut.ContainsKey(path.From))
            {
                pathsOut.Add(path.From, new());
            }
            pathsOut[path.From].Add(path.To);
        }

        int middlePageNumbersSum = 0;

        foreach (var update in updates)
        {
            bool isFixed = false;
            for (int i = 0; i < update.Length - 1; i++)
            {
                // Here, whenever we find a following element that should be placed before the current one, we swap them and replay the loop from the current index
                for (int j = i + 1; j < update.Length; j++)
                {
                    if (!pathsOut.ContainsKey(update[i]) || !pathsOut[update[i]].Contains(update[j]))
                    {
                        (update[i], update[j]) = (update[j], update[i]);
                        isFixed = true;
                        i -= 1;
                        break;
                    }
                }
            }

            if (isFixed)
            {
                middlePageNumbersSum += update[(update.Length - 1) / 2];
            }
        }

        return middlePageNumbersSum;
    }
}
