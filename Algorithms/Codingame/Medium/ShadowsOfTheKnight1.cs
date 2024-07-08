// https://www.codingame.com/training/medium/shadows-of-the-knight-episode-1

using System;
using System.Collections.Generic;

namespace Codingame.Medium.ShadowsOfTheKnight1;

public class ShadowsOfTheKnight1
{
    public List<string> GetMoves(int width, int height, int startX, int startY, int nbMovesAllowed, DirectionInput directionInput)
    {
        int leftLimit = 0;
        int rightLimit = width - 1;
        int topLimit = 0;
        int bottomLimit = height - 1;

        int currentX = startX;
        int currentY = startY;

        // Game loop
        List<string> moves = new();
        string bombDir = directionInput.GetDirection(currentX, currentY).ToUpper();
        while (bombDir != string.Empty && nbMovesAllowed-- > 0)
        {
            if (bombDir.Contains("L"))
            {
                rightLimit = currentX;
                currentX = currentX - (currentX + 1 - leftLimit) / 2;
            }
            else if (bombDir.Contains("R"))
            {
                leftLimit = currentX;
                currentX = currentX + (rightLimit + 1 - currentX) / 2;
            }
            string move = currentX + " ";

            if (bombDir.Contains("U"))
            {
                bottomLimit = currentY;
                currentY = currentY - (currentY + 1 - topLimit) / 2;
            }
            else if (bombDir.Contains("D"))
            {
                topLimit = currentY;
                currentY = currentY + (bottomLimit + 1 - currentY) / 2;
            }
            move += currentY;

            moves.Add(move);
            bombDir = directionInput.GetDirection(currentX, currentY).ToUpper();
        }

        if (bombDir == string.Empty)
        {
            return moves;
        }

        // In this particular puzzle, the goal is to always win, so we don't have to handle the losing case
        throw new Exception("No more turns...bomb has detonated...");
    }
}

// This puzzle requires inputs at every turn, dynamically supplied by Codingame depending on the move we specify at each turn.
// In order to follow this requirement while still making the program testable, we introduce a DirectionInput interface that supplies the inputs, and we inject it into our algorithm
// We implement a ConsoleInput (to actually play the game) and an AutomatedInput (to be able to unit test our solution)

public interface DirectionInput
{
    // Returns the direction of the bomb from Batman's current location (U, UR, R, DR, D, DL, L or UL)
    string GetDirection(int x, int y);
}

public class ConsoleInput : DirectionInput
{
    public string GetDirection(int x, int y)
    {
        Console.WriteLine($"Current position: ({x},{y})");
        Console.WriteLine("Please input bomb direction: (U/UR/R/DR/D/DL/L/UL, ENTER if bomb found)");
        Console.WriteLine();
        return Console.ReadLine()!;
    }
}

public class AutomatedInput : DirectionInput
{
    private int _bombX;
    private int _bombY;

    public AutomatedInput(int bombX, int bombY)
    {
        _bombX = bombX;
        _bombY = bombY;
    }

    public string GetDirection(int x, int y)
    {
        return (x > _bombX ? "L" : x < _bombX ? "R" : "") + (y > _bombY ? "U" : y < _bombY ? "D" : "");
    }
}
