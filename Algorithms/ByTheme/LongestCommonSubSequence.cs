using System;
using System.Collections.Generic;
using System.Linq;

namespace ByTheme.LongestCommonSubSequence
{

    // https://www.geeksforgeeks.org/longest-common-subsequence-dp-using-memoization/?ref=rp
    public class LongestCommonSubSequence
    {
        public string Recursion(string string1, string string2)
        {
            if (string.IsNullOrEmpty(string1) || string.IsNullOrEmpty(string2))
            {
                return string.Empty;
            }

            if (string1.Last() == string2.Last())
            {
                return Recursion(string1.RemoveLastCharacter(), string2.RemoveLastCharacter()) + string1.Last();
            }

            string longest1 = Recursion(string1.RemoveLastCharacter(), string2);
            string longest2 = Recursion(string1, string2.RemoveLastCharacter());

            return longest1.Length >= longest2.Length ? longest1 : longest2;
        }

        public string Memoization(string string1, string string2)
        {
            _memoizationResults = new Dictionary<(string, string), string>();
            return _Memoization(string1, string2);
        }

        private Dictionary<(string, string), string> _memoizationResults;
        private string _Memoization(string string1, string string2)
        {
            if (string.IsNullOrEmpty(string1) || string.IsNullOrEmpty(string2))
            {
                return string.Empty;
            }

            if (_memoizationResults.ContainsKey((string1, string2)))
            {
                return _memoizationResults[(string1, string2)];
            }

            if (string1.Last() == string2.Last())
            {
                _memoizationResults[(string1, string2)] = _Memoization(string1.RemoveLastCharacter(), string2.RemoveLastCharacter()) + string1.Last();
            }
            else
            {
                string longest1 = _Memoization(string1.RemoveLastCharacter(), string2);
                string longest2 = _Memoization(string1, string2.RemoveLastCharacter());
                _memoizationResults[(string1, string2)] = longest1.Length >= longest2.Length ? longest1 : longest2;
            }

            return _memoizationResults[(string1, string2)];
        }
    }

    public static class StringExtensions
    {
        public static string RemoveLastCharacter(this string input)
        {
            return input.Remove(input.Length - 1);
        }

    }
}