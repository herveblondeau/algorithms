// Source: "Cracking the coding interview" book (2.3 - Delete middle node)

namespace Algorithms.CrackingTheCodeInterview.LinkedLists.DeleteMiddleNode;

public class DeleteMiddleNode
{
    public static void Delete(LinkedListNode node)
    {
        // Since we deal with a singly linked list, we cannot just go backwards and connect node n-1 to node n+1
        // The only option we have is to replace node n's data with node n+1's, and then connect node n to node n+2
        // Note: this will throw an exception if we are trying to delete the last node, but it cannot be addressed with the given constraints
        node.Value = node.Next.Value;
        node.Next = node.Next.Next;
    }
}

// Extremely basic singly linked list implementation for the purpose of the problem
public class LinkedListNode
{
    public string Value { get; set; }
    public LinkedListNode? Next { get; set; }

    public LinkedListNode(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        return Value == ((LinkedListNode)obj).Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
