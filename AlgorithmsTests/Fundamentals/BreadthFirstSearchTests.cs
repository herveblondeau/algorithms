using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.BreadthFirstSearch;

[TestClass]
public class BreadthFirstSearchTests
{
    [TestMethod]
    [DataRow("A", "B", true)]
    [DataRow("A", "C", true)]
    [DataRow("A", "D", true)]
    [DataRow("A", "E", true)]
    [DataRow("A", "F", true)]
    [DataRow("A", "G", true)]
    [DataRow("B", "E", true)]
    [DataRow("B", "F", true)]
    [DataRow("C", "G", true)]
    [DataRow("B", "A", false)]
    [DataRow("C", "A", false)]
    [DataRow("D", "A", false)]
    [DataRow("E", "A", false)]
    [DataRow("F", "A", false)]
    [DataRow("G", "A", false)]
    [DataRow("C", "B", false)]
    [DataRow("D", "B", false)]
    [DataRow("E", "B", false)]
    [DataRow("F", "B", false)]
    [DataRow("G", "B", false)]
    [DataRow("B", "C", false)]
    [DataRow("D", "C", false)]
    [DataRow("E", "C", false)]
    [DataRow("F", "C", false)]
    [DataRow("G", "C", false)]
    [DataRow("B", "D", false)]
    [DataRow("C", "D", false)]
    [DataRow("E", "D", false)]
    [DataRow("F", "D", false)]
    [DataRow("G", "D", false)]
    [DataRow("D", "E", false)]
    [DataRow("F", "E", false)]
    [DataRow("G", "E", false)]
    [DataRow("D", "F", false)]
    [DataRow("G", "F", false)]
    [DataRow("B", "G", false)]
    [DataRow("D", "G", false)]
    [DataRow("E", "G", false)]
    [DataRow("F", "G", false)]
    public void HasPath_WhenCalled_PerformsCorrectly(string from, string to, bool expected)
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
        BreadthFirstSearch<string> breadthFirstSearch = new();

        // Act
        var actual = breadthFirstSearch.HasPath(graph, from, to);

        // Assert
        actual.Should().Be(expected);
    }
}
