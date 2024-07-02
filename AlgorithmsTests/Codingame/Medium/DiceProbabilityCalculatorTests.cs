using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codingame.Medium.DiceProbabilityCalculator;

[TestClass]
public class DiceProbabilityCalculatorTests
{

    [TestMethod]
    [DynamicData(nameof(ComputeProbabilities_Miscellaneous_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void ComputeProbabilities_Miscellaneous_PerformsCorrectly(string input, Dictionary<int, double> expected)
    {
        // Arrange
        DiceProbabilityCalculator DiceProbabilityCalculator = new();

        // Act
        var actual = DiceProbabilityCalculator.ComputeProbabilities(input);
        foreach (var key in actual.Keys)
        {
            actual[key] = Math.Round(actual[key] * 100, 2);
        }

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    private static IEnumerable<object[]> ComputeProbabilities_Miscellaneous_PerformsCorrectly_Data()
    {
        yield return new object[] { "1+d4+1", new Dictionary<int, double>()
        {
            { 3, 25 },
            { 4, 25 },
            { 5, 25 },
            { 6, 25 },
        } };

        yield return new object[] { "(2>5)+2*(5>2)+4*(10>5)", new Dictionary<int, double>()
        {
            { 6, 100 },
        } };

        yield return new object[] { "d6+d6", new Dictionary<int, double>()
        {
            { 2, 2.78 },
            { 3, 5.56 },
            { 4, 8.33 },
            { 5, 11.11 },
            { 6, 13.89 },
            { 7, 16.67 },
            { 8, 13.89 },
            { 9, 11.11 },
            { 10, 8.33 },
            { 11, 5.56 },
            { 12, 2.78 },
        } };

        yield return new object[] { "8>d6+d6", new Dictionary<int, double>()
        {
            { 0, 41.67 },
            { 1, 58.33 },
        } };

        yield return new object[] { "d9-2*d4", new Dictionary<int, double>()
        {
            { -7, 2.78 },
            { -6, 2.78 },
            { -5, 5.56 },
            { -4, 5.56 },
            { -3, 8.33 },
            { -2, 8.33 },
            { -1, 11.11 },
            { 0, 11.11 },
            { 1, 11.11 },
            { 2, 8.33 },
            { 3, 8.33 },
            { 4, 5.56 },
            { 5, 5.56 },
            { 6, 2.78 },
            { 7, 2.78 },
        } };

        yield return new object[] { "12-d2*d6", new Dictionary<int, double>()
        {
            { 0, 8.33 },
            { 2, 8.33 },
            { 4, 8.33 },
            { 6, 16.67 },
            { 7, 8.33 },
            { 8, 16.67 },
            { 9, 8.33 },
            { 10, 16.67 },
            { 11, 8.33 },
        } };

        yield return new object[] { "2*d6*d3-(3+d3)*d5>0", new Dictionary<int, double>()
        {
            { 0, 59.63 },
            { 1, 40.37 },
        } };
    }
}
