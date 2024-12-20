﻿using System;
using System.Collections.Generic;

namespace ByTheme.Trees;

public class BinarySearchTree<T> where T : IComparable
{
    public BinaryTreeNode<T>? Root { get; set; }

    public BinaryTreeNode<T>? Find(T value)
    {
        BinaryTreeNode<T>? currentNode = Root;
        while (currentNode is not null)
        {
            if (value.Equals(currentNode.Value)) return currentNode;

            if (value.CompareTo(currentNode.Value) < 0)
            {
                currentNode = currentNode.LeftChild;
            }
            else
            {
                currentNode = currentNode.RightChild;
            }
        }

        return null;
    }

    public void Insert(T value)
    {
        if (Root is null)
        {
            Root = new BinaryTreeNode<T>
            {
                LeftChild = null,
                RightChild = null,
                Value = value,
            };
            return;
        }

        BinaryTreeNode<T> currentNode = Root;
        while (true)
        {
            if (value.Equals(currentNode.Value)) return;

            if (value.CompareTo(currentNode.Value) < 0)
            {
                if (currentNode.LeftChild is null)
                {
                    currentNode.LeftChild = new BinaryTreeNode<T>
                    {
                        LeftChild = null,
                        RightChild = null,
                        Value = value,
                    };
                    return;
                }
                currentNode = currentNode.LeftChild;
            }
            else
            {
                if (currentNode.RightChild is null)
                {
                    currentNode.RightChild = new BinaryTreeNode<T>
                    {
                        LeftChild = null,
                        RightChild = null,
                        Value = value,
                    };
                    return;
                }
                currentNode = currentNode.RightChild;
            }
        }
    }

    public List<BinaryTreeNode<T>> TraversePreOrder(BinaryTreeNode<T>? node)
    {
        List<BinaryTreeNode<T>> result = new();
        if (node is not null)
        {
            result.Add(node);
            result.AddRange(TraversePreOrder(node.LeftChild));
            result.AddRange(TraversePreOrder(node.RightChild));
        }
        return result;
    }

    public List<BinaryTreeNode<T>> TraverseInOrder(BinaryTreeNode<T>? node)
    {
        List<BinaryTreeNode<T>> result = new();
        if (node is not null)
        {
            result.AddRange(TraverseInOrder(node.LeftChild));
            result.Add(node);
            result.AddRange(TraverseInOrder(node.RightChild));
        }
        return result;
    }

    public List<BinaryTreeNode<T>> TraversePostOrder(BinaryTreeNode<T>? node)
    {
        List<BinaryTreeNode<T>> result = new();
        if (node is not null)
        {
            result.AddRange(TraversePostOrder(node.LeftChild));
            result.AddRange(TraversePostOrder(node.RightChild));
            result.Add(node);
        }
        return result;
    }

    public List<BinaryTreeNode<T>?> TraverseBreadFirst(BinaryTreeNode<T>? node)
    {
        List<BinaryTreeNode<T>?> result = new();
        Queue<BinaryTreeNode<T>?> queue = new();
        while (node is not null)
        {
            result.Add(node);
            queue.Enqueue(node.LeftChild);
            queue.Enqueue(node.RightChild);
            node = queue.Dequeue();
        }
        return result;
    }
}

public class BinaryTreeNode<T>
{
    public T? Value { get; internal set; }
    public BinaryTreeNode<T>? LeftChild { get; internal set; }
    public BinaryTreeNode<T>? RightChild { get; internal set; }
}