using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingTheCodeInterview.TreesAndGraphs.MinimalTree
{
    // Source: "Cracking the coding interview" book (4.2 - Minimal tree)
    public class MinimalTree
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="elements">A sorted array containing unique integers sorted in ascending order</param>
        /// <returns>the root node of the generated binary search tree</returns>
        public static Node GetMinimalBinarySearchTree(int[] elements)
        {
            // We do not check the input array as the problem states that its elements are unique and sorted in ascending order
            // Given that the array is sorted:
            // - the tree root is the middle element.
            // - its left child is the middle element of the left half
            // - its left child's left child if the middle element of the left half's left half
            // and so on...

            // Recursion is well suited to this problem

            // Exit cases
            Node root;
            if (elements.Length == 1)
            {
                root = new Node(elements[0]);
            }
            else if (elements.Length == 2)
            {
                root = new Node(elements[1]);
                root.LeftChild = new Node(elements[0]);
            }
            // Recursive case
            else
            {
                int middleIndex = elements.Length / 2;
                root = new Node(elements[middleIndex]);
                root.LeftChild = GetMinimalBinarySearchTree(elements.Take(middleIndex).ToArray()); // recursion on left half
                root.RightChild = GetMinimalBinarySearchTree(elements.Skip(middleIndex + 1).ToArray()); // recursion on right half
            }

            return root;
        }
    }

    // Basic tree implementation for the purpose of the problem
    public class Node
    {
        public int Value { get; private set; }

        public Node LeftChild { get; set; }

        public Node RightChild { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
