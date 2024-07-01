using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Easy.LargestNumber
{
    [TestClass]
    public class LargestNumberTests
    {

        [TestMethod]
        [DataRow(3141, 3, 3141)]
        [DataRow(529307543, 8, 0)]
        [DataRow(72659, 5, 7265)]
        [DataRow(104890600, 9, 4890600)]
        [DataRow(675379052, 3, 67537905)]
        public void GetClosestPermutation_Miscellaneous_PerformsCorrectly(int number, int divisor, int expected)
        {
            // Arrange
            LargestNumber largestNumber = new();

            // Act
            var actual = largestNumber.GetLargest(number, divisor);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
