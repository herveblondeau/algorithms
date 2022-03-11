using Codingame.SpeedCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.Elevator
{
    [TestClass]
    public class ElevatorTests
    {

        [TestMethod]
        [DataRow(1, 1, 1, 1)]
        [DataRow(1, 1, 10, 5)]
        [DataRow(50, 200, 10, 36)]
        public void GetNumberOfPresses_AlreadyAtEndFloor_ReturnsZero(int nbFloors, int current, int up, int down)
        {
            // Arrange
            Elevator elevator = new Elevator();

            // Act
            var actual = elevator.GetNumberOfPresses(nbFloors, current, current, up, down);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow(10, 5, 8, 1, 1, 3)]
        [DataRow(10, 1, 9, 2, 8, 4)]
        public void GetNumberOfPresses_GoingOnlyUp_PerformsCorrectly(int nbFloors, int start, int target, int up, int down, int expected)
        {
            // Arrange
            Elevator elevator = new Elevator();

            // Act
            var actual = elevator.GetNumberOfPresses(nbFloors, start, target, up, down);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //[DataRow(10, 8, 5, 1, 1, 3)]
        [DataRow(10, 9, 1, 8, 2, 4)]
        public void GetNumberOfPresses_GoingOnlyDown_PerformsCorrectly(int nbFloors, int start, int target, int up, int down, int expected)
        {
            // Arrange
            Elevator elevator = new Elevator();

            // Act
            var actual = elevator.GetNumberOfPresses(nbFloors, start, target, up, down);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(10, 1, 5, 3, 2, 3)] // 1->4->7->5
        [DataRow(20, 3, 18, 8, 5, 10)] // 3->11->19->14->9->17->12->7->15->10->18
        [DataRow(20, 3, 6, 2, 7, 6)] // 3->5->7->9->2->4->6
        [DataRow(20, 1, 4, 2, 17, 11)] // 1->3->5->7->9->11->13->15->17->19->2->4
        public void GetNumberOfPresses_GoingUpWithVariations_PerformsCorrectly(int nbFloors, int start, int target, int up, int down, int expected)
        {
            // Arrange
            Elevator elevator = new Elevator();

            // Act
            var actual = elevator.GetNumberOfPresses(nbFloors, start, target, up, down);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(10, 5, 1, 2, 3, 3)] // 5->7->4->1
        [DataRow(20, 3, 18, 8, 5, 10)] // 18->10->15->7->12->17->9->14->19->11->3
        [DataRow(20, 3, 6, 2, 7, 6)] // 6->4->2->9->7->5->3
        [DataRow(20, 4, 1, 17, 2, 11)] // 4->2->19->17->15->13->11->9->7->5->3->1
        public void GetNumberOfPresses_GoingDownWithVariations_PerformsCorrectly(int nbFloors, int start, int target, int up, int down, int expected)
        {
            // Arrange
            Elevator elevator = new Elevator();

            // Act
            var actual = elevator.GetNumberOfPresses(nbFloors, start, target, up, down);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(3, 1, 2, 3, 3)] // Cannot move up or down
        [DataRow(20, 11, 12, 6, 4)] // Cannot reach the target floor with the given buttons
        [DataRow(20, 1, 4, 2, 19)] // Cannot move down
        public void GetNumberOfPresses_ImpossibleCases_ReturnsMinusOne(int nbFloors, int start, int target, int up, int down)
        {
            // Arrange
            Elevator elevator = new Elevator();

            // Act
            var actual = elevator.GetNumberOfPresses(nbFloors, start, target, up, down);

            // Assert
            Assert.AreEqual(-1, actual);
        }
    }
}
