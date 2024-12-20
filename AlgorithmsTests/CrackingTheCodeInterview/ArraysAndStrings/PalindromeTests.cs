using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.ArraysAndStrings.Palindrome;

[TestClass]
public class PalindromeTests
{
    [TestMethod]
    [DataRow("a")]
    [DataRow("aa")]
    [DataRow("aaa")]
    [DataRow("a aa")]
    [DataRow("aba")]
    [DataRow("abba")]
    [DataRow("abcba")]
    [DataRow("abccba")]
    [DataRow("abc cba")]
    [DataRow("  a bc c b  a")]
    [DataRow(" c a bc  b c a")]
    [DataRow("abbaa")]
    [DataRow("abbaa")]
    [DataRow("aabbcc")]
    [DataRow("aabbccb")]
    public void IsPalindromePermutation_IsPermutation_ReturnsTrue(string input)
    {
        // Arrange
        var palindrome = new Palindrome();

        // Act
        bool actual = palindrome.IsPalindromePermutation(input);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    [DataRow("ab")]
    [DataRow("abaa")]
    [DataRow("abc")]
    [DataRow("abcddcbb")]
    [DataRow("aaabbccbc")]
    [DataRow("aabbccbc")]
    public void IsPalindromePermutation_IsNotPermutation_ReturnsFalse(string input)
    {
        // Arrange
        var palindrome = new Palindrome();

        // Act
        bool actual = palindrome.IsPalindromePermutation(input);

        // Assert
        actual.Should().BeFalse();
    }
}
