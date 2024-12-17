// https://adventofcode.com/2024/day/13

using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day13ClawContraption
{
    private const int PressCostButtonA = 3;
    private const int PressCostButtonB = 1;

    #region Part 1

    private const int MaxNbPresses = 100;

    public int CalculateNbTokens(List<((int DeltaX, int DeltaY) ButtonA, (int DeltaX, int DeltaY) ButtonB, (long X, long Y) Prize)> machines)
    {
        return machines.Sum(m => _calculateNbTokens((m.ButtonA.DeltaX, m.ButtonA.DeltaY), (m.ButtonB.DeltaX, m.ButtonB.DeltaY), (m.Prize.X, m.Prize.Y)) ?? 0);
    }

    // Just a dumb, straightforward and quick implementation
    private int? _calculateNbTokens((int DeltaX, int DeltaY) ButtonA, (int DeltaX, int DeltaY) ButtonB, (long X, long Y) Prize)
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

    #region Part 2

    public long CalculateNbTokensEquation(List<((int DeltaX, int DeltaY) ButtonA, (int DeltaX, int DeltaY) ButtonB, (long X, long Y) Prize)> machines)
    {
        return machines.Sum(m => _calculateNbTokensEquation((m.ButtonA.DeltaX, m.ButtonA.DeltaY), (m.ButtonB.DeltaX, m.ButtonB.DeltaY), (m.Prize.X, m.Prize.Y)) ?? 0);
    }

    private long? _calculateNbTokensEquation((int DeltaX, int DeltaY) ButtonA, (int DeltaX, int DeltaY) ButtonB, (long X, long Y) Prize)
    {
        // Numbers in part 2 are way too large to iterate over. However we can notice that the problem consists in solving a 2-variable equation, which makes it trivial

        long numeratorA = (Prize.X + 10000000000000) * ButtonB.DeltaY - (Prize.Y + 10000000000000) * ButtonB.DeltaX;
        long denominatorA = ButtonA.DeltaX * ButtonB.DeltaY - ButtonA.DeltaY * ButtonB.DeltaX;
        long numeratorB = (Prize.X + 10000000000000) * ButtonA.DeltaY - (Prize.Y + 10000000000000) * ButtonA.DeltaX;
        long denominatorB = ButtonB.DeltaX * ButtonA.DeltaY - ButtonB.DeltaY * ButtonA.DeltaX;

        if (numeratorA % denominatorA != 0 || numeratorB % denominatorB != 0)
        {
            return null;
        }

        var nbPressesA = numeratorA / denominatorA;
        var nbPressesB = numeratorB / denominatorB;

        return nbPressesA * PressCostButtonA + nbPressesB * PressCostButtonB;
    }

    #endregion
}
