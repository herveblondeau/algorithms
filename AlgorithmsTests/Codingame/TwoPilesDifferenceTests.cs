using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.TwoPilesDifference
{
    [TestClass]
    public class TwoPilesDifferenceTests
    {
        [TestMethod]
        //[DataRow(new int[] { 1, 2, 3, 4 }, 3)]
        //[DataRow(new int[] { 3, 4, 2, 1 }, 3)]
        //[DataRow(new int[] { 7, 7 }, 42)]
        //[DataRow(new int[] { 7, 11, 1, 9, 10, 3, 5, 13, 9, 12 }, 6)]
        //[DataRow(new int[] { 1, 9, 9, 12, 13, 5, 3, 7, 10, 11 }, 6)]
        [DataRow(new int[] { 12, 13, 5, 1, 9, 9, 3, 7, 10, 11 }, 6)]
        public void FindMaxPossibleLoss_WhenCalled_PerformsCorrectly(int[] values, int expected)
        {
            // Arrange
            TwoPilesDifference twoPilesDifference = new TwoPilesDifference();

            // Act
            var actual = twoPilesDifference.FindMinDifference(values);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
