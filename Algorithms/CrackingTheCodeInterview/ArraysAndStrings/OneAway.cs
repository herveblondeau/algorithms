using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingTheCodeInterview.ArraysAndStrings.OneAway
{
    public class OneAway
    {
        // Source: "Cracking the coding interview" book (1.5 - One away)
        public static bool AreZeroOrOneAway(string str1, string str2)
        {
            if (AreZeroOrOneCharacterReplacementAway(str1, str2))
            {
                return true;
            }
            else if (AreZeroOrOneCharacterShiftAway(str1, str2))
            {
                return true;
            }
            else if (AreZeroOrOneCharacterShiftAway(str2, str1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // This method must only be called if the string have the same length
        private static bool AreZeroOrOneCharacterReplacementAway(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            bool hasADifferentCharacter = false;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    if (hasADifferentCharacter)
                    {
                        return false;
                    }

                    hasADifferentCharacter = true;
                }
            }

            return true;
        }

        private static bool AreZeroOrOneCharacterShiftAway(string str1, string str2)
        {
            if (Math.Abs(str1.Length - str2.Length) != 1)
            {
                return false;
            }

            string shortStr = str1.Length < str2.Length ? str1 : str2;
            string longStr = str1.Length < str2.Length ? str2 : str1;

            bool hasADifferentCharacter = false;
            int shortStrIndex = 0;
            int longStrIndex = 0;
            while (shortStrIndex < shortStr.Length)
            {
                if (shortStr[shortStrIndex] != longStr[longStrIndex])
                {
                    if (hasADifferentCharacter)
                    {
                        return false;
                    }

                    hasADifferentCharacter = true;
                    longStrIndex++;
                }

                shortStrIndex++;
                longStrIndex++;
            }

            return true;
        }
    }
}
