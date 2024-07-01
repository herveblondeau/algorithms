// https://www.codingame.com/training/hard/hangman

using System.Collections.Generic;
using System.Text;

namespace Codingame.Hard.Hangman;

public class Hangman
{
    public Result Solve(string word, char[] guesses)
    {
        // Initialize
        var lower = word.ToLower();
        HashSet<char> lettersToGuess = new();
        foreach (var c in lower)
        {
            if (c != ' ') lettersToGuess.Add(c); // whitespaces are not meant to be guessed
        }

        // Process guesses
        int nbFails = 0;
        foreach (char c in guesses)
        {
            if (lettersToGuess.Contains(c))
            {
                lettersToGuess.Remove(c);
                if (lettersToGuess.Count == 0) break;
            }
            else
            {
                nbFails++;
                if (nbFails == 6) break;
            }

        }

        // Build guessed word
        StringBuilder result = new();
        for (int i = 0; i < word.Length; i++)
        {
            result.Append(lettersToGuess.Contains(lower[i]) ? '_' : word[i]);
        }

        return new Result(nbFails, result.ToString());
    }

    public class Result
    {
        public int NbFails { get; set; }
        public string Word { get; set; }

        public Result(int nbFails, string word)
        {
            NbFails = nbFails;
            Word = word;
        }
    }

    public static string[] Draw(int nbFails)
    {
        string[] rows = new string[4];

        rows[0] = "+--+";
        rows[1] = nbFails == 0 ? "|" : "|  o";
        rows[2] = nbFails <= 1 ? "|"
            : nbFails == 2 ? "|  |"
            : nbFails == 3 ? "| /|"
            : "| /|\\";
        rows[3] = nbFails <= 4 ? "|\\"
            : nbFails == 5 ? "|\\/"
            : "|\\/ \\";

        return rows;
    }
}
