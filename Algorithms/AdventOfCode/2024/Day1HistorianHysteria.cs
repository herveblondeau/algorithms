// https://adventofcode.com/2024/day/1

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day1HistorianHysteria
{
    public int CalculateDistance(List<int> list1, List<int> list2)
    {
        return list1.Order().Zip(list2.Order(), (x, y) => Math.Abs(x - y)).Sum();
    }

    public int CalculateSimilarity(List<int> list1, List<int> list2)
    {
        Dictionary<int, int> list2Occurrences = list2
            .GroupBy(n => n)
            .ToDictionary(g => g.Key, g => g.Count());

        return list1.Sum(n => n * (list2Occurrences.ContainsKey(n) ? list2Occurrences[n] : 0));
    }
}
