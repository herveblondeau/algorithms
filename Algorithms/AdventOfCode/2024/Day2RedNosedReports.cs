using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day2RedNosedReports
{
    public int CalculateNbSafeReports(List<List<int>> reports)
    {
        return reports.Count(_isSafe);
    }

    private bool _isSafe(List<int> report)
    {
        // Reports with one or no elements are obviously safe
        if (report.Count <= 1)
        {
            return true;
        }

        bool isAscending = report[1] > report[0];

        for (int i = 0; i < report.Count - 1; i++)
        {
            bool currentIsAscending = report[i + 1] > report[i];
            if (currentIsAscending ^ isAscending)
            {
                return false;
            }

            int differenceWithNextLevel = Math.Abs(report[i + 1] - report[i]);
            if (differenceWithNextLevel < 1 || differenceWithNextLevel > 3)
            {
                return false;
            }
        }

        return true;
    }
}
