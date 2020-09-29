using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.ArraysAndStrings.CheckPermutation
{
    [TestClass]
    public class CheckPermutationTests
    {
        [TestMethod]
        [DataRow("a", "b")]
        [DataRow("abc", "caa")]
        public void ArePermutations_AreNotPermutations_ReturnsFalse(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = CheckPermutation.ArePermutations(str1, str2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("a", "a")]
        [DataRow("ab", "ab")]
        [DataRow("fdlifjdslk", "fdlifjdslk")]
        public void ArePermutations_AreIdentical_ReturnsTrue(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = CheckPermutation.ArePermutations(str1, str2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("ab", "ba")]
        [DataRow("abc", "cab")]
        [DataRow("fdlifjdslk", "kfdlifsjdl")]
        public void ArePermutations_ArePermutations_ReturnsTrue(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = CheckPermutation.ArePermutations(str1, str2);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
