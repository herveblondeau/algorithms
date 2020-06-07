using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.ThreeNTiling
{
    [TestClass]
    public class ThreeNTilingTests
    {

        [TestMethod]
        [DataRow(1, 0)]
        [DataRow(2, 0)]
        [DataRow(3, 1)]
        [DataRow(4, 0)]
        [DataRow(5, 0)]
        [DataRow(6, 1)]
        [DataRow(7, 0)]
        [DataRow(8, 0)]
        [DataRow(9, 1)]
        [DataRow(10, 0)]
        [DataRow(19, 0)]
        [DataRow(23, 0)]
        [DataRow(33, 1)]
        [DataRow(69, 1)]
        public void GetNumberOfValidLayouts_Height1_PerformsCorrectly(int width, long expected)
        {
            // Arrange
            ThreeNTiling threeNTiling = new ThreeNTiling();

            // Act
            var actual = threeNTiling.GetNumberOfValidLayouts(width, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1, 0)]
        [DataRow(2, 1)]
        [DataRow(3, 1)]
        [DataRow(4, 1)]
        [DataRow(5, 2)]
        [DataRow(6, 2)]
        [DataRow(7, 3)]
        [DataRow(8, 4)]
        [DataRow(9, 5)]
        [DataRow(999891, 433872130)]
        [DataRow(929992, 366399507)]
        public void GetNumberOfValidLayouts_Height2_PerformsCorrectly(int width, long expected)
        {
            // Arrange
            ThreeNTiling threeNTiling = new ThreeNTiling();

            // Act
            var actual = threeNTiling.GetNumberOfValidLayouts(width, 2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(3, 2)]
        [DataRow(4, 3)]
        [DataRow(5, 4)]
        [DataRow(6, 8)]
        [DataRow(12, 154)]
        public void GetNumberOfValidLayouts_Height3_PerformsCorrectly(int width, long expected)
        {
            // Arrange
            ThreeNTiling threeNTiling = new ThreeNTiling();

            // Act
            var actual = threeNTiling.GetNumberOfValidLayouts(width, 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
