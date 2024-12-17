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
        // Instead, we simultaneously build three prefixes: low, same and high
        // - low is the highest sequence that is lower than the target
        // - same is the sequence that has the most common digits with the target
        // - high is the lowest sequence that is higher than the target

        // Basically, at each step, we expand each sequence by one digit and keep only the sequences that are closest to the target
        // Example: the target is 3746 and we have built 374
        // - if the remaining digits in our pool are 2, 4, 8, 9, then low=3744, high=3749 and there is no same. Then we only keep low, as 3749 is unuambiguously further than 3744 from 3746
        // - if the remaining digits in our pool are 2, 5, 6, 8, then low=3745, high=3748 and same=3746. Then we only keep low and same, as 3748 is unuambiguously further than 3745 and 3746 from 3746. At this stage, we cannot discard 3745 or 3746, as only the following digits will tell which one is closer. For instance, if target=48653, then 48649 is closer than 46858, even though 4864 is farther than 4685
        // Notes:
        // 1) when comparing to the target, we don't need to compare the whole sequence; the last two digits are enough
        // 2) the "same" sequence is not just expanded: it also generates its own low, same and high. If it itself has a low, then that new low replaces the previous one as it is necessarily closer
        // For instance, with target=3454786, low=3453, same=3454 and high=3455, and assuming all digits are available to pick from the remaining pool, then:
        // - next low=34539
        // - next high=34550
        // - next same gives three possibilities: 34546, 34547 and 34548 => 34546 and 34548 become the new low and high

        // Build a dictionary of the digits available for permutation
        Dictionary<int, int> lowAvailableDigits = _getAvailableDigits(source);
        Dictionary<int, int> sameAvailableDigits = _getAvailableDigits(source);
        Dictionary<int, int> highAvailableDigits = _getAvailableDigits(source);

        // Special cases
        if (source.Length > target.Length)
        {
            // More digits that required in the target, and enough zeros to remove (leading zeros)
            if (sameAvailableDigits.ContainsKey(0) && sameAvailableDigits[0] > source.Length - target.Length)
            {
                for (int i = 0; i < source.Length - target.Length; i++)
                {
                    lowAvailableDigits[0]--;
                    sameAvailableDigits[0]--;
                    highAvailableDigits[0]--;
                }
            }
            // More digits that required in the target, and not enough zeros to remove
            // The number we build will have more digits and therefore be higher than the target regardless of the permutation
            // Therefore, the closest number to the target is the smallest permutation we can create
            else
            {
                return _getLowestPermutation(source);
            }
        }
        else if (source.Length < target.Length)
        {
            // Conversely, if we have less digits than the target requires, the number we build will be lower than the target regardless of the permutation
            // Therefore, the closest number to the target is the highest permutation we can create
            return _getHighestPermutation(source);
        }

        List<int?> lows = new();
        List<int?> sames = new();
        List<int?> highs = new();

        // First digit
        (int? currentLow, int? currentSame, int? currentHigh) = _getLowSameHighForDigit(index: 0, target, lowAvailableDigits);
        (currentLow, currentSame, currentHigh) = _removeFarthest(_parse(target[0]), currentLow, currentSame, currentHigh);
        lows.Add(currentLow);
        sames.Add(currentSame);
        highs.Add(currentHigh);
        if (currentLow.HasValue)
        {
            _removeAvailableDigit(currentLow.Value, lowAvailableDigits);
        }
        if (currentSame.HasValue)
        {
            _removeAvailableDigit(currentSame.Value, sameAvailableDigits);
        }
        if (currentHigh.HasValue)
        {
            _removeAvailableDigit(currentHigh.Value, highAvailableDigits);
        }

        // Subsequent digits
        for (int index = 1; index < target.Length; index++)
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
                _removeAvailableDigit(nextLow!.Value, lowAvailableDigits);
            }
            else
            {
                nextLow = null;
            }
            if (tempSame.HasValue)
            {
                _removeAvailableDigit(nextSame!.Value, sameAvailableDigits);
            }
            else
            {
                nextSame = null;
            }
            if (tempHigh.HasValue)
            {
                _removeAvailableDigit(nextHigh!.Value, highAvailableDigits);
            }
            else
            {
                nextHigh = null;
            }

            lows.Add(nextLow);
            sames.Add(nextSame);
            highs.Add(nextHigh);

            (currentLow, currentSame, currentHigh) = (nextLow, nextSame, nextHigh);
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
                _removeAvailableDigit(i, availableDigits);
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
                _removeAvailableDigit(i, availableDigits);
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
            var lowDelta = target - low.Value;
            if (lowDelta < 0) // can happen for instance if target=03 and low=97
            {
                lowDelta += 100;
            }
            var highDelta = high.Value - target;
            if (lowDelta > highDelta + 1)
            {
                low = null;
            }
            else if (lowDelta < highDelta - 1)
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

    private void _removeAvailableDigit(int digit, Dictionary<int, int> availableDigits)
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
