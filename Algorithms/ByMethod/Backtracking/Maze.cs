using System;

namespace ByMethod.Backtracking;

public class Maze
{
    private int _width { get; set; }
    private int _height { get; set; }

    public void Solve(int[,] maze)
    {
        // Solve
        _width = maze.GetLength(0);
        _height = maze.GetLength(1);
        int[,] solution = new int[_width, _height];
        var isSolved = BacktrackingSolve(maze, 0, 0, solution);

        // Output
        if (isSolved)
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    Console.Write(solution[i, j]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Unsolvable");
        }
    }

    private bool BacktrackingSolve(int[,] maze, int currentX, int currentY, int[,] solution)
    {
        // Current position not playable => deadend
        if (!IsPlayable(maze, currentX, currentY))
        {
            return false;
        }

        // Mark current position as part of the solution
        solution[currentX, currentY] = 1;

        // Final position => maze solved
        if ((currentX, currentY) == (_width - 1, _height - 1))
        {
            return true;
        }

        // Try next positions
        if (BacktrackingSolve(maze, currentX + 1, currentY, solution))
        {
            return true;
        }
        if (BacktrackingSolve(maze, currentX, currentY + 1, solution))
        {
            return true;
        }

        // Revert current position
        solution[currentX, currentY] = 0;
        return false;
    }

    private bool IsPlayable(int[,] maze, int currentX, int currentY)
    {
        return currentX < _width && currentY < _height && maze[currentX, currentY] == 1;
    }
}