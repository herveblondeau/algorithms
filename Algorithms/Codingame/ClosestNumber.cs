// https://www.codingame.com/training/hard/closest-number

using System.Collections.Generic;
using System.Text;

namespace Codingame.ClosestNumber
{
    public class ClosestNumber
    {
        public string GetClosestPermutation(string target, string source)
        {
            if (source.Length <= 1)
            {
                return source;
            }

            // Build a dictionary of the digits available for permutation
            Dictionary<int, int> availableDigits = new Dictionary<int, int>();
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

            StringBuilder permutation = new StringBuilder();
            int index = 0;
            int digit = -1;

            // As long as we can find the same digits as the target, just add them
            while (index < target.Length)
            {
                digit = _parse(target[index]);

                if (!availableDigits.ContainsKey(digit))
                {
                    break;
                }

                permutation.Append(digit);
                _removeDigit(digit, availableDigits);
                index++;
            }

            // Then find the closest next digit
            bool? searchHigher = null;
            if (index < target.Length - 1)
            {
                digit = (FindClosestDigit(_parse(target[index]), _parse(target[index + 1]), availableDigits));
                permutation.Append(digit);
                _removeDigit(digit, availableDigits);
                searchHigher = digit < _parse(target[index]);
            }

            // Then find the highest or lowest digits
            if (searchHigher == true)
            {
                digit = 9;
                while (digit >= 0)
                {
                    while (availableDigits.ContainsKey(digit))
                    {
                        permutation.Append(digit);
                        _removeDigit(digit, availableDigits);
                    }
                    digit--;
                }
            }
            else if (searchHigher == false)
            {
                digit = 0;
                while (digit <= 9)
                {
                    while (availableDigits.ContainsKey(digit))
                    {
                        permutation.Append(digit);
                        _removeDigit(digit, availableDigits);
                    }
                    digit++;
                }
            }

            return permutation.ToString();
        }

        private int FindClosestDigit(int current, int next, Dictionary<int, int> availableDigits)
        {
            int digit = current;
            int increment = next >= 5 ? 1 : -1;

            while (digit >= 0 || digit <= 9)
            {
                if (availableDigits.ContainsKey(digit))
                {
                    return digit;
                }

                digit += increment;
                increment = increment > 0 ? -increment-1 : -increment+1;

                if (digit < 0 || digit > 9)
                {
                    digit += increment;
                    increment = increment > 0 ? -increment - 1 : -increment + 1;
                }
            }

            return 0;
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

        private int _parse(char c)
        {
            return c - '0';
        }
    }
}
