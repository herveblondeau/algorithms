using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.TreesAndGraphs.ValidateBst;

[TestClass]
public class ValidateBstTests
{

    #region Simple examples

    [TestMethod]
    public void IsBst_OneNode_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);

        // Act
        bool actual = ValidateBst.IsBst(root);

        // Assert
        Assert.IsTrue(actual);
    }

    [TestMethod]
    [DataRow(1, 2, false)]
    [DataRow(2, 1, true)]
    public void IsBst_OneNodeWithLeftChild_ChecksValues(int parentValue, int childValue, bool expected)
    {
        // Arrange
        BinaryTreeNode root = new(parentValue);
        BinaryTreeNode child = new(childValue);
        root.LeftChild = child;

        // Act
        bool actual = ValidateBst.IsBst(root);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(1, 2, true)]
    [DataRow(2, 1, false)]
    public void IsBst_OneNodeWithRightChild_ChecksValues(int parentValue, int childValue, bool expected)
    {
        // Arrange
        BinaryTreeNode root = new(parentValue);
        BinaryTreeNode child = new(childValue);
        root.RightChild = child;

        // Act
        bool actual = ValidateBst.IsBst(root);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(1, 2, 3, false)]
    [DataRow(1, 3, 2, false)]
    [DataRow(2, 1, 3, true)]
    [DataRow(2, 3, 1, false)]
    [DataRow(3, 1, 2, false)]
    [DataRow(3, 2, 1, false)]
    public void IsBst_OneNodeWithTwoChildren_ChecksValues(int parentValue, int leftChildValue, int rightChildValue, bool expected)
    {
        // Arrange
        BinaryTreeNode root = new(parentValue);
        BinaryTreeNode leftChild = new(leftChildValue);
        BinaryTreeNode rightChild = new(rightChildValue);
        root.LeftChild = leftChild;
        root.RightChild = rightChild;

        // Act
        bool actual = ValidateBst.IsBst(root);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Medium trees

    /*
     *       2
     *      / \
     *     /   \
     *    /     \
     *   1       4
     *    \
     *     3
     */
    [TestMethod]
    public void IsBst_MediumTree1_ReturnsFalse()
    {
        // Arrange
        BinaryTreeNode node2 = new(2);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node4 = new(4); // depth 1
        node2.LeftChild = node1;
        node2.RightChild = node4;

        BinaryTreeNode node3 = new(3); // depth 2
        node1.RightChild = node3;

        // Act
        bool actual = ValidateBst.IsBst(node2);

        // Assert
        Assert.IsFalse(actual);
    }

    /*
     *       0
     *      / \
     *     /   \
     *    /     \
     *   1       2
     *  / \     / \
     * 3   4   5   6
     */
    [TestMethod]
    public void IsBst_MediumTree2_ReturnsFalse()
    {
        // Arrange
        BinaryTreeNode node0 = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        node0.LeftChild = node1;
        node0.RightChild = node2;

        BinaryTreeNode node3 = new(3); // depth 2
        BinaryTreeNode node4 = new(4); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        node1.LeftChild = node3;
        node1.RightChild = node4;
        node2.LeftChild = node5;
        node2.RightChild = node6;

        // Act
        bool actual = ValidateBst.IsBst(node0);

        // Assert
        Assert.IsFalse(actual);
    }

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
    public void IsBst_MediumTree3_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode node4 = new(4);  // depth 0

        BinaryTreeNode node2 = new(2); // depth 1
        BinaryTreeNode node6 = new(6); // depth 1
        node4.LeftChild = node2;
        node4.RightChild = node6;

        BinaryTreeNode node1 = new(1); // depth 2
        BinaryTreeNode node3 = new(3); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node7 = new(7); // depth 2
        node2.LeftChild = node1;
        node2.RightChild = node3;
        node6.LeftChild = node5;
        node6.RightChild = node7;

        // Act
        bool actual = ValidateBst.IsBst(node4);

        // Assert
        Assert.IsTrue(actual);
    }

    #endregion

    #region Complex trees

    /*
     *               0
     *              / \
     *             /   \
     *            /     \
     *           /       \
     *          /         \
     *         /           \
     *        /             \
     *       1               2
     *      / \             / \
     *     /   \           /   \
     *    /     \         /     \
     *   3       4       5       6
     *  / \     / \     / \     / \
     * 7   8   9   10  11  12  13  14
     */
    [TestMethod]
    public void IsBst_ComplexTree1_ReturnsFalse()
    {
        // Arrange
        BinaryTreeNode node0 = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        node0.LeftChild = node1;
        node0.RightChild = node2;

        BinaryTreeNode node3 = new(3); // depth 2
        BinaryTreeNode node4 = new(4); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        node1.LeftChild = node3;
        node1.RightChild = node4;
        node2.LeftChild = node5;
        node2.RightChild = node6;

        BinaryTreeNode node7 = new(7); // depth 3
        BinaryTreeNode node8 = new(8); // depth 3
        BinaryTreeNode node9 = new(9); // depth 3
        BinaryTreeNode node10 = new(10); // depth 3
        BinaryTreeNode node11 = new(11); // depth 3
        BinaryTreeNode node12 = new(12); // depth 3
        BinaryTreeNode node13 = new(13); // depth 3
        BinaryTreeNode node14 = new(14); // depth 3
        node3.LeftChild = node7;
        node3.RightChild = node8;
        node4.LeftChild = node9;
        node4.RightChild = node10;
        node5.LeftChild = node11;
        node5.RightChild = node12;
        node6.LeftChild = node13;
        node6.RightChild = node14;

        // Act
        bool actual = ValidateBst.IsBst(node0);

        // Assert
        Assert.IsFalse(actual);
    }

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
    public void IsBst_ComplexTree2_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode node8 = new(8);  // depth 0

        BinaryTreeNode node4 = new(4); // depth 1
        BinaryTreeNode node12 = new(12); // depth 1
        node8.LeftChild = node4;
        node8.RightChild = node12;

        BinaryTreeNode node2 = new(2); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        BinaryTreeNode node10 = new(10); // depth 2
        BinaryTreeNode node14 = new(14); // depth 2
        node4.LeftChild = node2;
        node4.RightChild = node6;
        node12.LeftChild = node10;
        node12.RightChild = node14;

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
        node6.LeftChild = node5;
        node6.RightChild = node7;
        node10.LeftChild = node9;
        node10.RightChild = node11;
        node14.LeftChild = node13;
        node14.RightChild = node15;

        // Act
        bool actual = ValidateBst.IsBst(node8);

        // Assert
        Assert.IsTrue(actual);
    }

    #endregion
}
