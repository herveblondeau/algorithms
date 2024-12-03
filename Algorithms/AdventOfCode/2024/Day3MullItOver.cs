using System.Linq;
using System.Text.RegularExpressions;

namespace Algorithms.AdventOfCode._2024;

public class Day3MullItOver
{
    public int CalculateMulSum(string input)
    {
        Regex regex = new Regex(@"mul\((\d+),(\d+)\)");
        var matches = regex.Matches(input);
        return matches.Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value));
    }

    public int CalculateMulSumWithDosAndDonts(string input)
    {
        // Greedy removal of all "don't()... instances"
        var inputWithoutDonts = Regex.Replace(input, @"don\'t\(\).+?(?=do)", string.Empty);
        inputWithoutDonts = Regex.Replace(inputWithoutDonts, @"don\'t\(\).+?$", string.Empty);
        return CalculateMulSum(inputWithoutDonts);
    }
}
