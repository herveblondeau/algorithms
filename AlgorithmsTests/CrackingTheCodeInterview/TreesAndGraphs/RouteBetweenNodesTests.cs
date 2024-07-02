using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.TreesAndGraphs.RouteBetweenNodes;

[TestClass]
public class RouteBetweenNodesTests
{

    [TestMethod]
    public void AreConnected_SameNode_ReturnsTrue()
    {
        // Arrange
        Node start = new(18);

        // Act
        bool actual = RouteBetweenNodes.AreConnected(start, start);

        // Assert
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void AreConnected_DirectNeighbors_ReturnsTrue()
    {
        // Arrange
        Node start = new(18);
        Node end = new(19);
        start.ConnectTo(end);

        // Act
        bool actual = RouteBetweenNodes.AreConnected(start, end);

        // Assert
        Assert.IsTrue(actual);
    }

    [TestMethod]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(5)]
    [DataRow(10)]
    [DataRow(30)]
    // Nodes connected in a straight line, no other nodes in the graph
    public void AreConnected_NLevelsApart_ReturnsTrue(int n)
    {
        // Arrange
        Node start = new(1);
        Node previous = start;
        for (int i = 0; i < n; i++)
        {
            Node current = new(i);
            previous.ConnectTo(current);
            previous = current;
        }
        Node end = new(n);
        previous.ConnectTo(end);

        // Act
        bool actual = RouteBetweenNodes.AreConnected(start, end);

        // Assert
        Assert.IsTrue(actual);
    }

    [TestMethod]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(5)]
    [DataRow(10)]
    [DataRow(30)]
    public void AreConnected_NLevelsApartWithOtherNodes_ReturnsTrue(int n)
    {
        // Arrange
        int tempNodeIndex = n + 100;
        Node start = new(1);
        Node previous = start;
        for (int i = 0; i < n; i++)
        {
            Node current = new(i);
            previous.ConnectTo(current);

            // Add 10 dead end nodes
            for (int j = 0; j < 10; j++)
            {
                previous.ConnectTo(new Node(tempNodeIndex++));
            }

            previous = current;
        }
        Node end = new(n);
        previous.ConnectTo(end);

        // Act
        bool actual = RouteBetweenNodes.AreConnected(start, end);

        // Assert
        Assert.IsTrue(actual);
    }

    [TestMethod]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(5)]
    [DataRow(10)]
    [DataRow(30)]
    public void AreConnected_Unconnected_ReturnsFalse(int n)
    {
        // Arrange
        Node start = new(1);
        Node previous = start;
        for (int i = 0; i < n; i++)
        {
            Node current = new(i);
            previous.ConnectTo(current);
            previous = current;
        }
        Node end = new(n);

        // Act
        bool actual = RouteBetweenNodes.AreConnected(start, end);

        // Assert
        Assert.IsFalse(actual);
    }

}
