using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.AdventOfCode._2024;

public class Day8ResonantCollinearity
{
    #region Part 1

    public int CalculateNbAntinodes(string[] map)
    {
        // Parse the map to find the antennas
        int width = map[0].Length;
        int height = map.Length;
        Dictionary<char, List<(int Row, int Column)>> antennas = _findAntennas(map);

        // Compute the antinodes for each pair of antennas
        HashSet<(int Row, int Column)> antinodes = new();
        foreach (var frequency in antennas.Keys)
        {
            if (antennas[frequency].Count < 2)
            {
                break;
            }

            for (int i = 0; i < antennas[frequency].Count - 1; i++)
            {
                var antenna1 = antennas[frequency][i];
                for (int j = i + 1; j < antennas[frequency].Count; j++)
                {
                    var antenna2 = antennas[frequency][j];

                    // Each pair of antennas has two possible antinode locations
                    var antinode1 = (Row: 2 * antenna1.Row - antenna2.Row, Column: 2 * antenna1.Column - antenna2.Column);
                    var antinode2 = (Row: 2 * antenna2.Row - antenna1.Row, Column: 2 * antenna2.Column - antenna1.Column);
                    if (_isInMap(antinode1, width, height))
                    {
                        antinodes.Add(antinode1);
                    }
                    if (_isInMap(antinode2, width, height))
                    {
                        antinodes.Add(antinode2);
                    }
                }
            }
        }

        return antinodes.Count();
    }

    public int CalculateNbAntinodesWithResonantHarmonics(string[] map)
    {
        // Parse the map to find the antennas
        int width = map[0].Length;
        int height = map.Length;
        Dictionary<char, List<(int Row, int Column)>> antennas = _findAntennas(map);

        // Compute the antinodes for each pair of antennas
        HashSet<(int Row, int Column)> antinodes = new();
        foreach (var frequency in antennas.Keys)
        {
            if (antennas[frequency].Count < 2)
            {
                break;
            }

            for (int i = 0; i < antennas[frequency].Count - 1; i++)
            {
                var antenna1 = antennas[frequency][i];
                for (int j = i + 1; j < antennas[frequency].Count; j++)
                {
                    var antenna2 = antennas[frequency][j];
                    var deltaX = antenna2.Column - antenna1.Column;
                    var deltaY = antenna2.Row - antenna1.Row;

                    // Next, starting from antenna 1, find all antinodes in both directions
                    var currentAntenna = antenna1;
                    while (_isInMap(currentAntenna, width, height))
                    {
                        antinodes.Add(currentAntenna);
                        currentAntenna = (currentAntenna.Row - deltaY, currentAntenna.Column - deltaX);
                    }
                    currentAntenna = antenna1;
                    while (_isInMap(currentAntenna, width, height))
                    {
                        antinodes.Add(currentAntenna);
                        currentAntenna = (currentAntenna.Row + deltaY, currentAntenna.Column + deltaX);
                    }
                }
            }
        }

        return antinodes.Count();
    }

    private Dictionary<char, List<(int Row, int Column)>> _findAntennas(string[] map)
    {
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

        return antennas;
    }

    private bool _isInMap((int Row, int Column) node, int width, int height)
    {
        return node.Row >= 0 && node.Column >= 0
            && node.Row < height && node.Column < width;
    }

    #endregion
}
