// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/

using System.Collections.Generic;
using System.Text;

namespace LeetCode.LetterCombinationsOfPhoneNumber;

public class LetterCombinationsOfPhoneNumber
{
    private readonly Dictionary<char, string> _phone = new()
    {
      {'2', "abc"},
      {'3', "def"},
      {'4', "ghi"},
      {'5', "jkl"},
      {'6', "mno"},
      {'7', "pqrs"},
      {'8', "tuv"},
      {'9', "wxyz"},
    };

    private string _digits = null!;
    private HashSet<string> _results = null!;

    public IList<string> LetterCombinations(string digits)
    {
        _digits = digits;
        _results = new();
        _backtrack(0, new StringBuilder());

        return new List<string>(_results);
    }

    private void _backtrack(int position, StringBuilder current)
    {
        if (position == _digits.Length)
        {
            _results.Add(current.ToString());
            return;
        }

        foreach (var letter in _phone[_digits[position]])
        {
            current.Append(letter);
            _backtrack(position + 1, current);
            current.Length--;
        }
    }
}
