// https://www.codingame.com/training/easy/unary

using System;
using System.Text;

namespace Codingame.Easy.Unary;

public class Unary
{
    public string Encode(string message)
    {
        // Build the binary string representation of the message, for instance "10000111000011" for "CC"
        byte[] asciiBytes = Encoding.ASCII.GetBytes(message);
        string binary = "";
        foreach (var b in asciiBytes) binary += Convert.ToString(b, 2).PadLeft(7, '0');

        // Build the result
        string result = "";
        char previous = '\u00ff'; // a random character outside of the default ASCII range
        foreach (char current in binary)
        {
            // New value => build the first block
            if (current != previous) result += " " + (current == '1' ? "0" : "00") + " ";

            // Append the value to the second block
            result += "0";

            previous = current;
        }

        // The generic loop above has inserted a space at the very beginning, which we need to remove
        return result.TrimStart();
    }
}
