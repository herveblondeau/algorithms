// https://www.codingame.com/training/easy/lumen

using System.Collections.Generic;

namespace Codingame.Easy.Lumen;

public class Lumen
{
    public int CountDarkSpots(List<string> lines, int baseCandleLight)
    {
        var size = lines.Count;

        // We don't actually care about how much light each spot gets
        // We're just interested in knowing whether each spot is lit or not
        bool[,] lights = new bool[size, size];

        // All spots start as dark and are therefore all hiding places
        // We will decrement this value as the spots are being lit
        int nbDarkSpots = size * size;
        for (int row = 0; row < size; row++)
        {
            string line = lines[row];

            for (int column = 0; column < size; column++)
            {
                // Multiplied by 2 because there is a space between each character
                if (line[column * 2] == 'C')
                {
                    // Light up all neighboring spots
                    for (int k = row - baseCandleLight + 1; k < row + baseCandleLight; k++)
                    {
                        for (int l = column - baseCandleLight + 1; l < column + baseCandleLight; l++)
                        {
                            // try/catch so we don't need to care about out of bound indexes
                            try
                            {
                                if (!lights[k, l])
                                {
                                    lights[k, l] = true;
                                    nbDarkSpots--;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        return nbDarkSpots;
    }
}
