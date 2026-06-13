using System.Runtime.InteropServices.ComTypes;
// https://leetcode.com/problems/word-search

using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.WordSearch;

public class WordSearch
{
    private string _word = null!;
    private char[][] _board = null!;
    private HashSet<(int, int)> _visited = null!;

    public bool SearchWord(string word, char[][] board)
    {
        _word = word;
        _board = board;
        _visited = new HashSet<(int, int)>();

        for (int i = 0; i < _board.Length; i++)
        {
            for (int j = 0; j < _board[0].Length; j++)
            {
                if (board[i][j] == _word[0] && Backtrack(i, j, _visited, new StringBuilder()))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool Backtrack(int x, int y, HashSet<(int, int)> visited, StringBuilder currentWord)
    {
        // Already visited or out of bounds
        if (_visited.Contains((x, y)) || x < 0 || x >= _board.Length || y < 0 || y >= _board[0].Length)
        {
            return false;
        }

        // Process current cell: extend current word and mark as visited
        currentWord.Append(_board[x][y]);
        if (currentWord.ToString() == _word)
        {
            return true;
        }
        _visited.Add((x, y));

        // Explore neighbors (up, down, left, right)
        if (Backtrack(x + 1, y, visited, currentWord)
        || Backtrack(x - 1, y, visited, currentWord)
        || Backtrack(x, y + 1, visited, currentWord)
        || Backtrack(x, y - 1, visited, currentWord))
        {
            return true;
        }

        // Backtrack: remove the current cell from visited and remove the last character from currentWord
        _visited.Remove((x, y));
        currentWord.Length--;

        return false;
    }
}
