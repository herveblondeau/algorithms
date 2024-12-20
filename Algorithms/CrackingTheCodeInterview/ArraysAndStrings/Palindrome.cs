﻿// Source: "Cracking the coding interview" book (1.4 - Palindrome permutation)

using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingTheCodeInterview.ArraysAndStrings.Palindrome;

public class Palindrome
{
    // This is the most straightforward solution, there is a slightly more streamlined one in the book
    public bool IsPalindromePermutation(string input)
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
