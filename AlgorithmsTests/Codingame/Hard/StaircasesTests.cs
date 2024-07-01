using Codingame.Hard.Staircases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.Hard.Staircases
{
    [TestClass]
    public class StaircasesTests
    {

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void GetNumberOfStaircases_NotEnoughBricks_ReturnsZero(int bricks)
        {
            // Arrange
            Staircases staircases = new();

            // Act
            var actual = staircases.GetNumberOfStaircases(bricks);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow(3, 1)]
        [DataRow(5, 2)]
        [DataRow(10, 9)]
        [DataRow(25, 141)]
        //[DataRow(500, 2300)]
        public void GetNumberOfStaircases_WhenCalled_PerformsCorrectly(int bricks, int expected)
        {
            // Arrange
            Staircases staircases = new();

            // Act
            var actual = staircases.GetNumberOfStaircases(bricks);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
