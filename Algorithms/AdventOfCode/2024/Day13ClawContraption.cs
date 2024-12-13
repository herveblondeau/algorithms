// https://adventofcode.com/2024/day/13

using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day13ClawContraption
{
    private const int PressCostButtonA = 3;
    private const int PressCostButtonB = 1;
    private const int MaxNbPresses = 100;

    #region Part 1

    public int CalculateNbTokens(List<((int DeltaX, int DeltaY) ButtonA, (int DeltaX, int DeltaY) ButtonB, (int X, int Y) Prize)> machines)
    {
        return machines.Sum(m => _calculateNbTokens((m.ButtonA.DeltaX, m.ButtonA.DeltaY), (m.ButtonB.DeltaX, m.ButtonB.DeltaY), (m.Prize.X, m.Prize.Y)) ?? 0);
    }

    private int? _calculateNbTokens((int DeltaX, int DeltaY) ButtonA, (int DeltaX, int DeltaY) ButtonB, (int X, int Y) Prize)
    {
        bool solutionFound = false;
        int minNbTokens = int.MaxValue;

        for (int nbPressesA = 0; nbPressesA <= MaxNbPresses; nbPressesA++)
        {
            for (int nbPressesB = 0; nbPressesB <= MaxNbPresses; nbPressesB++)
            {
                if ((nbPressesA * ButtonA.DeltaX) + (nbPressesB * ButtonB.DeltaX) == Prize.X
                    && (nbPressesA * ButtonA.DeltaY) + (nbPressesB * ButtonB.DeltaY) == Prize.Y)
                    {
                        solutionFound = true;
                        int currentNbTokens = nbPressesA * PressCostButtonA + nbPressesB * PressCostButtonB;
                        if (currentNbTokens < minNbTokens)
                        {
                            minNbTokens = currentNbTokens;
                        }
                    }
            }
        }

        return solutionFound ? minNbTokens : null;
    }

    #endregion
}
