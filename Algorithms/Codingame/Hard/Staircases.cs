// https://www.codingame.com/training/hard/staircases

using System.Collections.Generic;

namespace Codingame.Hard.Staircases;

public class Staircases
{
    private Dictionary<(int, int), long> _visited = null!;

    public long GetNumberOfStaircases(int bricks)
    {
        if (bricks < 3)
        {
            return 0;
        }

        _visited = new Dictionary<(int, int), long>();
        long nbStaircases = 0;
        for (int i = 1; i <= bricks / 2; i++)
        {
            nbStaircases += _getNumberOfStaircases(i, bricks - i);
        }

        return nbStaircases;
    }

    private long _getNumberOfStaircases(int first, int remaining)
    {
        // Memoization result
        if (_visited.ContainsKey((first, remaining)))
        {
            return _visited[(first, remaining)];
        }

        // The second step must contain at least first+1 bricks
        if (remaining <= first)
        {
            _visited.Add((first, remaining), 0);
            return 0;
        }

        // The second step must contain at least first+1 bricks
        // The third step must contain at least first+2 bricks
        // So, if we have less than 2*first+3, then there is only one staircase possible
        if (remaining < 2 * first + 3)
        {
            _visited.Add((first, remaining), 1);
            return 1;
        }

        // We can already make one staircase using all remaining bricks
        long nbStaircases = 1;

        // Then recursively compute the number of "sub-staircases"
        for (int i = first + 1; i <= remaining / 2; i++)
        {
            nbStaircases += _getNumberOfStaircases(i, remaining - i);
        }
        _visited.Add((first, remaining), nbStaircases);

        return nbStaircases;
    }
}