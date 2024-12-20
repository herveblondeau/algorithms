using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.SlidingPuzzle;

[TestClass]
public class SlidingPuzzleTests
{

    [TestMethod]
    public void Test1()
    {
        // Arrange
        SlidingPuzzle slidingPuzzle = new();
        int[,] start = new int[,]
        {
            { 2, 3 },
            { 1, 0 },
        };
        int[,] end = new int[,]
        {
            { 1, 2 },
            { 3, 0 },
        };

        // Act
        var actual = slidingPuzzle.GetNumberOfMoves(start, end);

        // Assert
        actual.Should().Be(4);
    }

    [TestMethod]
    public void Test2()
    {
        // Arrange
        SlidingPuzzle slidingPuzzle = new();
        int[,] start = new int[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 0, 7 },
        };
        int[,] end = new int[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 0 },
        };

        // Act
        var actual = slidingPuzzle.GetNumberOfMoves(start, end);

        // Assert
        actual.Should().Be(1);
    }

    [TestMethod]
    public void Test3()
    {
        // Arrange
        SlidingPuzzle slidingPuzzle = new();
        int[,] start = new int[,]
        {
            { 4, 1, 2 },
            { 0, 6, 3 },
            { 7, 5, 8 },
        };
        int[,] end = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 0 },
        };

        // Act
        var actual = slidingPuzzle.GetNumberOfMoves(start, end);

        // Assert
        actual.Should().Be(7);
    }

}
