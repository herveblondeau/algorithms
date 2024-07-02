using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TwoSum;

[TestClass]
public class TwoSumTests
{
    [TestMethod]
    [DataRow(new int[] { 2, 7, 11, 15 }, 9,  new int[] { 0, 1 })]
    [DataRow(new int[] { 3, 2, 4 }, 6,  new int[] { 1, 2 })]
    [DataRow(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [DataRow(new int[] { -5, 2, 3, 9, 11 }, 4, new int[] { 0, 3 })]
    public void TwoSum_WhenCalled_PerformsCorrectly(int[] numbers, int target, int[] expected)
    {
        // Arrange

        // Act
        int[] actual = TwoSum.Find(numbers, target);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
