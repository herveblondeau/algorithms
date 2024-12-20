// https://adventofcode.com/2024/day/4

namespace Algorithms.AdventOfCode._2024;

public class Day4CeresSearch
{
    public int CountXmas(string[] rows)
    {
        int width = rows.Length;
        int height = rows[0].Length;

        int nbXmas = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                nbXmas += _countXmasFromPosition(rows, x, y);
            }
        }

        return nbXmas;
    }

    private int _countXmasFromPosition(string[] rows, int x, int y)
    {
        const int _xmasLength = 4;
        int width = rows.Length;
        int height = rows[0].Length;
        int nbXmas = 0;

        // Horizontal right
        if (x <= width - _xmasLength)
        {
            if (rows[y][x] == 'X' && rows[y][x+1] == 'M' && rows[y][x+2] == 'A' && rows[y][x+3] == 'S')
            {
                nbXmas++;
            }
        }

        // Horizontal left
        if (x >= _xmasLength - 1)
        {
            if (rows[y][x] == 'X' && rows[y][x-1] == 'M' && rows[y][x-2] == 'A' && rows[y][x-3] == 'S')
            {
                nbXmas++;
            }
        }

        // Vertical down
        if (y <= height - _xmasLength)
        {
            if (rows[y][x] == 'X' && rows[y+1][x] == 'M' && rows[y+2][x] == 'A' && rows[y+3][x] == 'S')
            {
                nbXmas++;
            }
        }

        // Vertical up
        if (y >= _xmasLength - 1)
        {
            if (rows[y][x] == 'X' && rows[y-1][x] == 'M' && rows[y-2][x] == 'A' && rows[y-3][x] == 'S')
            {
                nbXmas++;
            }
        }

        // Diagonal down-right
        if (x <= width - _xmasLength && y <= height - _xmasLength)
        {
            if (rows[y][x] == 'X' && rows[y+1][x+1] == 'M' && rows[y+2][x+2] == 'A' && rows[y+3][x+3] == 'S')
            {
                nbXmas++;
            }
        }

        // Diagonal up-right
        if (x <= width - _xmasLength && y >= _xmasLength - 1)
        {
            if (rows[y][x] == 'X' && rows[y-1][x+1] == 'M' && rows[y-2][x+2] == 'A' && rows[y-3][x+3] == 'S')
            {
                nbXmas++;
            }
        }

        // Diagonal down-left
        if (x >= _xmasLength - 1 && y <= height - _xmasLength)
        {
            if (rows[y][x] == 'X' && rows[y+1][x-1] == 'M' && rows[y+2][x-2] == 'A' && rows[y+3][x-3] == 'S')
            {
                nbXmas++;
            }
        }

        // Diagonal up-left
        if (x >= _xmasLength - 1 && y >= _xmasLength - 1)
        {
            if (rows[y][x] == 'X' && rows[y-1][x-1] == 'M' && rows[y-2][x-2] == 'A' && rows[y-3][x-3] == 'S')
            {
                nbXmas++;
            }
        }

        return nbXmas;
    }
    public int CountCrossmas(string[] rows)
    {
        int width = rows.Length;
        int height = rows[0].Length;

        int nbXmas = 0;
        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                nbXmas += _countCrossmasFromPosition(rows, x, y);
            }
        }

        return nbXmas;
    }

    private int _countCrossmasFromPosition(string[] rows, int x, int y)
    {
        if (rows[y][x] != 'A')
        {
            return 0;
        }

        int nbXmas = 0;

        // M S
        //  A
        // M S
        if (rows[y-1][x-1] == 'M' && rows[y+1][x+1] == 'S' && rows[y+1][x-1] == 'M' && rows[y-1][x+1] == 'S')
        {
            nbXmas++;
        }
        // S M
        //  A
        // S M
        else if (rows[y-1][x-1] == 'S' && rows[y+1][x+1] == 'M' && rows[y+1][x-1] == 'S' && rows[y-1][x+1] == 'M')
        {
            nbXmas++;
        }
        // M M
        //  A
        // S S
        else if (rows[y-1][x-1] == 'M' && rows[y+1][x+1] == 'S' && rows[y+1][x-1] == 'S' && rows[y-1][x+1] == 'M')
        {
            nbXmas++;
        }
        // S S
        //  A
        // M M
        else if (rows[y-1][x-1] == 'S' && rows[y+1][x+1] == 'M' && rows[y+1][x-1] == 'M' && rows[y-1][x+1] == 'S')
        {
            nbXmas++;
        }

        return nbXmas;
    }
}
