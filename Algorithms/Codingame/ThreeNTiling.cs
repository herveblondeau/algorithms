// https://www.codingame.com/training/medium/3n-tiling
using System.Collections.Generic;

public class ThreeNTiling
{

    private Dictionary<(int, int), int> _nbLayouts;
    
    public int GetNumberOfValidLayouts(int width, int height)
    {
        _nbLayouts = new Dictionary<(int, int), int>();
        int nbLayouts = RecursiveSolve(width, height);
        return nbLayouts;
    }

    private int RecursiveSolve(int width, int height)
    {
        if (width == 2 && height == 6)
        {

        }

        // Known simple shapes => 
        if ((width == 2 && height == 2)
            || (width == 1 && height == 3)
            || (width == 3 && height == 1))
        {
            return 1;
        }
        if ((width == 1 && height == 1)
            || (width == 1 && height == 2)
            || (width == 2 && height == 1)
            || (width == 1 && height == 4)
            || (width == 4 && height == 1)
            || (width == 1 && height == 5)
            || (width == 5 && height == 1))
        {
            return 0;
        }

        // Check if solution for this shape has already been computed
        if (_nbLayouts.ContainsKey((width, height)))
        {
            return _nbLayouts[(width, height)];
        }

        // Otherwise, try all (horizontal and vertical) possibilities by splitting into two subrectangles
        int nbLayouts = 0;
        int nbLayoutsForSubRectangle1;
        int nbLayoutsForSubRectangle2;
        for (int i = 1; i < width; i++)
        {
            nbLayoutsForSubRectangle1 = RecursiveSolve(width - i, height);
            if (nbLayoutsForSubRectangle1 == 0)
            {
                continue;
            }

            nbLayoutsForSubRectangle2 = RecursiveSolve(i, height);
            if (nbLayoutsForSubRectangle2 == 0)
            {
                continue;
            }

            nbLayouts += (nbLayoutsForSubRectangle1 * nbLayoutsForSubRectangle2);
        }
        for (int i = 1; i < height; i++)
        {
            nbLayoutsForSubRectangle1 = RecursiveSolve(width, height - i);
            if (nbLayoutsForSubRectangle1 == 0)
            {
                continue;
            }

            nbLayoutsForSubRectangle2 = RecursiveSolve(width, i);
            if (nbLayoutsForSubRectangle2 == 0)
            {
                continue;
            }

            nbLayouts += (nbLayoutsForSubRectangle1 * nbLayoutsForSubRectangle2);
        }

        // Store the solution for the current shape
        _nbLayouts.Add((width, height), nbLayouts);

        if (width == 2 && height == 6)
        {

        }
        return nbLayouts;
    }

}
