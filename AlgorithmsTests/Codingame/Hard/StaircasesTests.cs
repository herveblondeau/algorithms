using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.Staircases;

[TestClass]
public class StaircasesTests
{

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    public void GetNumberOfStaircases_NotEnoughBricks_ReturnsZero(int bricks)
    {
        // Arrange
        Staircases staircases = new();

        // Act
        var actual = staircases.GetNumberOfStaircases(bricks);

        // Assert
        actual.Should().Be(0);
    }

    [TestMethod]
    [DataRow(3, 1)]
    [DataRow(5, 2)]
    [DataRow(10, 9)]
    [DataRow(25, 141)]
    //[DataRow(500, 2300)]
    public void GetNumberOfStaircases_WhenCalled_PerformsCorrectly(int bricks, int expected)
    {
        // Arrange
        Staircases staircases = new();

        // Act
        var actual = staircases.GetNumberOfStaircases(bricks);

        // Assert
        actual.Should().Be(expected);
    }

}
