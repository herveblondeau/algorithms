using AwesomeAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode.LetterCombinationsOfPhoneNumber;

[TestClass]
public class LetterCombinationsOfPhoneNumberTests
{
    [TestMethod]
    [DataRow("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    [DataRow("2", new string[] { "a", "b", "c" })]
    public void FindAllDuplicates_NoDuplicate_ReturnsEmptyArray(string digits, string[] expected)
    {
        // Arrange
        var letterCombinationsOfPhoneNumber = new LetterCombinationsOfPhoneNumber();

        // Act
        var actual = letterCombinationsOfPhoneNumber.LetterCombinations(digits);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
