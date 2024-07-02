using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.KGood;

[TestClass]
public class KGoodTests
{
    [TestMethod]
    [DataRow("aaaaabcdef", 3, 7)]
    [DataRow("aabacdef", 5, 7)]
    [DataRow("aaaaabcdef", 26, 10)]
    public void GetLongestLength_WhenCalled_PerformsCorrectly(string input, int k, int expected)
    {
        // Arrange
        KGood kGood = new();

        // Act
        var actual = kGood.GetLongestKSubstringLength(input, k);

        // Assert
        actual.Should().Be(expected);
    }
}
