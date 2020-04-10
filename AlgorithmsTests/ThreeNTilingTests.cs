using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class ThreeNTilingTests
    {

        [TestMethod]
        //[DataRow(1, 3, 1)]
        //[DataRow(3, 1, 1)]
        //[DataRow(2, 2, 1)]
        //[DataRow(1, 6, 1)]
        [DataRow(2, 6, 2)]
        //[DataRow(3, 6, 8)]
        public void GetNumberOfValidLayouts_WhenCalled_PerformsCorrectly(int width, int height, int expected)
        {
            // Arrange
            ThreeNTiling threeNTiling = new ThreeNTiling();

            // Act
            var actual = threeNTiling.GetNumberOfValidLayouts(width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
