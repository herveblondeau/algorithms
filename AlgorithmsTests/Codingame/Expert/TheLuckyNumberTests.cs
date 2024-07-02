using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.TheLuckyNumber;

[TestClass]
public class TheLuckyNumberTests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow(1351)]
    [DataRow(9886456)]
    public void Count_WhenSameAndNotLucky_ReturnsZero(long number)
    {
        // Arrange
        TheLuckyNumber TheLuckyNumber = new();

        // Act
        var actual = TheLuckyNumber.Count(number, number);

        // Assert
        Assert.AreEqual(0, actual);
    }

    [TestMethod]
    [DataRow(6)]
    [DataRow(8)]
    [DataRow(65)]
    [DataRow(2389945)]
    [DataRow(9132654354)]
    public void Count_WhenSameAndLucky_ReturnsOne(long number)
    {
        // Arrange
        TheLuckyNumber TheLuckyNumber = new();

        // Act
        var actual = TheLuckyNumber.Count(number, number);

        // Assert
        Assert.AreEqual(1, actual);
    }

    [TestMethod]
    [DataRow(1, 10, 2)]
    [DataRow(58, 72, 10)]
    [DataRow(5999, 6000, 1)]
    [DataRow(7148, 8875, 1018)]
    [DataRow(361087, 773904, 224197)]
    [DataRow(92871036442, 3363728910382456, 1160053175781729)]
    [DataRow(1, 1000000000000000000, 264160473575034274)]
    public void Count_WhenCalled_PerformsCorrectly(long min, long max, long expected)
    {
        // Arrange
        TheLuckyNumber TheLuckyNumber = new();

        // Act
        var actual = TheLuckyNumber.Count(min, max);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
