// https://www.codingame.com/training/hard/the-greatest-number

using System.Collections.Generic;
using System.Text;

namespace Codingame.TheGreatestNumber
{
    public class TheGreatestNumber
    {
        public string GetGreatest(string input)
        {
            StringBuilder builder = new();
            var availableDigits = _toDictionary(input);
            bool isNegative = availableDigits.ContainsKey('-');
            bool isDecimal = availableDigits.ContainsKey('.');
            bool containsZero = availableDigits.ContainsKey('0');

            // Build a string containing all digits in order
            // - positive integer/decimal: from 9 to 0
            // - negative integer: from 1 to 9
            // - negative decimal: from 0 to 9
            var digit = isNegative ? (isDecimal ? '0' : '1') : '9';
            var endDigit = isNegative ? '9' + 1 : '0' - 1;
            while (digit != endDigit)
            {
                while (availableDigits.ContainsKey(digit))
                {
                    builder.Append(digit);
                    _removeDigit(digit, availableDigits);
                }
                if (isNegative) digit++;
                else digit--;
            }
            string orderedDigits = builder.ToString();

            // No digits => return 0
            if (string.IsNullOrEmpty(orderedDigits))
            {
                return "0";
            }
            // Only zeros => return 0
            if (orderedDigits[0] == '0' && orderedDigits[orderedDigits.Length - 1] == '0')
            {
                return "0";
            }

            if (!isNegative)
            {
                // Positive integer
                if (!isDecimal)
                {
                    return orderedDigits; // example: 6653211100 => 6653211100
                }
                // Positive decimal
                else
                {
                    return containsZero
                        ? orderedDigits.Substring(0, orderedDigits.Length - 1) // example: 6653211100 (=> 665321110.0) => 665321110
                        : orderedDigits.Insert(orderedDigits.Length - 1, ".")  // example: 66532111 => 6653211.1
                    ;
                }
            }
            else
            {
                // Negative integer
                if (!isDecimal)
                {
                    return "-" + orderedDigits; // example: 11123566 => -11123566
                }
                // Negative decimal
                else
                {
                    return "-" + orderedDigits.Insert(1, "."); // example: 0011123566 => -0.011123566
                }
            }
        }

        private Dictionary<char, int> _toDictionary(string text)
        {
            Dictionary<char, int> result = new();
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];

                if (result.ContainsKey(current))
                {
                    result[current]++;
                }
                else
                {
                    result.Add(current, 1);
                }
            }

            return result;
        }

        private void _removeDigit(char digit, Dictionary<char, int> availableDigits)
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
    }
}
