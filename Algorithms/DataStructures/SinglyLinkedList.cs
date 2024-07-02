using System;
using System.Text;

namespace Algorithms.CrackingTheCodeInterview.LinkedLists;

// TODO
// - implement Delete()
// - test all methods
// - implement doubly linked list
// - move all classes to the data structures solution

public class SinglyLinkedList
{
    public SinglyLinkedListNode? First { get; private set; }
    public SinglyLinkedListNode? Last { get; private set; }

    public void InsertFirst(int value)
    {
        SinglyLinkedListNode node = new(value);
        if (_isEmpty)
        {
            First = node;
            Last = node;
        }
        else
        {
            node.Next = First;
            First = node;
        }
    }

    public void InsertLast(int value)
    {
        SinglyLinkedListNode node = new(value);
        if (_isEmpty)
        {
            First = node;
            Last = node;
        }
        else
        {
            Last!.Next = node;
            Last = node;
        }
    }

    public void InsertBefore(SinglyLinkedListNode node, int value)
    {
        if (_isEmpty)
        {
            return;
        }

        SinglyLinkedListNode newNode= new(value);
        SinglyLinkedListNode? current = First;
        while (current is not null && current.Next != node)
        {
            current = current.Next;
        }

        if (current is null)
        {
            throw new ArgumentOutOfRangeException("Node not found");
        }

        node.SetNext(newNode);
    }

    public void InsertAfter(SinglyLinkedListNode node, int value)
    {
        if (_isEmpty)
        {
            return;
        }

        node.SetNext(new SinglyLinkedListNode(value));
    }

    public void Delete(SinglyLinkedListNode node)
    {
        if (_isEmpty)
        {
            return;
        }

        // TODO: implement
    }

    public override string ToString()
    {
        StringBuilder result = new();
        SinglyLinkedListNode? currentNode = First;
        while (currentNode is not null)
        {
            result.Append(currentNode.Value);
            result.Append(" ");
            currentNode = currentNode.Next;
        }
        return result.ToString();
    }

    private bool _isEmpty => First is null;
}

public class SinglyLinkedListNode
{
    public int Value { get; private set; }
    public SinglyLinkedListNode? Next { get; internal set; }

    public SinglyLinkedListNode(int value)
    {
        Value = value;
    }

    public bool HasNext()
    {
        return Next is not null;
    }

    public void SetNext(SinglyLinkedListNode node)
    {

        if (Next is null)
        {
            Next = node;
        }
        else
        {
            node.Next = Next.Next;
            Next.Next = Next;
            Next = node;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        return Value == ((SinglyLinkedListNode)obj).Value;
    }

    public override int GetHashCode()
    {
        return Value;
    }
}
