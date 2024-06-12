using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Dijkstra;

[TestClass]
public class BreadthFirstSearchTests
{
    [TestMethod]
    [DynamicData(nameof(GetShortestPath_WhenConnected_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void GetShortestPath_WhenConnected_PerformsCorrectly(string from, string to, List<string> expected)
    {
        // Arrange
        Dictionary<string, List<string>> graph = new()
        {
            { "A", ["B", "C", "D"] },
            { "B", ["E", "F"] },
            { "C", ["G"] },
            { "D", [] },
            { "E", [] },
            { "F", [] },
            { "G", [] },
        };
        Dijkstra<string> Dijkstra = new();

        // Act
        var actual = Dijkstra.GetShortestPath(graph, from, to);

        // Assert
        actual.Should().Equal(expected);
    }

    public static IEnumerable<object[]> GetShortestPath_WhenConnected_PerformsCorrectly_Data()
    {
        yield return new object[] { "A", "B", new List<string>() { "A", "B" } };
    }
}
