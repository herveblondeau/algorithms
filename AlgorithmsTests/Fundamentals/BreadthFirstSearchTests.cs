using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.BreadthFirstSearch
{
    [TestClass]
    public class BreadthFirstSearchTests
    {
        private static Node<string> NodeA = null!;
        private static Node<string> NodeB = null!;
        private static Node<string> NodeC = null!;
        private static Node<string> NodeD = null!;
        private static Node<string> NodeE = null!;
        private static Node<string> NodeF = null!;
        private static Node<string> NodeG = null!;
        private static Node<string> NodeH = null!;
        private static Node<string> NodeI = null!;

        [ClassInitialize]
        public static void GenerateNodes(TestContext context)
        {
            NodeA = new("A");
            NodeB = new("B");
            NodeC = new("C");
            NodeD = new("D");
            NodeE = new("E");
            NodeF = new("F");
            NodeG = new("G");
            NodeH = new("H");
            NodeI = new("I");
            NodeA.AddNeighbors([NodeB, NodeC, NodeD]);
            NodeB.AddNeighbor(NodeE);
            NodeC.AddNeighbors([NodeE, NodeG]);
            NodeE.AddNeighbor(NodeF);
            NodeH.AddNeighbor(NodeI);
            NodeI.AddNeighbor(NodeH);
        }

        [TestMethod]
        [DynamicData(nameof(HasPath_WhenConnected_ReturnsTrue_Data), DynamicDataSourceType.Method)]
        public void HasPath_WhenConnected_ReturnsTrue(Node<string> from, Node<string> to)
        {
            // Arrange
            BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch();

            // Act
            var actual = breadthFirstSearch.HasPath(from, to);

            // Assert
            Assert.IsTrue(actual);
        }

        public static IEnumerable<object[]> HasPath_WhenConnected_ReturnsTrue_Data()
        {
            yield return new object[] { NodeA, NodeB };
            yield return new object[] { NodeA, NodeC };
            yield return new object[] { NodeA, NodeD };
            yield return new object[] { NodeA, NodeE };
            yield return new object[] { NodeA, NodeF };
            yield return new object[] { NodeA, NodeG };

            yield return new object[] { NodeB, NodeE };
            yield return new object[] { NodeB, NodeF };
            yield return new object[] { NodeC, NodeG };

            yield return new object[] { NodeH, NodeI };

            yield return new object[] { NodeI, NodeH };
        }

        [TestMethod]
        [DynamicData(nameof(HasPath_WhenNotConnected_ReturnsFalse_Data), DynamicDataSourceType.Method)]
        public void HasPath_WhenNotConnected_ReturnsFalse(Node<string> from, Node<string> to)
        {
            // Arrange
            BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch();

            // Act
            var actual = breadthFirstSearch.HasPath(from, to);

            // Assert
            Assert.IsFalse(actual);
        }

        public static IEnumerable<object[]> HasPath_WhenNotConnected_ReturnsFalse_Data()
        {
            yield return new object[] { NodeB, NodeA };
            yield return new object[] { NodeC, NodeA };
            yield return new object[] { NodeD, NodeA };
            yield return new object[] { NodeE, NodeA };
            yield return new object[] { NodeF, NodeA };
            yield return new object[] { NodeG, NodeA };
            yield return new object[] { NodeH, NodeA };
            yield return new object[] { NodeI, NodeA };

            yield return new object[] { NodeC, NodeB };
            yield return new object[] { NodeD, NodeB };
            yield return new object[] { NodeE, NodeB };
            yield return new object[] { NodeF, NodeB };
            yield return new object[] { NodeG, NodeB };
            yield return new object[] { NodeH, NodeB };
            yield return new object[] { NodeI, NodeB };

            yield return new object[] { NodeB, NodeC };
            yield return new object[] { NodeD, NodeC };
            yield return new object[] { NodeE, NodeC };
            yield return new object[] { NodeF, NodeC };
            yield return new object[] { NodeG, NodeC };
            yield return new object[] { NodeH, NodeC };
            yield return new object[] { NodeI, NodeC };

            yield return new object[] { NodeB, NodeD };
            yield return new object[] { NodeC, NodeD };
            yield return new object[] { NodeE, NodeD };
            yield return new object[] { NodeF, NodeD };
            yield return new object[] { NodeG, NodeD };
            yield return new object[] { NodeH, NodeD };
            yield return new object[] { NodeI, NodeD };

            yield return new object[] { NodeD, NodeE };
            yield return new object[] { NodeF, NodeE };
            yield return new object[] { NodeG, NodeE };
            yield return new object[] { NodeH, NodeE };
            yield return new object[] { NodeI, NodeE };

            yield return new object[] { NodeD, NodeF };
            yield return new object[] { NodeG, NodeF };
            yield return new object[] { NodeH, NodeF };
            yield return new object[] { NodeI, NodeF };

            yield return new object[] { NodeB, NodeG };
            yield return new object[] { NodeD, NodeG };
            yield return new object[] { NodeE, NodeG };
            yield return new object[] { NodeF, NodeG };
            yield return new object[] { NodeH, NodeG };
            yield return new object[] { NodeI, NodeG };

            yield return new object[] { NodeA, NodeH };
            yield return new object[] { NodeB, NodeH };
            yield return new object[] { NodeC, NodeH };
            yield return new object[] { NodeD, NodeH };
            yield return new object[] { NodeE, NodeH };
            yield return new object[] { NodeF, NodeH };
            yield return new object[] { NodeG, NodeH };

            yield return new object[] { NodeA, NodeI };
            yield return new object[] { NodeB, NodeI };
            yield return new object[] { NodeC, NodeI };
            yield return new object[] { NodeD, NodeI };
            yield return new object[] { NodeE, NodeI };
            yield return new object[] { NodeF, NodeI };
            yield return new object[] { NodeG, NodeI };
        }
    }
}
