using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.TheGift;

[TestClass]
public class TheGiftTests
{

    [TestMethod]
    [DataRow(new int[] { 40, 40, 40 }, 100, new int[] { 33, 33, 34 })]
    [DataRow(new int[] { 100, 1, 60 }, 100, new int[] { 1, 49, 50 })]
    public void ComputeContributions_Solvable_PerformsCorrectly(int[] budgets, int total, int[] expected)
    {
        // Arrange
        TheGift theGift = new();

        // Act
        var actual = theGift.ComputeContributions(budgets, total);

        // Assert
        actual.IsSolvable.Should().BeTrue();
        actual.Contributions.Should().Equal(expected);
    }

    [TestMethod]
    [DataRow(new int[] { 20, 20, 40 }, 100)]
    public void ComputeContributions_Unsolvable_PerformsCorrectly(int[] budgets, int total)
    {
        // Arrange
        TheGift theGift = new();

        // Act
        var actual = theGift.ComputeContributions(budgets, total);

        // Assert
        actual.IsSolvable.Should().BeFalse();
    }

}
