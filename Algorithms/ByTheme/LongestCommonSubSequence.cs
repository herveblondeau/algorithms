using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{

    // https://www.geeksforgeeks.org/longest-common-subsequence-dp-using-memoization/?ref=rp
    public class LongestCommonSubSequence
    {
        private string _result;

        public string FindLongestCommonSubSequence(string string1, string string2)
        {
            _result = string.Empty;

            _result = RecursionSolve(string1, string2);

            return _result;
        }

        private string RecursionSolve(string string1, string string2)
        {
            if (string.IsNullOrEmpty(string1) || string.IsNullOrEmpty(string2))
            {
                return string.Empty;
            }

            if (string1.Last() == string2.Last())
            {
                return RecursionSolve(string1.RemoveLastCharacter(), string2.RemoveLastCharacter()) + string1.Last();
            }

            string longest1 = RecursionSolve(string1.RemoveLastCharacter(), string2);
            string longest2 = RecursionSolve(string1, string2.RemoveLastCharacter());

            return longest1.Length >= longest2.Length ? longest1 : longest2;
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