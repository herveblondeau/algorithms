using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingTheCodeInterview.ArraysAndStrings.IsUnique
{
    // Source: "Cracking the coding interview" book (1.1 - Is unique)
    public class IsUnique
    {
        public static bool HasAllUniqueChars(string input)
        {
            HashSet<char> alreadySeenChars = new();

            foreach (char c in input)
            {
                if (alreadySeenChars.Contains(c))
                {
                    return false;
                }
                alreadySeenChars.Add(c);
            }

            return true;
        }
    }
}
