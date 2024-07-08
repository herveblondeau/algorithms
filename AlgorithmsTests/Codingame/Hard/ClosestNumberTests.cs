using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.ClosestNumber;

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
        actual.Should().Be(target);
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
        actual.Should().Be(expected);
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
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void GetMinimumDrops_CodingameLongestCommonPrefixIsNotAlwaysRight_Returns605()
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation("590", "506");

        // Assert
        actual.Should().Be("605");
    }

    [TestMethod]
    public void GetMinimumDrops_CodingameTwoOptimalPermutations_Returns95()
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation("77", "95");

        // Assert
        actual.Should().Be("59");
    }

    [TestMethod]
    public void GetMinimumDrops_CodingameMoreDigitsWithZero_Returns7400()
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation("8732", "4000007");

        // Assert
        actual.Should().Be("7400");
    }

    [TestMethod]
    [DataRow("7326581367582145004806383665233945377507377600408046588615944865665876581942889334261190569828488903", "3206728551185670554010350791869507515399395992812150593418419992328800823624820469621655802304007277", "7326581367582145004806383665233945377507377600408046588599999999999888555555422222222211111111000000")]
    public void GetMinimumDrops_CodingameLargeNumbers_PerformsCorrectly(string target, string source, string expected)
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation(target, source);

        // Assert
        actual.Should().Be(expected);
    }

}
