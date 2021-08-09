using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.SortedSquareArray
{
    [TestClass]
    public class SortedSquareArrayTests
    {
        [TestMethod]
        [DataRow(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
        [DataRow(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
        public void Sort_OneColor_PerformsCorrectly(int[] numbers, int[] expected)
        {
            // Arrange

            // Act
            int[] actual = SortedSquareArray.SortSquares(numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
