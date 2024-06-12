using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.BreadthFirstSearch
{
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
        [DataRow("H", "I", true)]
        [DataRow("I", "H", true)]
        [DataRow("B", "A", false)]
        [DataRow("C", "A", false)]
        [DataRow("D", "A", false)]
        [DataRow("E", "A", false)]
        [DataRow("F", "A", false)]
        [DataRow("G", "A", false)]
        [DataRow("H", "A", false)]
        [DataRow("I", "A", false)]
        [DataRow("C", "B", false)]
        [DataRow("D", "B", false)]
        [DataRow("E", "B", false)]
        [DataRow("F", "B", false)]
        [DataRow("G", "B", false)]
        [DataRow("H", "B", false)]
        [DataRow("I", "B", false)]
        [DataRow("B", "C", false)]
        [DataRow("D", "C", false)]
        [DataRow("E", "C", false)]
        [DataRow("F", "C", false)]
        [DataRow("G", "C", false)]
        [DataRow("H", "C", false)]
        [DataRow("I", "C", false)]
        [DataRow("B", "D", false)]
        [DataRow("C", "D", false)]
        [DataRow("E", "D", false)]
        [DataRow("F", "D", false)]
        [DataRow("G", "D", false)]
        [DataRow("H", "D", false)]
        [DataRow("I", "D", false)]
        [DataRow("D", "E", false)]
        [DataRow("F", "E", false)]
        [DataRow("G", "E", false)]
        [DataRow("H", "E", false)]
        [DataRow("I", "E", false)]
        [DataRow("D", "F", false)]
        [DataRow("G", "F", false)]
        [DataRow("H", "F", false)]
        [DataRow("I", "F", false)]
        [DataRow("B", "G", false)]
        [DataRow("D", "G", false)]
        [DataRow("E", "G", false)]
        [DataRow("F", "G", false)]
        [DataRow("H", "G", false)]
        [DataRow("I", "G", false)]
        [DataRow("A", "H", false)]
        [DataRow("B", "H", false)]
        [DataRow("C", "H", false)]
        [DataRow("D", "H", false)]
        [DataRow("E", "H", false)]
        [DataRow("F", "H", false)]
        [DataRow("G", "H", false)]
        [DataRow("A", "I", false)]
        [DataRow("B", "I", false)]
        [DataRow("C", "I", false)]
        [DataRow("D", "I", false)]
        [DataRow("E", "I", false)]
        [DataRow("F", "I", false)]
        [DataRow("G", "I", false)]
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
                { "H", ["I"] },
                { "I", ["H"] },
            };
            BreadthFirstSearch<string> breadthFirstSearch = new(graph);

            // Act
            var actual = breadthFirstSearch.HasPath(from, to);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
