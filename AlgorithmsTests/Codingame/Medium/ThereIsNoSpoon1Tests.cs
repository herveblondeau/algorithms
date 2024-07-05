using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.ThereIsNoSpoon1;

[TestClass]
public class ThereIsNoSpoon1Tests
{
    [TestMethod]
    [DynamicData(nameof(GetNodes_WhenCalled_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void GetNodes_WhenCalled_PerformsCorrectly(int[,] grid, List<string> expected)
    {
        // Arrange
        ThereIsNoSpoon1 thereIsNoSpoon = new();

        // Act
        // We declare the inputs in the test method below in a human readable way, with the first index being the vertical one
        // But the tested method expects the opposite, with a horizontal first index
        // Therefore we need to transpose the input grid first
        var actual = thereIsNoSpoon.GetNodes(_transpose(grid));

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    private int[,] _transpose(int[,] input)
    {
        int width = input.GetLength(0);
        int height = input.GetLength(1);
        int[,] result = new int[height,width];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                result[y, x] = input[x, y];
            }
        }

        return result;
    }

    public static IEnumerable<object[]> GetNodes_WhenCalled_PerformsCorrectly_Data()
    {
        // Codingame example
        yield return new object[]
        {
            new int[,]
            {
                { 1, 1 },
                { 1, 0 },
            },
            new List<string>()
            {
                "0 0 1 0 0 1",
                "0 1 -1 -1 -1 -1",
                "1 0 -1 -1 -1 -1",
            }
        };

        // Codingame horizontal
        yield return new object[]
        {
            new int[,]
            {
                { 1, 0, 1, 0, 1 },
            },
            new List<string>()
            {
                "0 0 2 0 -1 -1",
                "2 0 4 0 -1 -1",
                "4 0 -1 -1 -1 -1",
            }
        };

        // Codingame square
        yield return new object[]
        {
            new int[,]
            {
                { 1, 0, 1 },
                { 0, 0, 0 },
                { 1, 0, 1 },
            },
            new List<string>()
            {
                "0 0 2 0 0 2",
                "0 2 2 2 -1 -1",
                "2 0 -1 -1 2 2",
                "2 2 -1 -1 -1 -1",
            }
        };

        // Codingame T
        yield return new object[]
        {
            new int[,]
            {
                { 1, 1, 1 },
                { 0, 1, 0 },
                { 0, 1, 0 },
            },
            new List<string>()
            {
                "0 0 1 0 -1 -1",
                "1 0 2 0 1 1",
                "1 1 -1 -1 1 2",
                "1 2 -1 -1 -1 -1",
                "2 0 -1 -1 -1 -1",
            }
        };

        // Codingame Diagonal
        yield return new object[]
        {
            new int[,]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 },
            },
            new List<string>()
            {
                "0 0 -1 -1 -1 -1",
                "1 1 -1 -1 -1 -1",
                "2 2 -1 -1 -1 -1",
                "3 3 -1 -1 -1 -1",
            }
        };

        // Codingame Complex
        yield return new object[]
        {
            new int[,]
            {
                { 1, 1, 0, 1 },
                { 1, 0, 1, 1 },
                { 0, 1, 0, 1 },
                { 1, 1, 1, 0 },
            },
            new List<string>()
            {
                "0 0 1 0 0 1",
                "0 1 2 1 0 3",
                "0 3 1 3 -1 -1",
                "1 0 3 0 1 2",
                "1 2 3 2 1 3",
                "1 3 2 3 -1 -1",
                "2 1 3 1 2 3",
                "2 3 -1 -1 -1 -1",
                "3 0 -1 -1 3 1",
                "3 1 -1 -1 3 2",
                "3 2 -1 -1 -1 -1",
            }
        };

        // Codingame Shuriken
        yield return new object[]
        {
            new int[,]
            {
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0 },
            },
            new List<string>()
            {
                "0 4 2 4 -1 -1",
                "2 0 -1 -1 2 2",
                "2 2 4 2 2 4",
                "2 4 4 4 -1 -1",
                "4 2 6 2 4 4",
                "4 4 -1 -1 4 6",
                "4 6 -1 -1 -1 -1",
                "6 2 -1 -1 -1 -1",
            }
        };
    }
}
