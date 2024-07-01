// https://www.codingame.com/training/medium/scrabble

using System.Collections.Generic;

namespace Codingame.Scrabble
{
    public class Scrabble
    {

        public string FindBestWord(string[] words, string letters)
        {
            string bestWord = string.Empty;
            int bestScore = 0;

            int currentScore;
            for (int i = 0; i < words.Length; i++)
            {
                if (_isPlayable(words[i], letters))
                {
                    currentScore = _getScore(words[i]);
                    if (currentScore > bestScore)
                    {
                        bestScore = currentScore;
                        bestWord = words[i];
                    }
                }
            }

            return bestWord;
        }

        private bool _isPlayable(string word, string letters)
        {
            Dictionary<char, int> letterFrequencies = _getLetterFrequencies(letters);
            foreach (char c in word)
            {
                if (!letterFrequencies.ContainsKey(c) || letterFrequencies[c] == 0)
                {
                    return false;
                }
                letterFrequencies[c]--;
            }
            return true;
        }

        private Dictionary<char, int> _getLetterFrequencies(string letters)
        {
            Dictionary<char, int> frequencies = new();
            foreach (char c in letters)
            {
                if (frequencies.ContainsKey(c))
                {
                    frequencies[c]++;
                }
                else
                {
                    frequencies.Add(c, 1);
                }
            }
            return frequencies;
        }

        private int _getScore(string word)
        {
            int score = 0;
            foreach (char c in word)
            {
                score += _letterScores[c];
            }
            return score;
        }

        private Dictionary<char, int> _letterScores = new()
        {
        { 'a', 1 },
        { 'b', 3 },
        { 'c', 3 },
        { 'd', 2 },
        { 'e', 1 },
        { 'f', 4 },
        { 'g', 2 },
        { 'h', 4 },
        { 'i', 1 },
        { 'j', 8 },
        { 'k', 5 },
        { 'l', 1 },
        { 'm', 3 },
        { 'n', 1 },
        { 'o', 1 },
        { 'p', 3 },
        { 'q', 10 },
        { 'r', 1 },
        { 's', 1 },
        { 't', 1 },
        { 'u', 1 },
        { 'v', 4 },
        { 'w', 4 },
        { 'x', 8 },
        { 'y', 4 },
        { 'z', 10 },
    };

    }
}