// https://www.codingame.com/training/medium/goro-want-chocolate
using System;
using System.Collections.Generic;

public class GoroWantChocolate
{
    private Dictionary<(int, int), int> _minimalNbSquares;

    public int GetMinimalNumberOfSquares(int width, int height)
    {
        _minimalNbSquares = new Dictionary<(int, int), int>();
        int nbSquares = RecursiveSolve(width, height);
        return nbSquares;
    }

    private int RecursiveSolve(int width, int height)
    {
        // Current shape is square => no need to split
        if (width == height)
        {
            return 1;
        }

        // Check if solution for this shape has already been computed
        if (_minimalNbSquares.ContainsKey((width, height)))
        {
            return _minimalNbSquares[(width, height)];
        }

        // Otherwise, try all (horizontal and vertical) possibilities for one cut
        int bestNbSquares = int.MaxValue;
        for (int i = 1; i < width; i++)
        {
            bestNbSquares = Math.Min(bestNbSquares, RecursiveSolve(width - i, height) + RecursiveSolve(i, height));
        }
        for (int i = 1; i < height; i++)
        {
            bestNbSquares = Math.Min(bestNbSquares, RecursiveSolve(width, height - i) + RecursiveSolve(width, i));
        }

        // Store the solution for the current shape
        _minimalNbSquares.Add((width, height), bestNbSquares);

        return bestNbSquares;
    }

}
