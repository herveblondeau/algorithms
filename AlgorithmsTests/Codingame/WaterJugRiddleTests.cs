using Codingame.SpeedCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.WaterJugRiddle
{
    [TestClass]
    public class WaterJugRiddleTests
    {

        // Cases where we just need to fill a jug
        [TestMethod]
        [DataRow(new int[] { 2 }, 2)]
        [DataRow(new int[] { 3, 5 }, 3)]
        [DataRow(new int[] { 3, 5 }, 5)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 3)]
        public void GetDistance_GoalMatchingACapacity_ReturnsOne(int[] capacities, int goal)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(1, actual);
        }

        // Cases where we just need to fill a jug then pour it into another one
        [TestMethod]
        [DataRow(new int[] { 3, 5 }, 2)]
        [DataRow(new int[] { 5, 3 }, 2)]
        [DataRow(new int[] { 2, 8, 5, 12 }, 3)]
        public void GetDistance_GoalMatchingDifferenceBetweenTwoCapacities_ReturnsTwo(int[] capacities, int goal)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(2, actual);
        }

        // 
        [TestMethod]
        [DataRow(new int[] { 7, 9 }, 4, 6)]
        [DataRow(new int[] { 3, 5 }, 4, 6)]
        [DataRow(new int[] { 2, 9, 3 }, 5, 4)]
        [DataRow(new int[] { 2, 9, 3 }, 4, 3)]
        public void GetDistance_VariousCases_PerformsCorrectly(int[] capacities, int goal, int expected)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // 
        [TestMethod]
        [DataRow(new int[] { 7, 9, 4 }, 4, 1)]
        [DataRow(new int[] { 7, 9, 5 }, 4, 2)]
        [DataRow(new int[] { 17, 19, 43, 45 }, 4, 5)]
        [DataRow(new int[] { 17, 19, 3, 3 }, 4, 6)]
        public void GetDistance_MultipleSolutions_ReturnsTheShortestOne(int[] capacities, int goal, int expected)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2 }, 3)]
        public void GetDistance_ImpossibleCases_ReturnsMinusOne(int[] capacities, int goal)
        {
            // Arrange
            WaterJugRiddle waterJugRiddle = new WaterJugRiddle();

            // Act
            var actual = waterJugRiddle.GetDistance(capacities, goal);

            // Assert
            Assert.AreEqual(-1, actual);
        }
    }
}
