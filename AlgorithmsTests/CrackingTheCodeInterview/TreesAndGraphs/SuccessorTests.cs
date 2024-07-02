using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.TreesAndGraphs.Successor;

[TestClass]
public class SuccessorTests
{

    #region Simple examples

    [TestMethod]
    public void Next_OneNode_ReturnsNull()
    {
        // Arrange
        BinaryTreeNode root = new(0);

        // Act
        BinaryTreeNode? actual = Successor.Next(root);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    public void Next_OneNodeWithLeftChild_PerformsCorrectly()
    {
        // Arrange
        BinaryTreeNode root = new(2);
        BinaryTreeNode child = new(1);
        root.LeftChild = child;
        child.Parent = root;

        // Act-Assert
        Assert.IsNull(Successor.Next(root));
        Assert.AreEqual(root, Successor.Next(child));
    }

    [TestMethod]
    public void Next_OneNodeWithRightChild_PerformsCorrectly()
    {
        // Arrange
        BinaryTreeNode root = new(1);
        BinaryTreeNode child = new(2);
        root.RightChild = child;
        child.Parent = root;

        // Act-Assert
        Assert.AreEqual(child, Successor.Next(root));
        Assert.IsNull(Successor.Next(child));
    }

    [TestMethod]
    public void Next_OneNodeWithTwoChildren_PerformsCorrectly()
    {
        // Arrange
        BinaryTreeNode root = new(2);
        BinaryTreeNode leftChild = new(1);
        BinaryTreeNode rightChild = new(3);
        root.LeftChild = leftChild;
        root.RightChild = rightChild;
        leftChild.Parent = root;
        rightChild.Parent = root;

        // Act-Assert
        Assert.AreEqual(root, Successor.Next(leftChild));
        Assert.AreEqual(rightChild, Successor.Next(root));
        Assert.IsNull(Successor.Next(rightChild));
    }

    #endregion

    #region Medium trees

    /*
     *       4
     *      / \
     *     /   \
     *    /     \
     *   2       6
     *  / \     / \
     * 1   3   5   7
     */
    [TestMethod]
    public void Next_MediumTree_PerformsCorrectly()
    {
        // Arrange
        BinaryTreeNode node4 = new(4);  // depth 0

        BinaryTreeNode node2 = new(2); // depth 1
        BinaryTreeNode node6 = new(6); // depth 1
        node4.LeftChild = node2;
        node4.RightChild = node6;
        node2.Parent = node4;
        node6.Parent = node4;

        BinaryTreeNode node1 = new(1); // depth 2
        BinaryTreeNode node3 = new(3); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node7 = new(7); // depth 2
        node2.LeftChild = node1;
        node2.RightChild = node3;
        node1.Parent = node2;
        node3.Parent = node2;
        node6.LeftChild = node5;
        node6.RightChild = node7;
        node5.Parent = node6;
        node7.Parent = node6;

        // Act-Assert
        Assert.AreEqual(node2, Successor.Next(node1));
        Assert.AreEqual(node3, Successor.Next(node2));
        Assert.AreEqual(node4, Successor.Next(node3));
        Assert.AreEqual(node5, Successor.Next(node4));
        Assert.AreEqual(node6, Successor.Next(node5));
        Assert.AreEqual(node7, Successor.Next(node6));
        Assert.IsNull(Successor.Next(node7));
    }

    #endregion

    #region Complex trees

    /*
     *               8
     *              / \
     *             /   \
     *            /     \
     *           /       \
     *          /         \
     *         /           \
     *        /             \
     *       4               12
     *      / \             / \
     *     /   \           /   \
     *    /     \         /     \
     *   2       6       10      14
     *  / \     / \     / \     / \
     * 1   3   5   7   9   11  13  15
     */
    [TestMethod]
    public void Next_ComplexTree_PerformsCorrectly()
    {
        // Arrange
        BinaryTreeNode node8 = new(8);  // depth 0

        BinaryTreeNode node4 = new(4); // depth 1
        BinaryTreeNode node12 = new(12); // depth 1
        node8.LeftChild = node4;
        node8.RightChild = node12;
        node4.Parent = node8;
        node12.Parent = node8;

        BinaryTreeNode node2 = new(2); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        BinaryTreeNode node10 = new(10); // depth 2
        BinaryTreeNode node14 = new(14); // depth 2
        node4.LeftChild = node2;
        node4.RightChild = node6;
        node2.Parent = node4;
        node6.Parent = node4;
        node12.LeftChild = node10;
        node12.RightChild = node14;
        node10.Parent = node12;
        node14.Parent = node12;

        BinaryTreeNode node1 = new(1); // depth 3
        BinaryTreeNode node3 = new(3); // depth 3
        BinaryTreeNode node5 = new(5); // depth 3
        BinaryTreeNode node7 = new(7); // depth 3
        BinaryTreeNode node9 = new(9); // depth 3
        BinaryTreeNode node11 = new(11); // depth 3
        BinaryTreeNode node13 = new(13); // depth 3
        BinaryTreeNode node15 = new(15); // depth 3
        node2.LeftChild = node1;
        node2.RightChild = node3;
        node1.Parent = node2;
        node3.Parent = node2;
        node6.LeftChild = node5;
        node6.RightChild = node7;
        node5.Parent = node6;
        node7.Parent = node6;
        node10.LeftChild = node9;
        node10.RightChild = node11;
        node9.Parent = node10;
        node11.Parent = node10;
        node14.LeftChild = node13;
        node14.RightChild = node15;
        node13.Parent = node14;
        node15.Parent = node14;

        // Act-Assert
        Assert.AreEqual(node2, Successor.Next(node1));
        Assert.AreEqual(node3, Successor.Next(node2));
        Assert.AreEqual(node4, Successor.Next(node3));
        Assert.AreEqual(node5, Successor.Next(node4));
        Assert.AreEqual(node6, Successor.Next(node5));
        Assert.AreEqual(node7, Successor.Next(node6));
        Assert.AreEqual(node8, Successor.Next(node7));
        Assert.AreEqual(node9, Successor.Next(node8));
        Assert.AreEqual(node10, Successor.Next(node9));
        Assert.AreEqual(node11, Successor.Next(node10));
        Assert.AreEqual(node12, Successor.Next(node11));
        Assert.AreEqual(node13, Successor.Next(node12));
        Assert.AreEqual(node14, Successor.Next(node13));
        Assert.AreEqual(node15, Successor.Next(node14));
        Assert.IsNull(Successor.Next(node15));
    }

    #endregion
}
