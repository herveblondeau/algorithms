// https://www.codingame.com/training/expert/the-barnyard

using System.Collections.Generic;
using System.Linq;

namespace Codingame.Barnyard
{
    public class Barnyard
    {
        private static readonly Dictionary<(string, string), int> _nbBodyPartsPerSpecies = new Dictionary<(string, string), int>
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

        public Dictionary<string, int> GetSpeciesCounts(string[] species, Dictionary<string, int> bodyParts)
        {
            /*
             * This problem is basically a system of linear equations: one equation per body part and one variable per animal
             * Since there are always the same number of species and body parts, there are also as many equations as variables
             * 
             * We build a 2D array to represent the equations. If n is the number of species/body parts, there are n rows and n+1 columns
             * - one row per body part
             * - one column per species, plus one for the total
             * 
             * For instance, if there are:
             * - rabbits, chickens and cows
             * - 9 heads, 6 horns, 8 wings
             * then the equations are modeled as:
             * [1, 1, 1, 9] (heads)
             * [0, 0, 2, 6] (horns)
             * [0, 2, 0, 8] (wings)
             */
            // Build the system
            int[][] equations = new int[species.Length][];
            int index = 0;
            foreach (var bodyPart in bodyParts)
            {
                equations[index] = new int[species.Length + 1];
                for (int i = 0; i < species.Length; i++)
                {
                    equations[index][i] = _nbBodyPartsPerSpecies[(species[i], bodyPart.Key)];
                }
                equations[index][species.Length] = bodyPart.Value;

                index++;
            }

            // Solve the system
            int[] solutions = _solve(equations);

            // Associate the solutions to the species
            var nbSpecies = new Dictionary<string, int>();
            for (int i = 0; i < species.Length; i++)
            {
                nbSpecies.Add(species[i], solutions[i]);
            }

            return nbSpecies;
        }


        // Solving is done by recursion
        // This is acceptable performance-wise because, in this problem, we know that there are no more than 5 equations with 5 variables, and that there is always a single solution
        private int[] _solve(int[][] equations)
        {
            int[] results = new int[equations.Length];

            // Exit condition
            if (equations.Length == 1)
            {
                return new int[] { equations[0][1] / equations[0][0] };
            }

            // Recursion
            // - build the subsystem
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

            // - solve the subsystem
            int[] subSolutions = _solve(subEquations);

            // - use one of the equations to solve the first variable
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
}
