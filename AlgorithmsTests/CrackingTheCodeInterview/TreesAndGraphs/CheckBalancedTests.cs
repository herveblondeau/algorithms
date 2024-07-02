using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.TreesAndGraphs.CheckBalanced;

[TestClass]
public class CheckBalancedTests
{

    #region Basic examples

    [TestMethod]
    public void IsBalanced_OneNode_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    public void IsBalanced_OneNodeWithLeftChild_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0
        BinaryTreeNode child = new(1);  // depth 1
        root.LeftChild = child;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    public void IsBalanced_OneNodeWithRightChild_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0
        BinaryTreeNode child = new(1);  // depth 1
        root.RightChild = child;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    public void IsBalanced_OneNodeWithTwoChildren_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0
        BinaryTreeNode leftChild = new(1);  // depth 1
        BinaryTreeNode rightChild = new(2);  // depth 1
        root.LeftChild = leftChild;
        root.RightChild = rightChild;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

    #endregion

    #region Simple structures, different levels

    [TestMethod]
    public void IsBalanced_OneNodeWithOneChildAndOneGrandChild_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0
        BinaryTreeNode child = new(1);  // depth 1
        BinaryTreeNode grandChild = new(2);  // depth 2
        root.LeftChild = child;
        child.LeftChild = grandChild;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    public void IsBalanced_OneNodeWithLeftSubHeightOneAndRightSubHeightTwo_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode leftChild = new(1);  // Left subtree
        root.LeftChild = leftChild;

        BinaryTreeNode rightChild = new(2);  // Right subtree
        root.RightChild = rightChild;
        BinaryTreeNode rightGrandChild = new(3);  // Right subtree
        rightChild.RightChild = rightGrandChild;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    public void IsBalanced_OneNodeWithLeftSubHeightOneAndRightSubHeightThree_ReturnsFalse()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode leftChild = new(1);  // Left subtree
        root.LeftChild = leftChild;

        BinaryTreeNode rightChild = new(2);  // Right subtree
        root.RightChild = rightChild;
        BinaryTreeNode rightGrandChild = new(3);  // Right subtree
        rightChild.RightChild = rightGrandChild;
        BinaryTreeNode rightGrandGrandChild = new(4);  // Right subtree
        rightGrandChild.RightChild = rightGrandGrandChild;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeFalse();
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
    public void IsBalanced_PerfectBinaryTree_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

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
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

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
     *  / \     / \     / \     /
     * 7   8   9   10  11  12  13
     */
    [TestMethod]
    public void IsBalanced_CompleteBinaryTree_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

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
        node3.LeftChild = node7;
        node3.RightChild = node8;
        node4.LeftChild = node9;
        node4.RightChild = node10;
        node5.LeftChild = node11;
        node5.RightChild = node12;
        node6.LeftChild = node13;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

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
     *                  / \
     *                 11  12
     */

    [TestMethod]
    public void IsBalanced_FullOneHeightDifferenceBinaryTree_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

        BinaryTreeNode node3 = new(3); // depth 2
        BinaryTreeNode node4 = new(4); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        node1.LeftChild = node3;
        node1.RightChild = node4;
        node2.LeftChild = node5;
        node2.RightChild = node6;

        BinaryTreeNode node11 = new(11); // depth 3
        BinaryTreeNode node12 = new(12); // depth 3
        node5.LeftChild = node11;
        node5.RightChild = node12;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

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
     *                      / \
     *                     /   \
     *                    /     \
     *                   5       6
     *                  / \
     *                 11  12
     */
    [TestMethod]
    public void IsBalanced_FullTwoHeightDifferenceBinaryTree_ReturnsFalse()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        node2.LeftChild = node5;
        node2.RightChild = node6;

        BinaryTreeNode node11 = new(11); // depth 3
        BinaryTreeNode node12 = new(12); // depth 3
        node5.LeftChild = node11;
        node5.RightChild = node12;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeFalse();
    }

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
     *        \             / \
     *         \           /   \
     *          \         /     \
     *           4       5       6
     *          /       /       / \
     *         9       11      13  14
     */
    [TestMethod]
    public void IsBalanced_RandomSameHeightBinaryTree_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

        BinaryTreeNode node4 = new(4); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        node1.RightChild = node4;
        node2.LeftChild = node5;
        node2.RightChild = node6;

        BinaryTreeNode node9 = new(9); // depth 3
        BinaryTreeNode node11 = new(11); // depth 3
        BinaryTreeNode node13 = new(13); // depth 3
        BinaryTreeNode node14 = new(14); // depth 3
        node4.LeftChild = node9;
        node5.LeftChild = node11;
        node6.LeftChild = node13;
        node6.RightChild = node14;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

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
     *        \             / \
     *         \           /   \
     *          \         /     \
     *           4       5       6
     *          /               / \
     *         9               13  14
     */
    [TestMethod]
    public void IsBalanced_RandomOneHeightDifferenceBinaryTree_ReturnsTrue()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

        BinaryTreeNode node4 = new(4); // depth 2
        BinaryTreeNode node5 = new(5); // depth 2
        BinaryTreeNode node6 = new(6); // depth 2
        node1.RightChild = node4;
        node2.LeftChild = node5;
        node2.RightChild = node6;

        BinaryTreeNode node9 = new(9); // depth 3
        BinaryTreeNode node13 = new(13); // depth 3
        BinaryTreeNode node14 = new(14); // depth 3
        node4.LeftChild = node9;
        node6.LeftChild = node13;
        node6.RightChild = node14;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeTrue();
    }

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
     *                        \
     *                         \
     *                          \
     *                           6
     *                          / \
     *                         13  14
     */
    [TestMethod]
    public void IsBalanced_RandomTwoHeightDifferenceBinaryTree_ReturnsFalse()
    {
        // Arrange
        BinaryTreeNode root = new(0);  // depth 0

        BinaryTreeNode node1 = new(1); // depth 1
        BinaryTreeNode node2 = new(2); // depth 1
        root.LeftChild = node1;
        root.RightChild = node2;

        BinaryTreeNode node6 = new(6); // depth 2
        node2.RightChild = node6;

        BinaryTreeNode node9 = new(9); // depth 3
        BinaryTreeNode node13 = new(13); // depth 3
        BinaryTreeNode node14 = new(14); // depth 3
        node6.LeftChild = node13;
        node6.RightChild = node14;

        // Act
        bool actual = CheckBalanced.IsBalanced(root);

        // Assert
        actual.Should().BeFalse();
    }

    #endregion

}
