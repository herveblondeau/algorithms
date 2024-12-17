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
    [DataRow("38413", "94754", "84331")]
    [DataRow("7", "9", "7")]
    [DataRow("5678", "1234", "5678")]
    [DataRow("1111114", "5743211", "4111111")]
    [DataRow("1111", "5743", "1111")]
    [DataRow("87645", "94545", "87654")]
    [DataRow("57645", "64545", "64557")]
    public void GetClosestPermutation_SameLengthNoZero_PerformsCorrectly(string source, string target, string expected)
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation(source, target);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("284512", "2749", "122458")]
    public void GetClosestPermutation_SourceHasMoreDigits_PerformsCorrectly(string source, string target, string expected)
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation(source, target);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("3841", "94754", "8431")]
    public void GetClosestPermutation_TargetHasMoreDigits_PerformsCorrectly(string source, string target, string expected)
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation(source, target);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void GetClosestPermutation_LongestCommonPrefixIsNotAlwaysRight_Returns605()
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation("506", "590");

        // Assert
        actual.Should().Be("605");
    }

    [TestMethod]
    public void GetClosestPermutation_TwoOptimalPermutations_Returns59()
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation("95", "77");

        // Assert
        actual.Should().Be("59");
    }

    [TestMethod]
    public void GetClosestPermutation_MoreDigitsWithZero_Returns7400()
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation("4000007", "8732");

        // Assert
        actual.Should().Be("7400");
    }

    [TestMethod]
    [DataRow("3204", "111", "234")]
    public void GetClosestPermutation_SolutionWithLeadingZeros_PerformsCorrectly(string source, string target, string expected)
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation(source, target);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("3206728551185670554010350791869507515399395992812150593418419992328800823624820469621655802304007277", "7326581367582145004806383665233945377507377600408046588615944865665876581942889334261190569828488903", "7326581367582145004806383665233945377507377600408046588599999999999888555555422222222211111111000000")]
    [DataRow("8642242538055631617524294811801855026953643083364783686457199668942767318016752686970441336944170775", "326109542891426748982002851988852534440754028118693019568075668666208589185054111087919093749367321", "326109542891426748982002851988852534440754028118693019568111123333333444445555666666666667777777789")]
    [DataRow("5969595885695618786785761679766655778669767668086986197966685897555959969979656695575886995550667", "1919966618600212816232509941577901088896234308923963495498140856053683268598629231959786259278147", "1919966618599999999999999998888888888887777777777777766666666666666666666666555555555555555555500")]
    public void GetClosestPermutation_LargeNumbers_PerformsCorrectly(string source, string target, string expected)
    {
        // Arrange
        ClosestNumber closestNumber = new();

        // Act
        var actual = closestNumber.GetClosestPermutation(source, target);

        // Assert
        actual.Should().Be(expected);
    }

}
