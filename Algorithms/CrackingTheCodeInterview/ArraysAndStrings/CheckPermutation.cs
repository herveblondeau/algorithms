using System.Linq;

namespace CrackingTheCodeInterview.ArraysAndStrings.CheckPermutation;

// Source: "Cracking the coding interview" book (1.2 - Check permutation)
public class CheckPermutation
{
    public static bool ArePermutations(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            return false;
        }

        // Sort both strings
        // O(nlogn) time, O(1s) space
        str1 = Sort(str1);
        str2 = Sort(str2);

        return str1 == str2;
    }

    private static string Sort(string input)
    {
        return string.Concat(input.ToCharArray().OrderBy(c => c));
    }
}
