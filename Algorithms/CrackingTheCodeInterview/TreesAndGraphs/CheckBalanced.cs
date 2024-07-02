// Source: "Cracking the coding interview" book (4.4 - Check balanced)

using System;

namespace CrackingTheCodeInterview.TreesAndGraphs.CheckBalanced;

public class CheckBalanced
{
    public static bool IsBalanced(BinaryTreeNode root)
    {
        return GetHeight(root) != -1;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="node"></param>
    /// <returns>-1 if unbalanced, node height otherwise</returns>
    private static int GetHeight(BinaryTreeNode node)
    {
        int leftHeight = node.LeftChild is not null ? GetHeight(node.LeftChild) : 0;
        int rightHeight = node.RightChild is not null ? GetHeight(node.RightChild) : 0;

        // Unbalanced left or right subtree => unbalanced node
        if (leftHeight == -1 || rightHeight == -1)
        {
            return -1;
        }
        // No left subtree => use only right subtree for computation
        else if (leftHeight == 0)
        {
            return 1 + rightHeight;
        }
        // No right subtree => use only left subtree for computation
        else if (rightHeight == 0)
        {
            return 1 + leftHeight;
        }
        // Large difference between left and right subtree heights => unbalanced node
        else if (Math.Abs(leftHeight - rightHeight) >= 2)
        {
            return -1;
        }

        // Balanced node => return computed height
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

// Basic binary tree implementation for the purpose of the problem
public class BinaryTreeNode
{
    public int Value { get; private set; }

    public BinaryTreeNode? LeftChild { get; set; }

    public BinaryTreeNode? RightChild { get; set; }

    public bool IsVisited { get; set; }

    public BinaryTreeNode(int value)
    {
        Value = value;
    }
}
