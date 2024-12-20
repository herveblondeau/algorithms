using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.TwoEggProblem;

[TestClass]
public class TwoEggProblemTests
{

    [TestMethod]
    [DataRow(100, 14)]
    public void GetMinimumDrops_WhenCalled_PerformsCorrectly(int floors, int expected)
    {
        // Arrange
        TwoEggProblem twoEggProblem = new();

        // Act
        var actual = twoEggProblem.GetMinimumDrops(floors);

        // Assert
        actual.Should().Be(expected);
    }

}
