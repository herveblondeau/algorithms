using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codingame.Asteroids
{
    [TestClass]
    public class AsteroidsTests
    {

        [TestMethod]
        public void GetState3_HorizontalMotion_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['A', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

            // Assert
            char[][] expected = [
                ['.', '.', 'A', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_VerticalMotion_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['A', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', '.', '.', '.', '.'],
                ['A', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

            // Assert
            char[][] expected = [
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['A', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_CombinedMotion_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['A', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', '.', '.', '.', '.'],
                ['.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

            // Assert
            char[][] expected = [
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', 'A', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_NegativeMotion_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', 'A', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', '.', '.', '.', '.'],
                ['.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

            // Assert
            char[][] expected = [
                ['A', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_GreaterDelta_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['A', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', '.', '.', '.', 'A', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 5, state2, 6);

            // Assert
            char[][] expected = [
                ['.', '.', '.', '.', '.', 'A'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_MultipleAsteroids_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['A', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['B', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', 'A', '.', '.', '.', '.'],
                ['B', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 3, state2, 5);

            // Assert
            char[][] expected = [
                ['B', '.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_NoMotion_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['.', '.', '.', '.', '.'],
                ['.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', 'D', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', '.', '.', '.', '.'],
                ['.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', 'D', '.'],
                ['.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(0, state1, 1255, state2, 9999);

            // Assert
            char[][] expected = [
                ['.', '.', '.', '.', '.'],
                ['.', 'A', '.', '.', '.'],
                ['.', '.', '.', '.', '.'],
                ['.', '.', '.', 'D', '.'],
                ['.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_Depth_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['.', '.', 'H', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['E', '.', '.', '.', 'G', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', 'F', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];
            char[][] state2 = [
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', 'H', '.', '.', '.'],
                ['.', 'E', '.', 'G', '.', '.'],
                ['.', '.', 'F', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

            // Assert
            char[][] expected = [
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', 'E', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void GetState3_OutOfBounds_PerformsCorrectly()
        {
            // Arrange
            Asteroids Asteroids = new();
            char[][] state1 = [
                ['A', '.', '.'],
                ['B', '.', '.'],
                ['C', '.', '.'],
            ];
            char[][] state2 = [
                ['B', 'A', '.'],
                ['.', '.', '.'],
                ['.', '.', 'C'],
            ];

            // Act
            var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

            // Assert
            char[][] expected = [
                ['.', '.', 'A'],
                ['.', '.', '.'],
                ['.', '.', '.'],
            ];
            Assert.IsTrue(AreEqual(expected, actual));
        }

        private bool AreEqual(char[][] a, char[][] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[0].Length; j++)
                {
                    if (a[i][j] != b[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
