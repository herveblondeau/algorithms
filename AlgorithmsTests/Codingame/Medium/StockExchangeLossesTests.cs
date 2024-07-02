using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.StockExchangeLosses;

[TestClass]
public class StockExchangeLossesTests
{
    [TestMethod]
    [DataRow(new int[] { 3, 2, 4, 2, 1, 5 }, -3)]
    [DataRow(new int[] { 5, 3, 4, 2, 3, 1 }, -4)]
    [DataRow(new int[] {1, 2, 4, 4, 5 }, 0)]
    public void FindMaxPossibleLoss_WhenCalled_PerformsCorrectly(int[] values, int expected)
    {
        // Arrange
        StockExchangeLosses stockExchangeLosses = new();

        // Act
        var actual = stockExchangeLosses.FindMaxPossibleLoss(values);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
