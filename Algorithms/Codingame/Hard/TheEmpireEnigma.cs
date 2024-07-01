// https://www.codingame.com/training/hard/the-empire-enigma
using System.Collections.Generic;
using System.Linq;

namespace Codingame.TheEmpireEnigma
{
    public class TheEmpireEnigma
    {
        /**
         * Let:
         * - A1,A2,..An the ASCII codes of the initial message
         * - R1,R2,..Rn the RNG numbers actually used for encryption (which means that R1 is the first character after the discarded offset characters)
         * - B1,B2,..Bn the ASCII codes of the encrypted message
         * B is known as well as A1 (it's always '@'); the goal is to find A.
         *
         * We have:
         * A1 XOR R1, truncated to the lowest 8 bit = B1
         * A2 XOR R2, truncated to the lowest 8 bit = B2
         * ...
         * An XOR Rn, truncated to the lowest 8 bit = Bn
         *
         * We proceed in two steps:
         * 1) Find R1
         * We know A1 and B1. We cannot XOR them to get R1 (similarly to what we do in the second step below) because B1 is truncated to the lowest 8 bits, so we cannot retrieve the full A1 value
         * The only way is to use the fact that the RNG formula ends with a modulo 7140 operator, which limits the possible RNG numbers. By applying the RNG formula to the [0, 7139] interval, we get all the possible values. (note: this has been assumed by computing the RNG formula up to 10000000, but must still be demonstrated mathematically...)
         * Once we have them, we just need to find the one that gives B1 when "XORed" with A1.
         *
         * 2) Find A2...An
         * Now that we know R1, we can compute R2...Rn thanks to the supplied RNG formula
         * So we have R and B
         * Then, to find A, we just need to use the fact that if A XOR R = B, then A = B XOR R
         */
        public string Break(byte[] encrypted)
        {
            // Compute all possible RNG numbers (we use a set to keep only distinct values)
            HashSet<int> rngs = new();
            for (int i = 0; i < 7140; i++)
            {
                rngs.Add(NextRng(i));
            }

            byte[] message = new byte[encrypted.Length - 1];

            // Find R1
            int currentRng = rngs.Single(r => (byte)(r ^ '@') == encrypted[0]);

            // Discard the leading '@' (A1)
            encrypted = encrypted.Skip(1).ToArray();

            // Find A2...An: compute the subsequent RNG numbers and XOR them with the corresponding encrypted characters
            for (int i = 0; i < encrypted.Length; i++)
            {
                currentRng = NextRng(currentRng);
                message[i] = (byte)(currentRng ^ encrypted[i]);
            }

            return string.Join("", message.Select(l => (char)l));
        }

        private int NextRng(long currentRng)
        {
            return (int)((7562100 * currentRng + 907598307) % 7140);
        }

    }
}
