using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingTheCodeInterview.ArraysAndStrings.Palindrome
{
    // Source: "Cracking the coding interview" book (1.4 - Palindrome permutation)
    public class Palindrome
    {
        // This is the most straightforward solution, there is a slightly more streamlined one in the book
        public static bool IsPalindromePermutation(string input)
        {
            Dictionary<char, int> nbOccurrencesPerCharacter = new();
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
