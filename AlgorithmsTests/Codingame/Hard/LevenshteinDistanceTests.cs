using Codingame.Hard.LevenshteinDistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.LevenshteinDistance
{
    [TestClass]
    public class LevenshteinDistanceTests
    {
        [TestMethod]
        [DataRow("test", "test")]
        [DataRow("lazy dog", "lazy dog")]
        public void GetDistance_IdenticalStrings_ReturnsZero(string source, string target)
        {
            // Arrange
            LevenshteinDistance levenshteinDistance = new();

            // Act
            var actual = levenshteinDistance.GetDistance(source, target);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow("text", "test", 1)]
        [DataRow("text", "tint", 2)]
        [DataRow("triumph", "tempted", 6)]
        [DataRow("The carrots are cooked", "The parrots are sleepy", 7)]
        public void GetDistance_SameLength_PerformsCorrectly(string source, string target, int expected)
        {
            // Arrange
            LevenshteinDistance levenshteinDistance = new();

            // Act
            var actual = levenshteinDistance.GetDistance(source, target);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("text", "tests", 2)]
        [DataRow("text", "tints", 3)]
        //[DataRow("triumph", "attempted", 6)]
        //[DataRow("The carrots are cooked", "The parrots are not here", 7)]
        public void GetDistance_DifferentLength_PerformsCorrectly(string source, string target, int expected)
        {
            // Arrange
            LevenshteinDistance levenshteinDistance = new();

            // Act
            var actual = levenshteinDistance.GetDistance(source, target);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
