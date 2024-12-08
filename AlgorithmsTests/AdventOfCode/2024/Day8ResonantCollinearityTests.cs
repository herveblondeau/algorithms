using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.AdventOfCode._2024;

[TestClass]
public class Day8ResonantCollinearityTests
{
    #region Part 1

    [TestMethod]
    public void CalculateNbAntinodes_SampleMap_PerformsCorrectly()
    {
        // Arrange
        Day8ResonantCollinearity day8ResonantCollinearity = new();
        var map = _getSampleMap();

        // Act
        var actual = day8ResonantCollinearity.CalculateNbAntinodes(map);

        // Assert
        actual.Should().Be(14);
    }

    [TestMethod]
    public void CalculateNbAntinodes_TestMap_PerformsCorrectly()
    {
        // Arrange
        Day8ResonantCollinearity day8ResonantCollinearity = new();
        var map = _getTestMap();

        // Act
        var actual = day8ResonantCollinearity.CalculateNbAntinodes(map);

        // Assert
        actual.Should().Be(278);
    }

    #endregion

    #region Part 2

    [TestMethod]
    public void CalculateNbAntinodesWithResonantHarmonics_SampleMap_PerformsCorrectly()
    {
        // Arrange
        Day8ResonantCollinearity day8ResonantCollinearity = new();
        var map = _getSampleMap();

        // Act
        var actual = day8ResonantCollinearity.CalculateNbAntinodesWithResonantHarmonics(map);

        // Assert
        actual.Should().Be(34);
    }

    [TestMethod]
    public void CalculateNbAntinodesWithResonantHarmonics_TestMap_PerformsCorrectly()
    {
        // Arrange
        Day8ResonantCollinearity day8ResonantCollinearity = new();
        var map = _getTestMap();

        // Act
        var actual = day8ResonantCollinearity.CalculateNbAntinodesWithResonantHarmonics(map);

        // Assert
        actual.Should().Be(1067);
    }

    #endregion

    private string[] _getSampleMap()
    {
        return
        [
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............",
        ];
    }

    private string[] _getTestMap()
    {
        return
        [
            ".........................p........................",
            "......................h....C............M.........",
            "..............................p....U..............",
            "..5..................p............................",
            "..6z...........................................C..",
            "...............c...........zV.....................",
            "...5.....c........................................",
            ".Z.............h........S...z....9................",
            ".O............................9...z........M..C...",
            "..O....5..............................F..M..C.....",
            "..Z.........5.c...............M....V..............",
            "........ZO................q.......................",
            "s...O................h..Uq.....7V...........4.....",
            ".q.g..............c.............p.......4.........",
            "............hZ.............................4G.....",
            "6s...........................U.Q.....3............",
            ".......6.................9.......Q.............3..",
            "....s..D.........................6................",
            ".............................................FL...",
            "..................................................",
            "..g...D.........q.....f.......Q...F....L......7...",
            "...............2.........f.............V.L...4....",
            "...................2.s...................f3......G",
            "....g...........................v......7P.........",
            "..2..g.............d.....v...........P.......1....",
            "..............u.........f.............L........G..",
            ".........l.D....u...............d........o..P.....",
            "..................8...............9..1......o...7.",
            "............l.....................................",
            "...................l...S...........F.......o..U...",
            ".......................u...S......................",
            "..........l....u...............m...........P....G.",
            "......................................1.8.......o.",
            "..................................................",
            "..................v.......S................0......",
            ".............v........d.....1.....................",
            "..................................................",
            "..........D....................................0..",
            "...................m.............H..........0.....",
            "...................................d......0.......",
            "..................................................",
            "....Q.............................................",
            "................................H.................",
            "........................H....................8....",
            "..................................................",
            "..................................................",
            ".........................................8........",
            ".......................H3.........................",
            "............................m.....................",
            "................................m.................",
        ];
    }
}
