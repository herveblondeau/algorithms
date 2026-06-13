using AwesomeAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.ContainerWithMostWater;

[TestClass]
public class ContainerWithMostWaterTests
{
    [TestMethod]
    [DataRow(new int[] { 1, 1 }, 1)]
    [DataRow(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    public void TwoSum_WhenCalled_PerformsCorrectly(int[] heights, int expected)
    {
        // Arrange
        var containerWithMostWater = new ContainerWithMostWater();

        // Act
        var actual = containerWithMostWater.ComputeAmount(heights);

        // Assert
        actual.Should().Be(expected);
    }
}
