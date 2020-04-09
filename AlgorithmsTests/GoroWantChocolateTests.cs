using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class GoroWantChocolateTests
    {

        [TestMethod]
        [DataRow(5, 3, 4)]
        [DataRow(13, 51, 10)]
        [DataRow(97, 101, 22)]
        [DataRow(149, 150, 12)]
        public void GetMinimalNumberOfSquares_WhenCalled_PerformsCorrectly(int width, int height, int expected)
        {
            // Arrange
            GoroWantChocolate goroWantChocolate = new GoroWantChocolate();

            // Act
            var actual = goroWantChocolate.GetMinimalNumberOfSquares(width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
