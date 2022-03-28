// https://www.codingame.com/ide/puzzle/the-greatest-number

using System.Collections.Generic;
using System.Text;

namespace Codingame.TheGreatestNumber
{
    public class TheGreatestNumber
    {
        public string GetGreatest(string input)
        {
            var characters = _toDictionary(input);

            if (!characters.ContainsKey('-'))
            {
                if (!characters.ContainsKey('.'))
                {
                    return _getHighestPositiveInteger(characters);
                }
                else
                {
                    return _getHighestPositiveDecimal(characters);
                }
            }
            else
            {
                if (!characters.ContainsKey('.'))
                {
                    return _getHighestNegativeInteger(characters);
                }
                else
                {
                    return _getHighestNegativeDecimal(characters);
                }
            }
        }

        private string _getHighestPositiveInteger(Dictionary<char, int> availableDigits)
        {
            StringBuilder builder = new StringBuilder();
            var digit = '9';
            while (digit >= '0')
            {
                while (availableDigits.ContainsKey(digit))
                {
                    builder.Append(digit);
                    _removeDigit(digit, availableDigits);
                }
                digit--;
            }

            return builder.ToString();
        }

        private string _getHighestNegativeInteger(Dictionary<char, int> availableDigits)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('-');

            var digit = '1';
            while (digit <= '9')
            {
                while (availableDigits.ContainsKey(digit))
                {
                    builder.Append(digit);
                    _removeDigit(digit, availableDigits);
                }
                digit++;
            }

            return builder.ToString();
        }

        private string _getHighestPositiveDecimal(Dictionary<char, int> availableDigits)
        {
            StringBuilder builder = new StringBuilder();
            var digit = '9';
            bool containsZero = availableDigits.ContainsKey('0');
            while (digit >= '0')
            {
                while (availableDigits.ContainsKey(digit))
                {
                    builder.Append(digit);
                    _removeDigit(digit, availableDigits);
                }
                digit--;
            }

            var intermediate = builder.ToString();
            return containsZero ? intermediate.Substring(0, intermediate.Length - 1) : intermediate.Insert(intermediate.Length - 1, ".");
        }

        private string _getHighestNegativeDecimal(Dictionary<char, int> availableDigits)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('-');

            var digit = '0';
            while (digit <= '9')
            {
                while (availableDigits.ContainsKey(digit))
                {
                    builder.Append(digit);
                    _removeDigit(digit, availableDigits);
                }
                digit++;
            }

            var intermediate = builder.ToString();
            return intermediate.Insert(2, ".");
        }

        private Dictionary<char, int> _toDictionary(string text)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
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
