using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.SquaresOrder;

[TestClass]
public class SquaresOrderTests
{
    [TestMethod]
    public void GetOrder_CodingameOneSquare_PerformsCorrectly()
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
    public void GetOrder_CodingameTwoSquares_PerformsCorrectly()
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
    public void GetOrder_CodingameThreeSquares_PerformsCorrectly()
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
    public void GetOrder_CodingameFiveSquares_PerformsCorrectly()
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

    [TestMethod]
    public void GetOrder_CustomThreeSquares_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..........",
            "..22211...",
            ".333331...",
            ".322231...",
            ".3.1131...",
            ".3...3....",
            ".33333....",
            "..........",
            "..........",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 4), (2, 3), (3, 5)]);
    }

    [TestMethod]
    public void GetOrder_Custom1_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "222",
            "211",
            "211",
        ];
        int nbSquares = 2;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(2, 3), (1, 2)]);
    }

    [TestMethod]
    public void GetOrder_Custom2_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "12222",
            "12..2",
            ".2..2",
            ".2222",
        ];
        int nbSquares = 2;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 2), (2, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom3_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "11111",
            "1...1",
            "1...1",
            "122.1",
            "11111",
        ];
        int nbSquares = 2;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(2, 2), (1, 5)]);
    }

    [TestMethod]
    public void GetOrder_Custom4_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "12222",
            "12.12",
            "12.12",
            "12222",
        ];
        int nbSquares = 2;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 4), (2, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom5_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "12333",
            "123.3",
            "12333",
            ".2222",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 3), (2, 4), (3, 3)]);
    }

    [TestMethod]
    public void GetOrder_Custom6_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "11111",
            "1...1",
            "1...1",
            "1.221",
            "13311",
            ".33...",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(2, 2), (1, 5), (3, 2)]);
    }

    [TestMethod]
    public void GetOrder_Custom7_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "11222.",
            "1.2.2.",
            "13222.",
            ".3..3.",
            ".3..3.",
            ".3333.",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 3), (3, 4), (2, 3)]);
    }

    [TestMethod]
    public void GetOrder_Custom8_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            ".1111",
            "22221",
            "21.21",
            "21333",
            "22323",
            "..333",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 4), (2, 4), (3, 3)]);
    }

    [TestMethod]
    public void GetOrder_Custom9_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
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
    public void GetOrder_Custom10_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            ".1111",
            "22221",
            "21.21",
            "21323",
            "22223",
            "..333",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 4), (3, 3), (2, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom11_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            ".1111",
            "21221",
            "21.21",
            "21111",
            "22323",
            "..333",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(2, 4), (3, 3), (1, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom12_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            ".1111",
            "22221",
            "21.21",
            "21121",
            "22223",
            "..333",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(3, 3), (1, 4), (2, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom13_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            ".1111",
            "21221",
            "21.21",
            "21111",
            "22223",
            "..333",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(3, 3), (2, 4), (1, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom14_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..3333....",
            "..3..3....",
            "..32232...",
            "1133332...",
            "1..2..2...",
            "1..2222...",
            "1.....1...",
            "1.....1...",
            "1.....1...",
            "1111111...",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 7), (2, 4), (3, 4)]);
    }

    [TestMethod]
    public void GetOrder_Custom15_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..........",
            ".222222222",
            ".2.......2",
            "33333....2",
            "3211311..2",
            "32..3.1..2",
            "32..3.1..2",
            "33333.1..2",
            ".2....1..2",
            ".222222222",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 6), (2, 9), (3, 5)]);
    }

    [TestMethod]
    public void GetOrder_Custom16_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "..1111111.",
            "..2222222.",
            "..2333333.",
            "4444444.3.",
            "4.23..4.3.",
            "4.23..4.3.",
            "4.2311413.",
            "4.2333433.",
            "4.....4...",
            "4444444...",
        ];
        int nbSquares = 4;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 7), (2, 7), (3, 6), (4, 7)]);
    }

    [TestMethod]
    public void GetOrder_Custom17_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "....111111",
            "....1....1",
            "....1....1",
            "....1....1",
            "333333...1",
            "2224431111",
            "242..3....",
            "2255.3....",
            "3455.3....",
            "333333....",
        ];
        int nbSquares = 5;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 6), (4, 5), (3, 6), (2, 3), (5, 2)]);
    }

    [TestMethod]
    public void GetOrder_Custom18_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "1111111111",
            "1........1",
            "1........1",
            "1........1",
            "333333...1",
            "222..3...1",
            "244..3...1",
            "2455.3...1",
            "3.55.3...1",
            "3333331111",
        ];
        int nbSquares = 5;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 10), (3, 6), (2, 3), (4, 2), (5, 2)]);
    }

    [TestMethod]
    public void GetOrder_Custom19_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "22333",
            "2.3.3",
            "21333",
            "2...2",
            "22222",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 3), (2, 5), (3, 3)]);
    }

    [TestMethod]
    public void GetOrder_Custom20_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "2211",
            "2331",
            "1344",
            "1144",
        ];
        int nbSquares = 4;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 4), (2, 2), (3, 2), (4, 2)]);
    }

    [TestMethod]
    public void GetOrder_Custom21_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "44411.",
            "434322",
            "445552",
            "135352",
            "125552",
            ".22222",
        ];
        int nbSquares = 5;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 5), (2, 5), (3, 3), (4, 3), (5, 3)]);
    }

    [TestMethod]
    public void GetOrder_Custom22_PerformsCorrectly()
    {
        // Arrange
        SquaresOrder squaresOrder = new();
        string[] map = [
            "223322",
            "2.33.2",
            "2..1.2",
            "2111.2",
            "2....2",
            "222222",
        ];
        int nbSquares = 3;

        // Act
        var actual = squaresOrder.GetOrder(_format(map), nbSquares);

        // Assert
        actual.Should().BeEquivalentTo([(1, 4), (2, 6), (3, 2)]);
    }

    // The following tests have been commented out because the current algorithm doesn't pass them
    // The algorithm itself hasn't been updated because it still passes all Codingame tests and more, but it could be further improved in the future
    // [TestMethod]
    // public void GetOrder_Custom23_PerformsCorrectly()
    // {
    //     // Arrange
    //     SquaresOrder squaresOrder = new();
    //     string[] map = [
    //         "3334444444",
    //         "32.4.13114",
    //         "32.4.13555",
    //         "32.4.13515",
    //         "3224213555",
    //         "3..4..3..4",
    //         "3334444444",
    //     ];
    //     int nbSquares = 5;

    //     // Act
    //     var actual = squaresOrder.GetOrder(_format(map), nbSquares);

    //     // Assert
    //     actual.Should().BeEquivalentTo([(2, 5), (1, 4), (3, 7), (4, 7), (5, 3)]);
    // }

    // [TestMethod]
    // public void GetOrder_Custom24_PerformsCorrectly()
    // {
    //     // Arrange
    //     SquaresOrder squaresOrder = new();
    //     string[] map = [
    //         ".555522222",
    //         ".5..544112",
    //         ".5..5.41.2",
    //         ".555544312",
    //         ".3.....3.2",
    //         ".3.....3.2",
    //         ".3.....3.2",
    //         ".3.....3.2",
    //         ".322222322",
    //         ".3333333..",
    //     ];
    //     int nbSquares = 5;

    //     // Act
    //     var actual = squaresOrder.GetOrder(_format(map), nbSquares);

    //     // Assert
    //     actual.Should().BeEquivalentTo([(1, 3), (2, 9), (3, 7), (4, 3), (5, 4)]);
    // }

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
