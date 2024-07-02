using System;

namespace ByMethod.Backtracking;

public class Sudoku
{
    private int _size { get; set; }

    public void Solve(int[,] board)
    {
        bool isSolved = false;

        // Solve
        _size = board.GetLength(0);
        for (int n = 1; n <= _size; n++)
        {
            if (BacktrackingSolve(board, n))
            {
                isSolved = true;
                break;
            }
        }

        // Output
        if (isSolved)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Unsolvable");
        }
    }

    private bool BacktrackingSolve(int[,] board, int number)
    {
        // Board complete => success
        (int row, int column) = FindNextZero(board);
        if ((row, column) == (-1, -1))
        {
            return true;
        }

        // Number not playable at given position => immediate failure, no need to go further
        if (!IsPlayable(board, number, row, column))
        {
            return false;
        }

        // Mark current position as part of the solution
        board[row, column] = number;

        // Try next positions
        for (int n = 1; n <= _size; n++)
        {
            if (BacktrackingSolve(board, n))
            {
                return true;
            }
        }

        // Revert current position if none of the next positions has succeeded
        board[row, column] = 0;
        return false;
    }

    private bool IsPlayable(int[,] board, int number, int row, int column)
    {
        // Row
        for (int i = 0; i < _size; i++)
        {
            if (board[i, column] == number)
            {
                return false;
            }
        }

        // Column
        for (int j = 0; j < _size; j++)
        {
            if (board[row, j] == number)
            {
                return false;
            }
        }

        // Square
        int subSize = Convert.ToInt32(Math.Sqrt(_size));
        int startRow = (row / subSize) * subSize;
        int startColumn = (column / subSize) * subSize;
        for (int i = 0; i < subSize; i++)
        {
            for (int j = 0; j < subSize; j++)
            {
                if (board[startRow + i, startColumn + j] == number)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private (int, int) FindNextZero(int[,] board)
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (board[i, j] == 0)
                    return (i, j);
            }
        }

        return (-1, -1);
    }
}