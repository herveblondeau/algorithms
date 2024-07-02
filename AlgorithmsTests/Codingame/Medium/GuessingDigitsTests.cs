using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.GuessingDigits;

[TestClass]
public class GuessingDigitsTests
{
    [TestMethod]
    [DataRow(2, 1, 1, 1, 1, 1)]
    [DataRow(3, 2, 1, 1, 1, 2)]
    [DataRow(17, 72, 1, 1, 8, 9)]
    [DataRow(18, 81, 1, 1, 9, 9)]
    [DataRow(4, 3, 1, 2, 1, 3)]
    [DataRow(6, 5, 1, 2, 1, 5)]
    [DataRow(7, 10, 1, 2, 2, 5)]
    [DataRow(8, 15, 1, 2, 3, 5)]
    [DataRow(9, 20, 1, 2, 4, 5)]
    [DataRow(10, 25, 1, 2, 5, 5)]
    [DataRow(11, 30, 1, 2, 5, 6)]
    [DataRow(8, 7, 1, 2, 1, 7)]
    [DataRow(9, 14, 1, 2, 2, 7)]
    [DataRow(10, 21, 1, 2, 3, 7)]
    [DataRow(11, 28, 1, 2, 4, 7)]
    [DataRow(12, 35, 1, 2, 5, 7)]
    [DataRow(13, 42, 1, 2, 6, 7)]
    [DataRow(14, 49, 1, 2, 7, 7)]
    [DataRow(12, 32, 1, 2, 4, 8)]
    [DataRow(13, 40, 1, 2, 5, 8)]
    [DataRow(14, 48, 1, 2, 6, 8)]
    [DataRow(15, 56, 1, 2, 7, 8)]
    [DataRow(16, 64, 1, 2, 8, 8)]
    [DataRow(12, 27, 1, 2, 3, 9)]
    [DataRow(14, 45, 1, 2, 5, 9)]
    [DataRow(15, 54, 1, 2, 6, 9)]
    [DataRow(16, 63, 1, 2, 7, 9)]
    [DataRow(4, 4, 2, 1, 2, 2)]
    [DataRow(12, 36, 2, 1, 6, 6)]
    [DataRow(13, 36, 2, 1, 4, 9)]
    [DataRow(5, 4, 2, 2, 1, 4)]
    [DataRow(5, 6, 3, 1, 2, 3)]
    [DataRow(7, 6, 3, 2, 1, 6)]
    [DataRow(7, 12, 4, 1, 3, 4)]
    [DataRow(8, 12, 4, 2, 2, 6)]
    [DataRow(8, 16, 5, 1, 4, 4)]
    [DataRow(10, 16, 5, 2, 2, 8)]
    public void Guess_SolvableCases_PerformsCorrectly(int sum, int product, int expectedTurn, int expectedPlayer, int expectedLow, int expectedHigh)
    {
        // Arrange
        GuessingDigits guessingDigits = new();

        // Act
        Guess? actual = guessingDigits.GuessDigits(sum, product)!;

        // Assert
        actual.Turn.Should().Be(expectedTurn);
        actual.Player.Should().Be(expectedPlayer);
        actual.Pair.Low.Should().Be(expectedLow);
        actual.Pair.High.Should().Be(expectedHigh);
    }

    [TestMethod]
    [DataRow(9, 8)]
    [DataRow(10, 9)]
    [DataRow(6, 8)]
    [DataRow(11, 18)]
    [DataRow(6, 9)]
    [DataRow(9, 18)]
    [DataRow(11, 24)]
    [DataRow(10, 24)]
    public void Guess_UnsolvableCases_ReturnsNull(int sum, int product)
    {
        // Arrange
        GuessingDigits guessingDigits = new();

        // Act
        Guess? actual = guessingDigits.GuessDigits(sum, product);

        // Assert
        actual.Should().BeNull();
    }
}
