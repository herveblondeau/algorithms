using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.SquaresOrder;

[TestClass]
public class SquaresOrderTests
{
    [TestMethod]
    public void GetDistance_OneSquare_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..111",
            "..1.1",
            "..111",
            ".....",
            ".....",
        ];
        int nbSquares = 1;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 3)]);
    }

    [TestMethod]
    public void GetDistance_TwoSquares_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..111",
            "22221",
            "2.121",
            "2..2.",
            "2222.",
        ];
        int nbSquares = 2;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 3), (2, 4)]);
    }

    [TestMethod]
    public void GetDistance_ThreeSquares_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            ".....",
            ".1111",
            "21221",
            "21.21",
            "21333",
            "22323",
            "..333",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(2, 4), (1, 4), (3, 3)]);
    }

    [TestMethod]
    public void GetDistance_FiveSquares_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..........",
            "...22222..",
            "...24442..",
            "...2..42..",
            "...2.333..",
            "...22323..",
            ".....33111",
            ".......1.1",
            "......5511",
            "......55..",
        ];
        int nbSquares = 5;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(4, 4), (2, 5), (3, 3), (1, 3), (5, 2)]);
    }

    private int[][] _format(string[] source)
    {
        var target = new int[source.Length][];
        for (int row = 0; row < source.Length; row++)
        {
            target[row] = new int[source[row].Length];
            for (int column = 0; column < source[row].Length; column++)
            {
                target[row][column] = source[row][column] == '.' ? 0 : (int)char.GetNumericValue(source[row][column]);
            }
        }

        return target;
    }
}
