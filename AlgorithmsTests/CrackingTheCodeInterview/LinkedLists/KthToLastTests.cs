using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.LinkedLists.KthToLast
{
    [TestClass]
    public class KthToLastTests
    {
        [TestMethod]
        [DataRow(1, "node 10")]
        [DataRow(2, "node 9")]
        [DataRow(3, "node 8")]
        [DataRow(4, "node 7")]
        [DataRow(5, "node 6")]
        [DataRow(6, "node 5")]
        [DataRow(7, "node 4")]
        [DataRow(8, "node 3")]
        [DataRow(9, "node 2")]
        [DataRow(10, "node 1")]
        public void GetKthToLast_LessThan10thToLastIn10_ReturnsKthToLast(int k, string expected)
        {
            // Arrange
            // List with 10 nodes from 1 to 10
            LinkedListNode start = new("node 1");
            LinkedListNode current = start;
            LinkedListNode next;
            for (int i = 2; i <= 10; i++)
            {
                next = new LinkedListNode($"node {i}");
                current.Next = next;
                current = next;
            }

            // Act
            LinkedListNode result = KthToLast.GetKthToLast(start, k);

            // Assert
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-5)]
        [DataRow(-10)]
        [DataRow(-100)]
        [DataRow(-965)]
        public void GetKthToLast_NegativeK_ReturnsNull(int k)
        {
            // Arrange
            // List with 10 nodes from 1 to 10
            LinkedListNode start = new("node 1");
            LinkedListNode current = start;
            LinkedListNode next;
            for (int i = 2; i <= 10; i++)
            {
                next = new LinkedListNode($"node {i}");
                current.Next = next;
                current = next;
            }

            // Act
            LinkedListNode result = KthToLast.GetKthToLast(start, k);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow(11)]
        [DataRow(12)]
        [DataRow(13)]
        [DataRow(14)]
        [DataRow(50)]
        [DataRow(100)]
        public void GetKthToLast_MoreThan10thToLastIn10_ReturnsNull(int k)
        {
            // Arrange
            // List with 10 nodes from 1 to 10
            LinkedListNode start = new("node 1");
            LinkedListNode current = start;
            LinkedListNode next;
            for (int i = 2; i <= 10; i++)
            {
                next = new LinkedListNode($"node {i}");
                current.Next = next;
                current = next;
            }

            // Act
            LinkedListNode result = KthToLast.GetKthToLast(start, k);

            // Assert
            Assert.IsNull(result);
        }
    }
}
