// https://www.codingame.com/training/hard/candies

using System;
using System.Collections.Generic;

namespace Codingame.Candies
{
    public class Candies
    {
        public List<string> GetSequences(int nbCandies, int mouthSize)
        {
            List<string> sequences = new();

            _getSequences(sequences, string.Empty, nbCandies, mouthSize);

            return sequences;
        }

        private void _getSequences(List<string> sequences, string current, int nbCandies, int mouthSize)
        {
            for (int i = 1; i <= Math.Min(nbCandies - 1, mouthSize); i++)
            {
                _getSequences(sequences, current + " " + i, nbCandies - i, mouthSize);
            }

            if (nbCandies <= mouthSize)
            {
                sequences.Add((current + " " + nbCandies).TrimStart());
            }
        }
    }
}