using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.LongestPalindrome;

[TestClass]
public class LongestPalindromeTests
{
    [TestMethod]
    [DataRow("madam", "madam")]
    public void GetLongestPalindrome_OneResult_PerformsCorrectly(string input, string expected)
    {
        // Arrange
        LongestPalindrome longestPalindrome = new();

        // Act
        var actual = longestPalindrome.GetLongestPalindromes(input);

        // Assert
        actual[0].Should().Be(expected);
    }
}
