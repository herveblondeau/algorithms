using System;

public class KnightTour
{
    private int _boardSize { get; set; }
    private int _nbMoves { get; set; }

    public void Solve(int boardSize)
    {
        // Solve
        _boardSize = boardSize;
        int[,] solution = new int[_boardSize, _boardSize];
        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {
                solution[i, j] = -1;
            }
        }
        var isSolved = BacktrackingSolve(_boardSize, 0, 0, solution);

        // Output
        if (isSolved)
        {
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    Console.Write(solution[i, j] + ",");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Unsolvable");
        }
    }

    private bool BacktrackingSolve(int boardSize, int currentX, int currentY, int[,] solution)
    {
        // Current position not playable => deadend
        if (!IsPlayable(boardSize, currentX, currentY, solution))
        {
            return false;
        }

        // Mark current position as part of the solution
        solution[currentX, currentY] = _nbMoves++;

        // Final position => maze solved
        if (_nbMoves == Math.Pow(boardSize, 2))
        {
            return true;
        }

        // Try next positions
        if (BacktrackingSolve(boardSize, currentX + 1, currentY + 2, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX + 1, currentY - 2, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX - 1, currentY + 2, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX - 1, currentY - 2, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX + 2, currentY + 1, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX + 2, currentY - 1, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX - 2, currentY + 1, solution))
        {
            return true;
        }
        if (BacktrackingSolve(boardSize, currentX - 2, currentY - 1, solution))
        {
            return true;
        }

        // Revert current position
        solution[currentX, currentY] = -1;
        _nbMoves--;
        return false;
    }

    private bool IsPlayable(int boardSize, int currentX, int currentY, int[,] solution)
    {
        return currentX >= 0
            && currentY >= 0
            && currentX < boardSize
            && currentY < boardSize
            && solution[currentX, currentY] == -1;
    }
}
