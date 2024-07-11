using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Easy.BankRobbers;

[TestClass]
public class BankRobbersTests
{
    [TestMethod]
    [DynamicData(nameof(ComputeHeistTime_WhenCalled_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void ComputeHeistTime_WhenCalled_PerformsCorrectly(int nbRobbers, List<(int, int)> vaultDescriptions, int expected)
    {
        // Arrange
        BankRobbers bankRobbers = new();

        // Act
        var result = bankRobbers.ComputeHeistTime(nbRobbers, vaultDescriptions);

        // Assert
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> ComputeHeistTime_WhenCalled_PerformsCorrectly_Data()
    {
        // Codingame One robber, one easy vault
        yield return new object[]
        {
            1,
            new List<(int, int)>()
            {
                (3, 1),
            },
            250
        };

        // Codingame More robbers, more vaults
        yield return new object[]
        {
            4,
            new List<(int, int)>()
            {
                (3, 2),
                (4, 1),
                (7, 6),
                (7, 1),
            },
            5000000
        };

        // Codingame Fewer robbers than vaults
        yield return new object[]
        {
            2,
            new List<(int, int)>()
            {
                (3, 1),
                (3, 2),
                (4, 0),
                (4, 0),
            },
            1125
        };

        // Codingame Big heist
        yield return new object[]
        {
            5,
            new List<(int, int)>()
            {
                (6, 3),
                (7, 1),
                (4, 4),
                (8, 4),
                (3, 0),
                (4, 3),
                (8, 1),
                (3, 3),
                (5, 5),
                (7, 6),
                (6, 2),
                (5, 3),
                (5, 4),
                (7, 0),
                (7, 0),
                (8, 4),
                (6, 0),
                (6, 5),
                (3, 2),
                (4, 2),
            },
            6515625
        };
    }
}
