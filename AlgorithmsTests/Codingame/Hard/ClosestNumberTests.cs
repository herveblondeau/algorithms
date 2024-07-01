using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.ClosestNumber
{
    [TestClass]
    public class ClosestNumberTests
    {

        [TestMethod]
        [DataRow("94754")]
        [DataRow("5")]
        [DataRow("7816053167431")]
        public void GetClosestPermutation_SameSourceAndTarget_ReturnsTarget(string target)
        {
            // Arrange
            ClosestNumber closestNumber = new();

            // Act
            var actual = closestNumber.GetClosestPermutation(target, target);

            // Assert
            Assert.AreEqual(target, actual);
        }

        [TestMethod]
        [DataRow("94754", "38413", "84331")]
        [DataRow("9", "7", "7")]
        [DataRow("1234", "5678", "5678")]
        [DataRow("5743211", "1111114", "4111111")]
        [DataRow("5743", "1111", "1111")]
        [DataRow("94545", "87645", "87654")]
        [DataRow("64545", "57645", "64557")]
        public void GetClosestPermutation_SameLengthNoZero_PerformsCorrectly(string target, string source, string expected)
        {
            // Arrange
            ClosestNumber closestNumber = new();

            // Act
            var actual = closestNumber.GetClosestPermutation(target, source);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("94754", "3841", "8431")]
        public void GetMinimumDrops_WhenCalled_PerformsCorrectly(string target, string source, string expected)
        {
            // Arrange
            ClosestNumber closestNumber = new();

            // Act
            var actual = closestNumber.GetClosestPermutation(target, source);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
