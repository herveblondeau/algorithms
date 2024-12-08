using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day8ResonantCollinearity
{
    #region Part 1

    public int CalculateNbAntinodes(string[] map)
    {
        HashSet<(int Row, int Column)> antinodes = new();
        Dictionary<char, List<(int Row, int Column)>> antennas = new();

        // Parse the map to find the antennas
        int width = map[0].Length;
        int height = map.Length;
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                if (map[row][column] == '.')
                {
                    continue;
                }

                char currentFrequency = map[row][column];
                if (!antennas.ContainsKey(currentFrequency))
                {
                    antennas[currentFrequency] = new();
                }
                antennas[currentFrequency].Add((row, column));
            }
        }

        // Compute the antinodes for each pair of antennas
        foreach (var frequency in antennas.Keys)
        {
            if (antennas[frequency].Count < 2)
            {
                break;
            }

            for (int i = 0; i < antennas[frequency].Count - 1; i++)
            {
                for (int j = i + 1; j < antennas[frequency].Count; j++)
                {
                    var antenna1 = antennas[frequency][i];
                    var antenna2 = antennas[frequency][j];

                    // Each pair of antennas has two possible antinode locations
                    var antinode1 = (Row: 2 * antenna1.Row - antenna2.Row, Column: 2 * antenna1.Column - antenna2.Column);
                    var antinode2 = (Row: 2 * antenna2.Row - antenna1.Row, Column: 2 * antenna2.Column - antenna1.Column);

                    if (antinode1.Row >= 0 && antinode1.Column >= 0
                        && antinode1.Row < height && antinode1.Column < width)
                    {
                        if (!antinodes.Contains((antinode1.Row, antinode1.Column)))
                        {
                            antinodes.Add((antinode1.Row, antinode1.Column));
                        }
                    }
                    if (antinode2.Row >= 0 && antinode2.Column >= 0
                        && antinode2.Row < height && antinode2.Column < width)
                    {
                        if (!antinodes.Contains((antinode2.Row, antinode2.Column)))
                        {
                            antinodes.Add((antinode2.Row, antinode2.Column));
                        }
                    }
                }
            }
        }

        return antinodes.Count();
    }

    #endregion
}
