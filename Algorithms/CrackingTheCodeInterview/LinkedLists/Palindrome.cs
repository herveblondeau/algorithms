// Source: "Cracking the coding interview" book (2.6 - Palindrome)

namespace CrackingTheCodeInterview.LinkedLists.Palindrome;

public class Palindrome
{
    public bool IsPalindrome(LinkedListNode start)
    {
        // This can be debated but we consider an empty list to not be a palindrome
        if (start is null)
        {
            return false;
        }

        // Build the reverse of the list
        LinkedListNode? reverseCurrent = GetReversedCopy(start);

        // Compare both lists
        LinkedListNode? initialCurrent = start;
        while (initialCurrent is not null)
        {
            if (initialCurrent.Value != reverseCurrent?.Value)
            {
                return false;
            }

            initialCurrent = initialCurrent.Next;
            reverseCurrent = reverseCurrent.Next;
        }

        return true;
    }

    // Duplicate and reverse a linked list
    private LinkedListNode GetReversedCopy(LinkedListNode start)
    {
        LinkedListNode initialCurrent = start;
        LinkedListNode reverseCurrent = new(start.Value);
        while (initialCurrent.Next is not null)
        {
            LinkedListNode reversePrevious = new(initialCurrent.Next.Value)
            {
                Next = reverseCurrent
            };

            initialCurrent = initialCurrent.Next;
            reverseCurrent = reversePrevious;
        }

        return reverseCurrent;
    }
}

// Extremely basic singly linked list implementation for the purpose of the problem
public class LinkedListNode
{
    public int Value { get; set; }
    public LinkedListNode? Next { get; set; }

    public LinkedListNode(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
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
        return Value;
    }
}
