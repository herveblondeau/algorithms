// https://www.codingame.com/training/expert/the-barnyard

using System.Collections.Generic;
using System.Linq;

namespace Codingame.TheBarnyard;

public class Barnyard
{
    private static readonly Dictionary<(string, string), int> _partCountsPerAnimal = new Dictionary<(string, string), int>
    {
        { ("Rabbits", "Heads"),  1 },
        { ("Rabbits", "Eyes"),   2 },
        { ("Rabbits", "Horns"),  0 },
        { ("Rabbits", "Wings"),  0 },
        { ("Rabbits", "Legs"),   4 },
        { ("Chickens", "Heads"), 1 },
        { ("Chickens", "Eyes"),  2 },
        { ("Chickens", "Horns"), 0 },
        { ("Chickens", "Wings"), 2 },
        { ("Chickens", "Legs"),  2 },
        { ("Cows", "Heads"),     1 },
        { ("Cows", "Eyes"),      2 },
        { ("Cows", "Horns"),     2 },
        { ("Cows", "Wings"),     0 },
        { ("Cows", "Legs"),      4 },
        { ("Pegasi", "Heads"),   1 },
        { ("Pegasi", "Eyes"),    2 },
        { ("Pegasi", "Horns"),   0 },
        { ("Pegasi", "Wings"),   2 },
        { ("Pegasi", "Legs"),    4 },
        { ("Demons", "Heads"),   1 },
        { ("Demons", "Eyes"),    4 },
        { ("Demons", "Horns"),   4 },
        { ("Demons", "Wings"),   2 },
        { ("Demons", "Legs"),    4 },
    };

    public Dictionary<string, int> GetAnimalCounts(string[] animals, Dictionary<string, int> bodyParts)
    {
        // This is basically a n-equation system
        // It is greatly simplified because we know that there are no more than 5 variables, and that the system always has exactly one solution

        int[][] equations = new int[animals.Length][];
        int index = 0;
        foreach (var bodyPart in bodyParts)
        {
            equations[index] = new int[animals.Length + 1];
            for (int i = 0; i < animals.Length; i++)
            {
                equations[index][i] = _partCountsPerAnimal[(animals[i], bodyPart.Key)];
            }
            equations[index][animals.Length] = bodyPart.Value;

            index++;
        }

        int[] results = _solve(equations);

        var nbAnimals = new Dictionary<string, int>();
        for (int i = 0; i < animals.Length; i++)
        {
            nbAnimals.Add(animals[i], results[i]);
        }

        return nbAnimals;
    }

    private int[] _solve(int[][] equations)
    {
        int[] results = new int[equations.Length];

        // Exit condition
        if (equations.Length == 1)
        {
            return new int[] { equations[0][1] / equations[0][0] };
        }

        // Recursion
        // - build subsystem
        int[][] subEquations = new int[equations.Length - 1][];
        int index = 0;
        int index1 = 0;
        int index2 = equations.Length - 1;
        while (index1 < index2)
        {
            if (equations[index1][0] == 0)
            {
                subEquations[index] = equations[index1]
                    .Skip(1)
                    .ToArray();
                index1++;
            }
            else if (equations[index2][0] == 0)
            {
                subEquations[index] = equations[index2]
                    .Skip(1)
                    .ToArray();
                index2--;
            }
            else
            {
                subEquations[index] = equations[index1]
                    .Zip(equations[index2], (x, y) => x * equations[index2][0] - y * equations[index1][0])
                    .Skip(1)
                    .ToArray();

                index1++;
            }

            index++;
        }

        // - solve subsystem
        int[] subSolutions = _solve(subEquations);

        // - use first equation to solve first variable
        var firstEquation = equations.Where(e => e[0] != 0).First();
        var firstVariable = firstEquation[firstEquation.Length - 1];
        for (int i = firstEquation.Length - 2; i > 0; i--)
        {
            firstVariable -= firstEquation[i] * subSolutions[i - 1];
        }
        firstVariable /= firstEquation[0];

        results[0] = firstVariable;
        for (int i = 1; i <= results.Length - 1; i++)
        {
            results[i] = subSolutions[i - 1];
        }

        return results;
    }
}
