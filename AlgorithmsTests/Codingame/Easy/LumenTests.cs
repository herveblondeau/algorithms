using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Easy.Lumen;

[TestClass]
public class LumenTests
{

    [TestMethod]
    [DynamicData(nameof(CountDarkSpots_WhenCalled_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void CountDarkSpots_WhenCalled_PerformsCorrectly(List<string> lines, int baseCandleLight, int expected)
    {
        // Arrange
        Lumen lumen = new();

        // Act
        var actual = lumen.CountDarkSpots(lines, baseCandleLight);

        // Assert
        actual.Should().Be(expected);
    }

    public static IEnumerable<object[]> CountDarkSpots_WhenCalled_PerformsCorrectly_Data()
    {
        // Codingame Only one candle
        yield return new object[]
        {
            new List<string>()
            {
                "X X X X X",
                "X C X X X",
                "X X X X X",
                "X X X X X",
                "X X X X X",
            }, 3, 9
        };

        // Codingame Ritual
        yield return new object[]
        {
            new List<string>()
            {
                "C X X X C",
                "X X X X X",
                "X X X X X",
                "X X X X X",
                "C X X X C",
            }, 3, 0
        };

        // Codingame Large pit
        yield return new object[]
        {
            new List<string>()
            {
                "X X X X X",
                "X C X X X",
                "X X X X X",
                "X X X C X",
                "X X X X X",
            }, 3, 2
        };

        // Codingame Small cellar
        yield return new object[]
        {
            new List<string>()
            {
                "X X X X X X",
                "X C X X X X",
                "X X X X X X",
                "X X X C X X",
                "X X X X X X",
                "X X X X X X",
            }, 3, 4
        };

        // Codingame Medium cellar
        yield return new object[]
        {
            new List<string>()
            {
                "X X X X X X X X X X X X C X X",
                "X X X X X X X X X X X X C X X",
                "X X X X X X X X X C X X X X X",
                "X X X X X C X X X X X X X X X",
                "X X X X C X X X X X X X X X X",
                "C X X X X X X X C X X C X X X",
                "X X X X X C X X X X X X X X C",
                "X C X X X X X X X X X X X X X",
                "X X X X X X X C X C X X X X X",
                "X X X X X X X X X X X X C X X",
                "X X X X X X X X X X X X X X X",
                "X X C X C X X X X X X X X X C",
                "X X X X X X C X X X C X X X X",
                "X C X X X X X X X X X X X X X",
                "X X X X X X X X X X X X X X X",
            }, 3, 14
        };

        // Codingame Large cellar
        yield return new object[]
        {
            new List<string>()
            {
                "X X X C X C X X X X X X X X X X X X X X",
                "X C X X X C X X X X C X X X X C X X X X",
                "X X X X X X X X X X X X X C C X X X X X",
                "X X X X X X X X X X X X X X X X X X X X",
                "X X X X X X X X X X X X X X X X X X X C",
                "X X X X X X X X C X X X X X X X C X X X",
                "X X X X X C X X X X X X X X C X X X X C",
                "X X X X X X C X X C C C X X X X X X X X",
                "X C X X X X X X X X C X X X C X X X X X",
                "X X X X C X X C X X X X X X X X X C X X",
                "X X X X X X X X X C X C X X X X X X X X",
                "X X X X X X X X X X X X X X X X X X X X",
                "X X X X X X C X X X X X X X X X X C X X",
                "X X X X X X X X X X X X X X X X X X X X",
                "X X X X X X X X X C C X X X X C X X X X",
                "X X X X X X X X X X X X C C C X X X X X",
                "X X X X X X X X C X X X X X X X C C X X",
                "X X X C X X X X X X X X X X X X X C X X",
                "X X X X X C X X X X X X X X X C X X X X",
                "X C X C X X X X X X X X X X X X X X X X",
            }, 3, 34
        };

        // Codingame Not very smart
        yield return new object[]
        {
            new List<string>()
            {
                "X X X",
                "X X X",
                "X X X",
            }, 3, 9
        };

        // Codingame Great hall
        yield return new object[]
        {
            new List<string>()
            {
                "X X C C C C X X X X C C X X X C X X X X X C X X X",
                "C X X X X X X X X X X X X X X C X X X X X X X X X",
                "X X X X X X X X X X X X C X X X X C X X X C C X X",
                "C X X X X C X X X X X X X X X X X X X C X X X X X",
                "X X C X C X X X X X X X X X C X X C X X X C X X X",
                "X X X X X C X X X X X X X C X C X X X X X X X X X",
                "C X X X X C C X X X X X X X X X C X X X X X X C X",
                "C X C C X X C X X C X X C C X X C X X X X X X X X",
                "X X X X X X X X X X X X X X X X X C X X X X X C X",
                "X C X X X X X X X X X X X X X X X X X C C X X X X",
                "C X X X X X X C X C X X X X C X X X X X C X X X X",
                "X C X X C X X X X X X X X X C X X X X X C X X X C",
                "X X X X X X X X X C X X C X X X X X X X X X C X X",
                "X X C X C X X X X X C X X X X X X C C X X X C X C",
                "C X C C X X X X X X X X X X C X X X X X C X X X X",
                "C X X C X C X X C C X X X C C X X X X X X X C C X",
                "C X X X X X X X X X X X X X X X X X X C X X X X X",
                "X X X X X X X C X X X X X X C X X X X X X X C X X",
                "X C X C X X C X X X X X C X X X X X X X C C X C X",
                "X X X C X X C C C X X C X X X X X C X X X X X X X",
                "X C X X X X X X X X X X X C X X X X X X X X X X X",
                "X X X C C X X C X C X X X X X X X X X C C X X X X",
                "X X C X X X X C X C C X X X X X C X X X X C C X X",
                "X X X X C X X X X X C X X X X X C X X X C X X C X",
                "X X X C X X C X X X X X X X X X X X C X X X X X X",
            }, 2, 90
        };

        // Codingame Not euclidean
        yield return new object[]
        {
            new List<string>()
            {
                "C X X X X",
                "X X X X X",
                "X X X X X",
                "X X X X X",
                "X X X X X",
            }, 4, 9
        };
    }
}
