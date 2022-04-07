using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.SlidingPuzzle
{
    [TestClass]
    public class SlidingPuzzleTests
    {

        [TestMethod]
        public void Test1()
        {
            // Arrange
            SlidingPuzzle slidingPuzzle = new SlidingPuzzle();
            int[,] start = new int[,]
            {
                { 2, 3 },
                { 1, 0 },
            };
            int[,] end = new int[,]
            {
                { 1, 2 },
                { 3, 0 },
            };

            // Act
            var actual = slidingPuzzle.GetNumberOfMoves(start, end);

            // Assert
            Assert.AreEqual(4, actual);
        }

        [TestMethod]
        public void Test2()
        {
            // Arrange
            SlidingPuzzle slidingPuzzle = new SlidingPuzzle();
            int[,] start = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 0, 7 },
            };
            int[,] end = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 0 },
            };

            // Act
            var actual = slidingPuzzle.GetNumberOfMoves(start, end);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Test3()
        {
            // Arrange
            SlidingPuzzle slidingPuzzle = new SlidingPuzzle();
            int[,] start = new int[,]
            {
                { 4, 1, 2 },
                { 0, 6, 3 },
                { 7, 5, 8 },
            };
            int[,] end = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 },
            };

            // Act
            var actual = slidingPuzzle.GetNumberOfMoves(start, end);

            // Assert
            Assert.AreEqual(7, actual);
        }

    }
}
