﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingTheCodeInterview.TreesAndGraphs.ListOfDepths
{
    // Source: "Cracking the coding interview" book (4.3 - List of depths)
    public class ListOfDepths
    {
        private static List<LinkedListNode> _firsts; // keeps track of the first element of each linked list - this is what the conversion will return
        private static List<LinkedListNode> _lasts; // keeps track of the last element of each linked list - this is where we append new elements

        public static LinkedListNode[] GetDepthLists(BinaryTreeNode root)
        {
            _firsts = new List<LinkedListNode>();
            _lasts = new List<LinkedListNode>();

            ProcessNode(root, 0);

            return _firsts.ToArray();
        }

        private static void ProcessNode(BinaryTreeNode node, int depth)
        {
            // We use pre order traversal. In theory, any type of traversal would do but, with our implementation,
            // processing the node before its children is necessary to ensure that the working lists always contain enough depths
            // (with in order or post order, we would try to add an element at index n before even having an element at index zero)

            // Create new list for current depth...
            if (_firsts.Count == depth)
            {
                LinkedListNode next = new LinkedListNode(node.Value);
                _firsts.Add(next);
                _lasts.Add(next);
            }
            // ... or append to the existing one
            else
            {
                _lasts[depth].Next = new LinkedListNode(node.Value);
                _lasts[depth] = _lasts[depth].Next;
            }

            // Process children
            if (node.LeftChild != null)
            {
                ProcessNode(node.LeftChild, depth + 1);
            }
            if (node.RightChild != null)
            {
                ProcessNode(node.RightChild, depth + 1);
            }
        }
    }

    // Basic binary tree implementation for the purpose of the problem
    public class BinaryTreeNode
    {
        public int Value { get; private set; }

        public BinaryTreeNode LeftChild { get; set; }

        public BinaryTreeNode RightChild { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }

    // Basic singly linked list implementation for the purpose of the problem
    public class LinkedListNode
    {
        public int Value { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return Value == ((LinkedListNode)obj).Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
