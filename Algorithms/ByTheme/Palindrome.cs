using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.ByTheme
{
    public class Palindrome
    {
        public static bool IsPalindromePermutation(string input)
        {
            Dictionary<char, int> nbOccurrencesPerCharacter = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (nbOccurrencesPerCharacter.ContainsKey(c))
                {
                    nbOccurrencesPerCharacter[c]++;
                }
                else
                {
                    nbOccurrencesPerCharacter.Add(c, 1);
                }
            };

            int nbOddCharacters = nbOccurrencesPerCharacter.Count(pair => pair.Value % 2 == 1);
            return nbOddCharacters <= 1;
        }
    }
}
