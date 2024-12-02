using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day1HistorianHysteria
{
    public int CalculateDistance(List<int> list1, List<int> list2)
    {
        return list1.Order().Zip(list2.Order(), ((x, y) => Math.Abs(x - y))).Sum();
    }
}
