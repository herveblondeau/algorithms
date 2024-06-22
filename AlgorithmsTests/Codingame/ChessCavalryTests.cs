using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.ChessCavalry
{
    [TestClass]
    public class ChessCavalryTests
    {

        [TestMethod]
        [DynamicData(nameof(GetDistance_AlreadyAtTarget_ReturnsZero_Data), DynamicDataSourceType.Method)]
        public void GetDistance_AlreadyAtTarget_ReturnsZero(int width, int height, int startX, int startY, (int, int)[] obstacles)
        {
            // Arrange
            ChessCavalry chessCavalry = new ChessCavalry();

            // Act
            var actual = chessCavalry.GetDistance(width, height, (startX, startY), (startX, startY), obstacles);

            // Assert
            Assert.AreEqual(0, actual);
        }

        private static IEnumerable<object[]> GetDistance_AlreadyAtTarget_ReturnsZero_Data()
        {
            yield return new object[] { 3, 2, 0, 2, new (int, int)[0] { } };
            yield return new object[] { 3, 2, 0, 2, new (int, int)[1] { (1, 1) } };
        }

        [TestMethod]
        [DynamicData(nameof(GetDistance_NoObstacle_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
        public void GetDistance_NoObstacle_PerformsCorrectly(int width, int height, (int,int) start, (int, int) target, int expected)
        {
            // Arrange
            ChessCavalry chessCavalry = new ChessCavalry();

            // Act
            var actual = chessCavalry.GetDistance(width, height, start, target, []);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> GetDistance_NoObstacle_PerformsCorrectly_Data()
        {
            yield return new object[] { 3, 2, (0, 0), (2, 1), 1 };
            yield return new object[] { 3, 2, (0, 2), (2, 1), 1 };
            yield return new object[] { 5, 3, (0, 1), (3, 2), 2 };
        }

        [TestMethod]
        [DynamicData(nameof(GetDistance_WithObstacles_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
        public void GetDistance_WithObstacles_PerformsCorrectly(int width, int height, (int, int) start, (int, int) target, (int, int)[] obstacles, int expected)
        {
            // Arrange
            ChessCavalry chessCavalry = new ChessCavalry();

            // Act
            var actual = chessCavalry.GetDistance(width, height, start, target, obstacles);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> GetDistance_WithObstacles_PerformsCorrectly_Data()
        {
            yield return new object[] { 5, 3, (0, 1), (3, 2), new (int, int)[1] { (2, 0) }, 4 };
        }
    }
}
