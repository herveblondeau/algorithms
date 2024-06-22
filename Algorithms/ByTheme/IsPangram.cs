using System.Collections.Generic;

namespace ByTheme.IsPangram
{
    public class IsPangram
    {
        public bool Check(string text)
        {
            // Complexity: O(n) time, O(1) space
            HashSet<char> alphabet = new() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            foreach (var c in text.ToUpper())
            {
                alphabet.Remove(c);
            }

            return alphabet.Count == 0;
        }
    }
}