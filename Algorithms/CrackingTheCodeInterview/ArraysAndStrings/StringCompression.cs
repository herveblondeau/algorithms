using Codingame.TheGift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingTheCodeInterview.ArraysAndStrings.StringCompression
{
    // Source: "Cracking the coding interview" book (1.6 - String compression)
    public class StringCompression
    {
        public static string Compress(string input)
        {
            StringBuilder compressed = new();
            int length = 0;
            for (int i = 0; i < input.Length; i++)
            {
                length++;

                if (i + 1 == input.Length        // last character in string
                    || input[i] != input[i + 1]) // last character before new sequence
                {
                    compressed.Append(input[i]);
                    compressed.Append(length);
                    length = 0;
                }
            }

            return compressed.Length < input.Length ? compressed.ToString(): input;
        }
    }
}
