// https://leetcode.com/problems/number-of-islands/

namespace LeetCode.NumberOfIslands;

public class NumberOfIslands
{
    private int _width;
    private int _height;

    public int CountIslands(int[,] lands)
    {
        _width = lands.GetLength(0);
        _height = lands.GetLength(1);

        int nbIslands = 0;

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (lands[i, j] == 1)
                {
                    _processLand(i, j, lands);
                    nbIslands++;
                }
            }
        }

        return nbIslands;
    }

    private void _processLand(int x, int y, int[,] lands)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height || lands[x, y] == 0)
        {
            return;
        }

        lands[x, y] = 0;

        _processLand(x - 1, y, lands);
        _processLand(x + 1, y, lands);
        _processLand(x, y - 1, lands);
        _processLand(x, y + 1, lands);

    }
}
