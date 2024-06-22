using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.NumberOfIslands
{
    [TestClass]
    public class NumberOfIslandsTests
    {

        [TestMethod]
        public void CountIslands_OneIsland_Returns1()
        {
            // Arrange
            int[,] spots = new int[,]
            {
                { 1,1,1,1,0 },
                { 1,1,0,1,0 },
                { 1,1,0,0,0 },
                { 0,0,0,0,0 }
            };
            NumberOfIslands numberOfIslandsSolver = new();

            // Act
            var actual = numberOfIslandsSolver.CountIslands(spots);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void CountIslands_TwoIslands_Returns2()
        {
            // Arrange
            int[,] spots = new int[,]
            {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 1, 0 },
                { 0, 0, 0, 1, 1 }
            };
            NumberOfIslands numberOfIslandsSolver = new();

            // Act
            var actual = numberOfIslandsSolver.CountIslands(spots);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void CountIslands_ThreeIslands_Returns3()
        {
            // Arrange
            int[,] spots = new int[,]
            {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 1 }
            };
            NumberOfIslands numberOfIslandsSolver = new();

            // Act
            var actual = numberOfIslandsSolver.CountIslands(spots);

            // Assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void CountIslands_ElevenIslands_Returns11()
        {
            // Arrange
            int[,] spots = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 1, 1, 0, 1 },
                { 0, 1, 0, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 1, 0, 0, 1, 0, 1 },
                { 1, 1, 0, 0, 1, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 },
            };
            NumberOfIslands numberOfIslandsSolver = new();

            // Act
            var actual = numberOfIslandsSolver.CountIslands(spots);

            // Assert
            Assert.AreEqual(11, actual);
        }
    }
}
