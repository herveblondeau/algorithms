using Codingame.SpeedCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.WaterJugRiddle
{
    [TestClass]
    public class WaterJugRiddleTests
    {

        [TestMethod]
        [DataRow(new int[] { 2 }, 2)]
        [DataRow(new int[] { 3, 5 }, 3)]
        [DataRow(new int[] { 3, 5 }, 5)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 3)]
        public void GetNumberOfMoves_GoalMatchingACapacity_ReturnsOne(int[] capacities, int goal)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 5 }, 2)]
        [DataRow(new int[] { 5, 3 }, 2)]
        public void GetNumberOfMoves_GoalMatchingDifferenceBetweenTwoCapacities_ReturnsTwo(int[] capacities, int goal)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 7, 9 }, 4, 6)]
        public void GetNumberOfMoves_VariousCases_PerformsCorrectly(int[] capacities, int goal, int expected)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
