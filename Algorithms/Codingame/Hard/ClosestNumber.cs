// https://www.codingame.com/training/hard/closest-number

using System.Collections.Generic;

namespace Codingame.Hard.ClosestNumber;

public class ClosestNumber
{
    public string GetClosestPermutation(string source, string target)
    {
        if (source.Length <= 1)
        {
            return source;
        }

        // Unfortunately, we cannot apply a simple algorithm such as "start by adding as many digits that are identical to the target",
        // because that doesn't work with simple cases like 506->590 as it returns 560 instead of 605
        // Instead, we simultaneously build three prefixes:
        // TODO: expand

        // Build a dictionary of the digits available for permutation
        Dictionary<int, int> lowAvailableDigits = _getAvailableDigits(source);
        Dictionary<int, int> sameAvailableDigits = _getAvailableDigits(source);
        Dictionary<int, int> highAvailableDigits = _getAvailableDigits(source);

        // Special cases
        if (source.Length > target.Length)
        {
            if (!sameAvailableDigits.ContainsKey(0) || sameAvailableDigits[0] <= source.Length - target.Length)
            {
                return _getLowestPermutation(source);
            }
        }
        else if (source.Length < target.Length)
        {
            return _getHighestPermutation(source);
        }

        //
        List<int?> lows = new();
        List<int?> sames = new();
        List<int?> highs = new();

        // First digit has special treatment
        (int? currentLow, int? currentSame, int? currentHigh) = _getLowSameHighForDigit(index: 0, target, lowAvailableDigits);
        (currentLow, currentSame, currentHigh) = _removeFarthest(_parse(target[0]), currentLow, currentSame, currentHigh);
        lows.Add(currentLow);
        sames.Add(currentSame);
        highs.Add(currentHigh);
        if (currentLow.HasValue)
        {
            _removeDigit(currentLow.Value, lowAvailableDigits);
        }
        if (currentSame.HasValue)
        {
            _removeDigit(currentSame.Value, sameAvailableDigits);
        }
        if (currentHigh.HasValue)
        {
            _removeDigit(currentHigh.Value, highAvailableDigits);
        }

        // From the second digit
        int index = 1;
        while (index < target.Length)
        {
            int? nextLow = null;
            if (currentLow.HasValue)
            {
                nextLow = _getHighestAvailableDigit(lowAvailableDigits);
            }

            int? nextHigh = null;
            if (currentHigh.HasValue)
            {
                nextHigh = _getLowestAvailableDigit(highAvailableDigits);
            }

            int? nextSame = null;
            if (currentSame.HasValue)
            {
                (int? sameLow, int? sameSame, int? sameHigh) = _getLowSameHighForDigit(index, target, sameAvailableDigits);

                if (sameLow.HasValue)
                {
                    lowAvailableDigits = _clone(sameAvailableDigits);
                    lows = _clone(sames);
                    currentLow = currentSame;
                    nextLow = sameLow;
                }
                if (sameHigh.HasValue)
                {
                    highAvailableDigits = _clone(sameAvailableDigits);
                    highs = _clone(sames);
                    currentHigh = currentSame;
                    nextHigh = sameHigh;
                }
                if (sameSame.HasValue)
                {
                    nextSame = sameSame;
                }
            }

            // We need to compare the last two digits here; the last one is not enough
            (int? tempLow, int? tempSame, int? tempHigh) = _removeFarthest(10 * _parse(target[index - 1]) + _parse(target[index]),
                currentLow.HasValue && nextLow.HasValue ? 10 * currentLow + nextLow : null,
                currentSame.HasValue && nextSame.HasValue ? 10 * currentSame + nextSame : null,
                currentHigh.HasValue && nextHigh.HasValue ? 10 * currentHigh + nextHigh : null);
            if (tempLow.HasValue)
            {
                _removeDigit(nextLow!.Value, lowAvailableDigits);
            }
            else
            {
                nextLow = null;
            }
            if (tempSame.HasValue)
            {
                _removeDigit(nextSame!.Value, sameAvailableDigits);
            }
            else
            {
                nextSame = null;
            }
            if (tempHigh.HasValue)
            {
                _removeDigit(nextHigh!.Value, highAvailableDigits);
            }
            else
            {
                nextHigh = null;
            }

            lows.Add(nextLow);
            sames.Add(nextSame);
            highs.Add(nextHigh);

            (currentLow, currentSame, currentHigh) = (nextLow, nextSame, nextHigh);
            index++;
        }

        List<int?> result;

        if (currentSame.HasValue)
        {
            result = sames;
        }
        else if (currentLow.HasValue) // lower numbers have precedence over higher number in case of equal distance
        {
            result = lows;
        }
        else
        {
            result = highs;
        }

        return string.Join(string.Empty, _removeLeadingZeros(result));
    }

    private string _getLowestPermutation(string input)
    {
        List<int> permutation = new();
        var availableDigits = _getAvailableDigits(input);

        for (int i = 0; i <= 9; i++)
        {
            while (availableDigits.ContainsKey(i))
            {
                permutation.Add(i);
                _removeDigit(i, availableDigits);
            }
        }

        return string.Join(string.Empty, _removeLeadingZeros(permutation));
    }

    private string _getHighestPermutation(string input)
    {
        List<int> permutation = new();
        var availableDigits = _getAvailableDigits(input);

        for (int i = 9; i >= 0; i--)
        {
            while (availableDigits.ContainsKey(i))
            {
                permutation.Add(i);
                _removeDigit(i, availableDigits);
            }
        }

        return string.Join(string.Empty, _removeLeadingZeros(permutation));
    }

    private Dictionary<int, int> _getAvailableDigits(string source)
    {
        Dictionary<int, int> availableDigits = new();

        for (int i = 0; i < source.Length; i++)
        {
            int d = _parse(source[i]);

            if (availableDigits.ContainsKey(d))
            {
                availableDigits[d]++;
            }
            else
            {
                availableDigits.Add(d, 1);
            }
        }

        return availableDigits;
    }

    private (int? Low, int? Same, int? High) _removeFarthest(int target, int? low, int? same, int? high)
    {
        if (low.HasValue && same.HasValue)
        {
            if (low.Value < same.Value - 1)
            {
                low = null;
            }
        }

        if (high.HasValue && same.HasValue)
        {
            if (high.Value > same.Value + 1)
            {
                high = null;
            }
        }

        if (low.HasValue && high.HasValue)
        {
            if ((target - low.Value) > (high.Value - target) + 1)
            {
                low = null;
            }
            else if ((target - low.Value) < (high.Value - target) - 1)
            {
                high = null;
            }
        }

        return (low, same, high);
    }

    private (int? Low, int? Same, int? High) _getLowSameHighForDigit(int index, string target, Dictionary<int, int> availableDigits)
    {
        int? low = null;
        int? same = null;
        int? high = null;

        var digit = _parse(target[index]);

        for (int d = digit - 1; d >= 0; d--)
        {
            if (availableDigits.ContainsKey(d))
            {
                low = d;
                break;
            }
        }

        same = availableDigits.ContainsKey(digit) ? digit : null;

        for (int d = digit + 1; d <= 9; d++)
        {
            if (availableDigits.ContainsKey(d))
            {
                high = d;
                break;
            }
        }

        return (low, same, high);
    }

    private int? _getHighestAvailableDigit(Dictionary<int, int> availableDigits)
    {
        for (int digit = 9; digit >= 0; digit--)
        {
            if (availableDigits.ContainsKey(digit))
            {
                return digit;
            }
        }

        return null;
    }

    private int? _getLowestAvailableDigit(Dictionary<int, int> availableDigits)
    {
        for (int digit = 0; digit <= 9; digit++)
        {
            if (availableDigits.ContainsKey(digit))
            {
                return digit;
            }
        }

        return null;
    }

    private void _removeDigit(int digit, Dictionary<int, int> availableDigits)
    {
        if (availableDigits.ContainsKey(digit))
        {
            if (availableDigits[digit] > 1)
            {
                availableDigits[digit]--;
            }
            else
            {
                availableDigits.Remove(digit);
            }
        }
    }

    private List<int> _removeLeadingZeros(List<int> digits)
    {
        while (digits[0] == 0)
        {
            digits.RemoveAt(0);
        }
        return digits;
    }

    private List<int?> _removeLeadingZeros(List<int?> digits)
    {
        while (digits[0] == 0)
        {
            digits.RemoveAt(0);
        }
        return digits;
    }

    private Dictionary<int, int> _clone(Dictionary<int, int> availableDigits)
    {
        Dictionary<int, int> clone = new();
        foreach (var digit in availableDigits.Keys)
        {
            clone.Add(digit, availableDigits[digit]);
        }

        return clone;
    }

    private List<int?> _clone(List<int?> values)
    {
        return [..values];
    }

    private int _parse(char c)
    {
        return c - '0';
    }
}
