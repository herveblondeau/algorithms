using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.ArraysAndStrings.IsUnique
{
    [TestClass]
    public class IsUniqueTests
    {
        [TestMethod]
        [DataRow("", true)]
        public void HasAllUniqueChars_EdgeCases_PerformsCorrectly(string input, bool expected)
        {
            // Arrange

            // Act
            bool actual = IsUnique.HasAllUniqueChars(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("a")]
        [DataRow("ab")]
        [DataRow("abcd")]
        [DataRow("abcdefghijklmnopqrstuvwxyz")]
        public void HasAllUniqueChars_AllUniqueChars_ReturnsTrue(string input)
        {
            // Arrange

            // Act
            bool actual = IsUnique.HasAllUniqueChars(input);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("aa")]
        [DataRow("abb")]
        [DataRow("abcdb")]
        [DataRow("abcdefghijkllmnopqrstuvwxyz")]
        [DataRow("abcdefghijklmnopqrstcuvwxyz")]
        public void HasAllUniqueChars_DuplicateChars_ReturnsFalse(string input)
        {
            // Arrange

            // Act
            bool actual = IsUnique.HasAllUniqueChars(input);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
