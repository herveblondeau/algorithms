using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.RecurringDecimals;

[TestClass]
public class RecurringDecimalsTests
{
    [TestMethod]
    [DataRow(4, "0.25")]
    [DataRow(8, "0.125")]
    [DataRow(10, "0.1")]
    [DataRow(25000, "0.00004")]
    [DataRow(195312500, "0.00000000512")]
    public void Invert_Terminating_PerformsCorrectly(int n, string expected)
    {
        // Arrange
        RecurringDecimals recurringDecimals = new();

        // Act
        var actual = recurringDecimals.Invert(n);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow(3, "0.(3)")]
    [DataRow(7, "0.(142857)")]
    [DataRow(561, "0.(0017825311942959)")]
    [DataRow(1931, "0.(00051786639047125841532884515794924909373381667529777317452097358881408596582081822889694458829621957534955981356809943034697048161574313827032625582599689280165717244950802692905230450543759709994821336095287415846711548420507509062661833247022268254790264111859140341791817711030554117037804246504401864319005696530295183842568617296737441740031071983428275504919730709476954945624029)")]
    public void Invert_NonTerminating_PerformsCorrectly(int n, string expected)
    {
        // Arrange
        RecurringDecimals recurringDecimals = new();

        // Act
        var actual = recurringDecimals.Invert(n);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow(210, "0.0(047619)")]
    [DataRow(44, "0.02(27)")]
    public void Invert_Mixed_PerformsCorrectly(int n, string expected)
    {
        // Arrange
        RecurringDecimals recurringDecimals = new();

        // Act
        var actual = recurringDecimals.Invert(n);

        // Assert
        actual.Should().Be(expected);
    }
}
