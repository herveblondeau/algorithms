// https://adventofcode.com/2024/day/11

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day11PlutonianPebbles
{
    #region Part 1

    public long CalculateNumberOfStonesWithRegularLoop(List<long> stones, int nbBlinks)
    {
        for (int i = 0; i < nbBlinks; i++)
        {
            stones = _blink(stones);
        }
        return stones.Count;
    }

    private List<long> _blink(List<long> stones)
    {
        List<long> stonesAfterBlink = new();

        foreach (var stone in stones)
        {
            if (stone == 0)
            {
                stonesAfterBlink.Add(1);
            }
            else if (_hasEvenDigits(stone))
            {
                var splitStone = _split(stone);
                stonesAfterBlink.Add(splitStone.LeftHalf);
                stonesAfterBlink.Add(splitStone.RightHalf);
            }
            else
            {
                stonesAfterBlink.Add(stone * 2024);
            }
        }

        return stonesAfterBlink;
    }

    #endregion

    #region Part 2

    public long CalculateNumberOfStonesWithMemoization(List<long> stones, int nbBlinks)
    {
        Dictionary<(long, int), long> nbStonesByStoneAndNbBlinks = new();

        long nbTotal = 0;
        for (int i = 0; i < stones.Count; i++)
        {
            nbTotal += _getNbStones(stones[i], nbBlinks, nbStonesByStoneAndNbBlinks);
        }
        return nbTotal;
    }

    private long _getNbStones(long stone, int nbBlinks, Dictionary<(long, int), long> nbStonesByStoneAndNbBlinks)
    {
        long nbStones = 0;

        // Exit conditions
        if (nbBlinks == 0)
        {
            return 1;
        }

        if (nbStonesByStoneAndNbBlinks.ContainsKey((stone, nbBlinks)))
        {
            return nbStonesByStoneAndNbBlinks[(stone, nbBlinks)];
        }

        // Split and recursively add the subresults
        var nextStones = _blink(stone);
        foreach (var nextStone in nextStones)
        {
            var currentNbStones = _getNbStones(nextStone, nbBlinks - 1, nbStonesByStoneAndNbBlinks);
            if (!nbStonesByStoneAndNbBlinks.ContainsKey((nextStone, nbBlinks - 1)))
            {
                nbStonesByStoneAndNbBlinks.Add((nextStone, nbBlinks - 1), currentNbStones);
            }
            nbStones += currentNbStones;
        }

        return nbStones;
    }

    private List<long> _blink(long stone)
    {
        if (stone == 0)
        {
            return [1];
        }
        else if (_hasEvenDigits(stone))
        {
            var splitStone = _split(stone);
            return [splitStone.LeftHalf, splitStone.RightHalf];
        }
        else
        {
            return [stone * 2024];
        }
    }

    #endregion

    #region Common

    private bool _hasEvenDigits(long n)
    {
        var nbDigits = (int)Math.Log10(n / 10 * 10) + 1;
        return nbDigits % 2 == 0;
    }

    private (long LeftHalf, long RightHalf) _split(long n)
    {
        List<long> digits = new();
        while (n > 0)
        {
            digits.Insert(0, n % 10);
            n /= 10;
        }

        int midPoint = digits.Count / 2;
        long leftHalf = _toNumber(digits.Take(midPoint).ToList());
        long rightHalf = _toNumber(digits.Skip(midPoint).ToList() );

        return (leftHalf, rightHalf);
    }

    private long _toNumber(List<long> digits)
    {
        long sum = 0;

        for (int i = 0; i < digits.Count; i++)
        {
            sum += digits[i] * (long)Math.Pow(10, digits.Count - i - 1);
        }

        return sum;
    }

    #endregion
}
