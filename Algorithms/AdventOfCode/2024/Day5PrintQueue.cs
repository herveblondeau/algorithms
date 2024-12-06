using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day5PrintQueue
{
    public int CalculateCorrectlyOrderedMiddlePageNumbers(List<(int From, int To)> paths, List<int[]> updates)
    {
        // Based on the description, we "just" need to check that each element of an update is:
        // - on the right side of an order with each element that preceeds it
        // - on the left side of an order with each element that follows it
        // We therefore build two dictionaries to represent the paths going in and out of every element
        Dictionary<int, HashSet<int>> pathsOut = new();
        Dictionary<int, HashSet<int>> pathsIn = new();
        foreach (var path in paths)
        {
            if (!pathsOut.ContainsKey(path.From))
            {
                pathsOut.Add(path.From, new());
            }
            pathsOut[path.From].Add(path.To);

            if (!pathsIn.ContainsKey(path.To))
            {
                pathsIn.Add(path.To, new());
            }
            pathsIn[path.To].Add(path.From);
        }

        int middlePageNumbersSum = 0;

        foreach (var update in updates)
        {
            bool isOrdered = true;
            for (int i = 0; i < update.Length; i++)
            {
                // Check that the current element has a path coming from each preceeding element
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (!pathsIn.ContainsKey(update[i]) || !pathsIn[update[i]].Contains(update[j]))
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

                // Check that the current element has a path going to each following element
                if (i < update.Length - 1)
                {
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
            }

            if (isOrdered)
            {
                middlePageNumbersSum += update[(update.Length - 1) / 2];
            }
        }

        return middlePageNumbersSum;
    }
}
