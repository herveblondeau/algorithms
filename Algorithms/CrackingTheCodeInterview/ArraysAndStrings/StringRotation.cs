using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingTheCodeInterview.ArraysAndStrings.StringRotation
{
    // Source: "Cracking the coding interview" book (1.9 - String rotation)
    public class StringRotation
    {
        public static bool AreRotations(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            return AreRotationsMethod2(str1, str2);
        }

        // We loop through each character of the second string. Every time we find the first string's beginning character, we rotate the second string and compare it to the first one
        // For example, if the first string is "waterbottlewow" and the second one is "erbottlewowwater", we will compare "wowwaterbottle", "wwaterbottlewo" and "waterbottlewow" to the first string
        // Note: this solution works but it doesn't follow the actual exercise requirement, which is to use one call to IsSubstring(), so method 2 is recommended instead
        private static bool AreRotationsMethod1(string str1, string str2)
        {

            char str1FirstChar = str1[0];
            for (int i = 0; i < str2.Length; i++)
            {
                if (str2[i] == str1FirstChar)
                {
                    if (str2.Substring(i) + str2.Substring(0, i) == str1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Using the given "waterbottle" example, all rotations are contained within the "waterbottlewaterbottle" string
        // This solution fits the exercise requirement
        private static bool AreRotationsMethod2(string str1, string str2)
        {
            return IsSubstring(str2, str1 + str1);
        }

        // Checks whether str1 is a substring of str2
        private static bool IsSubstring(string str1, string str2)
        {
            return str2.Contains(str1);
        }
    }
}
