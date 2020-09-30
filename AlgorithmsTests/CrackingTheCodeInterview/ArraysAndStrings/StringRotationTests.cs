using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.ArraysAndStrings.StringRotation
{
    [TestClass]
    public class StringRotationTests
    {
        [TestMethod]
        [DataRow("a", "b")]
        [DataRow("abcde", "edabc")]
        public void AreRotations_AreNotRotations_ReturnsFalse(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = StringRotation.AreRotations(str1, str2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("a", "a")]
        [DataRow("ab", "ab")]
        [DataRow("fdlifjdslk", "fdlifjdslk")]
        public void AreRotations_AreIdentical_ReturnsTrue(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = StringRotation.AreRotations(str1, str2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("ab", "ba")]
        [DataRow("abc", "cab")]
        [DataRow("abcde", "deabc")]
        [DataRow("abcdefghijklmno", "klmnoabcdefghij")]
        public void AreRotations_AreRotations_ReturnsTrue(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = StringRotation.AreRotations(str1, str2);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
