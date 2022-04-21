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

        public Dictionary<string, int> GetNbAnimalsPerSpecies(string[] species, Dictionary<string, int> bodyParts)
        {
            /*
             * This problem is basically a system of linear equations: one equation per body part and one variable per animal
             * Since there are always the same number of species and body parts, there are as many equations as variables
             * 
             * We build a 2D array to represent the equations. If n is the number of species/body parts, there are n rows and n+1 columns
             * - one row per body part
             * - each row contains one column per species, plus one for the total
             * 
             * For instance, if there are:
             * - rabbits, chickens and cows
             * - 9 heads, 6 horns, 8 wings
             * then the equations are modeled as:
             * [1, 1, 1, 9] (1 * number of rabbits + 1 * number of chickens + 1 * number of cows = number of heads)
             * [0, 0, 2, 6] (2 * number of cows = number of horns)
             * [0, 2, 0, 8] (2 * number of chickens = number of wings)
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


        // Solving is done by recursion. This is acceptable performance-wise because, in this particular problem, we know that there are no more than 5 equations with 5 variables (so recursion never becomes too deep), and that there is always a single solution (so no need to check for lack of solution or infinite solutions)
        private int[] _solve(int[][] equations)
        {
            int[] solutions = new int[equations.Length];

            // Exit condition: when there is only equation
            if (equations.Length == 1)
            {
                // The solution is the total divided by the first and only coefficient
                return new int[] { equations[0][1] / equations[0][0] };
            }

            // Recursion
            // - eliminate the first variable and build a subsystem with 1 less variable
            int[][] subEquations = _buildSubSystemWithoutFirstVariable(equations);

            // - recursively solve the subsystem
            int[] subSolutions = _solve(subEquations);

            // - solve for the first variable
            var firstVariable = _solveFirstVariable(equations, subSolutions);

            // Combine the first variable and the recursively computed subsystem solutions
            solutions[0] = firstVariable;
            for (int i = 1; i <= solutions.Length - 1; i++)
            {
                solutions[i] = subSolutions[i - 1];
            }

            return solutions;
        }

        private int[][] _buildSubSystemWithoutFirstVariable(int[][] equations)
        {
            // This consists in combining the equations by pairs, eliminating the first variable for each pair and resulting with a subsystem one less equation with one less variable
            // For instance, if we have [2 1 4 10] and [3 2 2 18], we multiply the first equation by 3, the second by 2 and then subtract, we obtain [0 -1 8 -6], i.e. [-1 8 -6] for the subsystem
            // Note that equations that don't contain the first variable cannot and do not need to be combined. They can be used as is. For instance, [0 2 0 8] is directly used as [2 0 8] in the subsystem
            // There are many ways to select pairs of equations. Here we start with the first and last, then move towards the center

            int[][] subEquations = new int[equations.Length - 1][];
            int subEquationIndex = 0;
            int equationIndex1 = 0;
            int equationIndex2 = equations.Length - 1;
            while (equationIndex1 < equationIndex2)
            {
                // Equation 1 doesn't contain the first variable => include it as is
                if (equations[equationIndex1][0] == 0)
                {
                    subEquations[subEquationIndex] = equations[equationIndex1]
                        .Skip(1)
                        .ToArray();

                    equationIndex1++;
                }
                // Equation 2 doesn't contain the first variable => include it as is
                else if (equations[equationIndex2][0] == 0)
                {
                    subEquations[subEquationIndex] = equations[equationIndex2]
                        .Skip(1)
                        .ToArray();

                    equationIndex2--;
                }
                else
                {
                    // Both equations contain the first variable => combine them to eliminate the first variable
                    subEquations[subEquationIndex] = equations[equationIndex1]
                        .Zip(equations[equationIndex2], (x, y) => x * equations[equationIndex2][0] - y * equations[equationIndex1][0])
                        .Skip(1)
                        .ToArray();

                    equationIndex1++;
                }

                subEquationIndex++;
            }

            return subEquations;
        }

        private int _solveFirstVariable(int[][] equations, int[] subSolutions)
        {
            // We can use any equation as long as it contains the first variable
            // (for instance any equation ax + by + cz + ... = d where a != 0)
            // There is always such an equation, otherwise the system would be unsolvable
            var firstVariableEquation = equations.Where(e => e[0] != 0).First();

            // Compute the first variable using the total and the subsolutions
            // For instance, with the equation ax + by + cz + ... = d, then x = (d - ... - cz - by) / a
            var firstVariable = firstVariableEquation[firstVariableEquation.Length - 1];
            for (int i = firstVariableEquation.Length - 2; i > 0; i--)
            {
                firstVariable -= firstVariableEquation[i] * subSolutions[i - 1];
            }
            firstVariable /= firstVariableEquation[0];

            return firstVariable;
        }
    }
}
