// https://adventofcode.com/2024/day/2

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
            // The sequence must increase or decrease, but not stay the same
            if (report[i + 1] == report[i])
            {
                return false;
            }

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

    public int CalculateNbPseudoSafeReports(List<List<int>> reports)
    {
        return reports.Count(_isPseudoSafe);
    }

    private bool _isPseudoSafe(List<int> report)
    {
        // Reports with one or no elements are obviously safe
        // Reports with two elements are always pseudo safe since we can remove one element to get a safe report
        if (report.Count <= 2)
        {
            return true;
        }

        if (_isSafe(report))
        {
            return true;
        }

        // If the report is not safe, try all sub reports obtained by removing one element
        for (int i = 0; i < report.Count; i++)
        {
            if (_isSafe(report.Where((item, index) => index != i).ToList()))
            {
                return true;
            }
        }

        return false;
    }
}
