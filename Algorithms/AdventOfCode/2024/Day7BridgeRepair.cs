// https://adventofcode.com/2024/day/7

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day7BridgeRepair
{
    #region Part 1

    public long CalculateCalibrationResult(Dictionary<long, int[]> equations, byte nbOperators)
    {
        return equations.Where(e => _isSolvable(e.Key, e.Value, nbOperators)).Sum(e => e.Key);
    }

    private bool _isSolvable(long total, int[] numbers, int nbOperators)
    {
        Operator[] operators = new Operator[numbers.Length - 1];
        for (int i = 0; i < operators.Length; i++)
        {
            operators[i] = Operator.Multiply;
        }

        bool isSolved = false;
        bool allOperatorsTested = false;
        while (!isSolved && !allOperatorsTested)
        {
            isSolved = _isSolved(total, numbers, operators);
            allOperatorsTested = !_incrementOperators(operators, nbOperators);
        }

        return isSolved;
    }

    private bool _isSolved(long total, int[] numbers, Operator[] operators)
    {
        long currentTotal = numbers[0];
        if (currentTotal > total)
        {
            return false;
        }
        else if (currentTotal == total)
        {
            return true;
        }

        for (int i = 1; i < numbers.Length; i++)
        {
            if (operators[i - 1] == Operator.Multiply)
            {
                currentTotal *= numbers[i];
            }
            else if (operators[i - 1] == Operator.Add)
            {
                currentTotal += numbers[i];
            }
            else
            {
                int nbDigitsCurrentNumber = (int)Math.Log10(numbers[i]) + 1;
                currentTotal = currentTotal * (int)Math.Pow(10, nbDigitsCurrentNumber) + numbers[i];
            }

            if (currentTotal > total)
            {
                return false;
            }
            else if (currentTotal == total)
            {
                return true;
            }
        }

        return false;
    }

    private bool _incrementOperators(Operator[] operators, int nbOperators)
    {
        if (operators.All(o => o == Operator.Add))
        {
            return false;
        }

        int lastIncrementableOperatorIndex = -1;
        for (int i = operators.Length - 1; i >= 0; i--)
        {
            if (operators[i] == Operator.Multiply || operators[i] == Operator.Concatenate)
            {
                lastIncrementableOperatorIndex = i;
                break;
            }
        }

        operators[lastIncrementableOperatorIndex] = operators[lastIncrementableOperatorIndex] == Operator.Multiply && nbOperators == 3 ? Operator.Concatenate : Operator.Add;
        for (int i = lastIncrementableOperatorIndex + 1; i < operators.Length; i++)
        {
            operators[i] = Operator.Multiply;
        }

        return true;
    }

    #endregion

    private enum Operator
    {
        Multiply,
        Concatenate,
        Add,
    }
}
