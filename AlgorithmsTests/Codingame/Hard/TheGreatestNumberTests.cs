using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.TheGreatestNumber;

[TestClass]
public class TheGreatestNumberTests
{

    [TestMethod]
    [DataRow("5", "5")]
    [DataRow("58250", "85520")]
    [DataRow("0000", "0")]
    public void GetGreatest_PositiveInteger_PerformsCorrectly(string input, string expected)
    {
        // Arrange
        TheGreatestNumber theGreatestNumber = new();

        // Act
        var actual = theGreatestNumber.GetGreatest(input);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("5-", "-5")]
    [DataRow("58-250", "-2558")]
    [DataRow("0-0000", "0")]
    public void GetGreatest_NegativeInteger_PerformsCorrectly(string input, string expected)
    {
        // Arrange
        TheGreatestNumber theGreatestNumber = new();

        // Act
        var actual = theGreatestNumber.GetGreatest(input);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("3.5", "5.3")]
    [DataRow("0.5", "5")]
    [DataRow("5.8259", "9855.2")]
    [DataRow("5.8250", "8552")]
    [DataRow("0001000.", "100000")]
    [DataRow("000.0", "0")]
    public void GetGreatest_PositiveDecimal_PerformsCorrectly(string input, string expected)
    {
        // Arrange
        TheGreatestNumber theGreatestNumber = new();

        // Act
        var actual = theGreatestNumber.GetGreatest(input);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("-.35", "-3.5")]
    [DataRow("-0.5", "-0.5")]
    [DataRow("-582.59", "-2.5589")]
    [DataRow("-58.250", "-0.2558")]
    [DataRow("-0000000.", "0")]
    public void GetGreatest_NegativeDecimal_PerformsCorrectly(string input, string expected)
    {
        // Arrange
        TheGreatestNumber theGreatestNumber = new();

        // Act
        var actual = theGreatestNumber.GetGreatest(input);

        // Assert
        actual.Should().Be(expected);
    }
}
