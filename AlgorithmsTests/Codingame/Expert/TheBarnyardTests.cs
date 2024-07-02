using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.TheBarnyard;

[TestClass]
public class TheBarnyardTests
{

    [TestMethod]
    [DynamicData(nameof(GetAnimalCounts_WhenCalled_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void GetAnimalCounts_WhenCalled_PerformsCorrectly(string[] animals, Dictionary<string, int> bodyParts, Dictionary<string, int> expected)
    {
        // Arrange
        Barnyard Barnyard = new();

        // Act
        var actual = Barnyard.GetAnimalCounts(animals, bodyParts);

        // Assert
        actual.Should().Equal(expected);
    }

    private static IEnumerable<object[]> GetAnimalCounts_WhenCalled_PerformsCorrectly_Data()
    {
        yield return new object[] {
            new string[]
            {
                "Rabbits",
                "Chickens",
            },
            new Dictionary<string, int>
            {
                { "Heads", 5 },
                { "Legs", 14 },
            },
            new Dictionary<string, int>
            {
                { "Rabbits", 2 },
                { "Chickens", 3 },
            }
        };

        yield return new object[] {
            new string[]
            {
                "Rabbits",
                "Chickens",
                "Cows",
            },
            new Dictionary<string, int>
            {
                { "Heads", 9 },
                { "Horns", 6 },
                { "Wings", 8 },
            },
            new Dictionary<string, int>
            {
                { "Rabbits", 2 },
                { "Chickens", 4 },
                { "Cows", 3 },
            }
        };

        yield return new object[] {
            new string[]
            {
                "Cows",
                "Pegasi",
                "Demons",
                "Chickens",
                "Rabbits",
            },
            new Dictionary<string, int>
            {
                { "Eyes", 128 },
                { "Heads", 61 },
                { "Legs", 202 },
                { "Wings", 72 },
                { "Horns", 34 },
            },
            new Dictionary<string, int>
            {
                { "Cows", 11 },
                { "Pegasi", 12 },
                { "Demons", 3 },
                { "Chickens", 21 },
                { "Rabbits", 14 },
            }
        };
    }
}
