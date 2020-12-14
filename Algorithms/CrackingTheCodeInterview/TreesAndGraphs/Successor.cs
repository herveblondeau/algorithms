using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Serialization;

namespace CrackingTheCodeInterview.TreesAndGraphs.Successor
{
    // Source: "Cracking the coding interview" book (4.6 - Successor)
    public class Successor
    {
        public static BinaryTreeNode Next(BinaryTreeNode node)
        {
            // We don't check the left child since it can never be a successor in an in order traversal

            // If there is right child, the next node is the leftmost descendant in the right descendant hierarchy
            if (node.RightChild != null)
            {
                return LeftMostDescendant(node.RightChild);
            }

            // Otherwise, we need to go up the ascendant hierarchy until we go to the right
            return FirstRightAscendant(node);

        }

        private static BinaryTreeNode LeftMostDescendant(BinaryTreeNode node)
        {
            if (node.LeftChild != null)
            {
                return LeftMostDescendant(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                return LeftMostDescendant(node.RightChild);
            }

            return node;
        }

        private static BinaryTreeNode FirstRightAscendant(BinaryTreeNode node)
        {
            if (node == null || node.Parent == null)
            {
                return null;
            }
            if (node.Parent.LeftChild == node)
            {
                return node.Parent;
            }

            return FirstRightAscendant(node.Parent);
        }

    }

    // Basic binary tree implementation for the purpose of the problem
    public class BinaryTreeNode
    {
        public int Value { get; private set; }

        public BinaryTreeNode Parent { get; set; }

        public BinaryTreeNode LeftChild { get; set; }

        public BinaryTreeNode RightChild { get; set; }

        public bool IsVisited { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }
}
