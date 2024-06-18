using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.TheTwoPilesDifference;

[TestClass]
public class TheTwoPilesDifferenceTests
{

    [TestMethod]
    [DynamicData(nameof(FindMinDifference_WhenCalled_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void FindMinDifference_WhenCalled_PerformsCorrectly(int[] input, int expected)
    {
        // Arrange
        TheTwoPilesDifference TheTwoPilesDifference = new TheTwoPilesDifference();

        // Act
        var actual = TheTwoPilesDifference.FindMinDifference(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    private static IEnumerable<object[]> FindMinDifference_WhenCalled_PerformsCorrectly_Data()
    {
        yield return new object[] { new int[] { 7, 11, 1, 9, 10, 3, 5, 13, 9, 12 }, 6 };
        yield return new object[] { new int[] { 2, 3, 5, 4, 7, 4, 20, 17, 19, 18, 16, 20, 17, 2, 1, 3 }, 476 };
        yield return new object[] { new int[] { 2, 3, 5, 4, 7, 4, 1, 2, 4, 3, 6, 2, 17, 2, 1, 3 }, 1 };
        yield return new object[] { new int[] { 1, 2, 1, 3, 4, 4, 3, 6, 5, 6, 7, 8, 5, 3, 2, 2, 7, 7, 3, 4 }, 92 };
        yield return new object[] { new int[] { 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 1, 1, 1, 3, 2, 1, 2, 4, 2, 1, 2, 4, 2, 1, 2, 4, 2, 1, 2, 3, 2 }, 0 };
    }
}
