using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.UnfloodTheWorld
{
    [TestClass]
    public class UnfloodTheWorldTests
    {

        [TestMethod]
        public void Wall1()
        {
            // Arrange
            UnfloodTheWorld unfloodTheWorld = new UnfloodTheWorld();
            int[,] map = new int[,]
            {
                { 1, 1, 9, 1, 1 },
                { 1, 1, 9, 1, 1 },
                { 1, 1, 9, 1, 1 }
            };

            // Act
            var actual = unfloodTheWorld.GetNumberOfDrains(map);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Wall2()
        {
            // Arrange
            UnfloodTheWorld unfloodTheWorld = new UnfloodTheWorld();
            int[,] map = new int[,]
            {
                { 2, 2, 9, 1, 1 },
                { 2, 2, 9, 1, 1 },
                { 2, 2, 9, 1, 1 }
            };

            // Act
            var actual = unfloodTheWorld.GetNumberOfDrains(map);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Hill()
        {
            // Arrange
            UnfloodTheWorld unfloodTheWorld = new UnfloodTheWorld();
            int[,] map = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 2, 2, 2, 2, 2, 1 },
                { 1, 2, 3, 9, 3, 2, 1 },
                { 1, 2, 2, 2, 2, 2, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
            };

            // Act
            var actual = unfloodTheWorld.GetNumberOfDrains(map);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Plateaus()
        {
            // Arrange
            UnfloodTheWorld unfloodTheWorld = new UnfloodTheWorld();
            int[,] map = new int[,]
            {
                { 1, 1, 2, 2, 3, 3 },
                { 1, 1, 2, 2, 3, 3 },
                { 6, 6, 5, 5, 4, 4 },
                { 6, 6, 5, 5, 4, 4 },
                { 7, 7, 8, 8, 9, 9 },
                { 7, 7, 8, 8, 9, 9 },
            };

            // Act
            var actual = unfloodTheWorld.GetNumberOfDrains(map);

            // Assert
            Assert.AreEqual(1, actual);
        }

    }
}
