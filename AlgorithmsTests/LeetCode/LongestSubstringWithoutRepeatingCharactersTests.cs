using AwesomeAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.LongestSubstringWithoutRepeatingCharacters;

[TestClass]
public class LongestSubstringWithoutRepeatingCharactersTests
{
    [TestMethod]
    [DataRow("abcabcbb", 3)]
    [DataRow("bbbbb", 1)]
    [DataRow("pwwkew", 3)]
    [DataRow("abcdefaghiklmna", 13)]
    [DataRow("abcdefaghiklmn", 13)]
    public void LengthOfLongestSubstring_PerformsCorrectly(string input, int expected)
    {
        // Arrange
        LongestSubstringWithoutRepeatingCharacters longestSubstringWithoutRepeatingCharacters = new();

        // Act
        var actual = longestSubstringWithoutRepeatingCharacters.GetLength(input);

        // Assert
        actual.Should().Be(expected);
    }
}
