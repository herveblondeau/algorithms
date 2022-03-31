using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.LongestPalindrome
{
    [TestClass]
    public class LongestPalindromeTests
    {
        [TestMethod]
        [DataRow("madam", "madam")]
        public void GetLongestPalindrome_OneResult_PerformsCorrectly(string input, string expected)
        {
            // Arrange
            LongestPalindrome longestPalindrome = new LongestPalindrome();

            // Act
            var actual = longestPalindrome.GetLongestPalindromes(input);

            // Assert
            Assert.AreEqual(expected, actual[0]);
        }
    }
}
