namespace CrackingTheCodeInterview.LinkedLists.KthToLast;

// Source: "Cracking the coding interview" book (2.2 - Kth to last)
public class KthToLast
{
    // O(n) time, O(1) space
    public static LinkedListNode GetKthToLast(LinkedListNode start, int k)
    {
        if (k < 0)
        {
            return null;
        }

        // We use two pointers, where the second pointer will simply be trailing the first one by k nodes

        // Move the first pointer by k nodes
        LinkedListNode current = start;
        int counter = 1;
        while (counter < k && current != null)
        {
            current = current.Next;
            counter++;
        }

        // Return null if there are less than k nodes
        if (current == null)
        {
            return null;
        }

        // Move both pointers together. When the first one reaches the end, the second one will be k nodes behind
        LinkedListNode kthToLast = start;
        while (current.Next != null)
        {
            kthToLast = kthToLast.Next;
            current = current.Next;
        }

        return kthToLast;
    }
}

// Extremely basic singly linked list implementation for the purpose of the problem
public class LinkedListNode
{
    public string Value { get; set; }
    public LinkedListNode Next { get; set; }

    public LinkedListNode(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public override bool Equals(object obj)
    {
        return Value == ((LinkedListNode)obj).Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
