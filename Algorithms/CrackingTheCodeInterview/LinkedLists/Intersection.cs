namespace Algorithms.CrackingTheCodeInterview.LinkedLists.Intersection;

// Source: "Cracking the coding interview" book (2.7 - Intersection)
public class Intersection
{
    public LinkedListNode? GetIntersection(LinkedListNode start1, LinkedListNode start2)
    {
        if (start1 is null || start2 is null)
        {
            return null;
        }

        LinkedListNode? current;
        LinkedListNode current1 = null!;
        LinkedListNode current2 = null!;

        // Go through the lists once to determine their respective lengths and end nodes
        int length1 = 0;
        current = start1;
        while (current is not null)
        {
            length1++;
            current1 = current;
            current = current.Next;
        }

        int length2 = 0;
        current = start2;
        while (current is not null)
        {
            length2++;
            current2 = current;
            current = current.Next;
        }

        // The lists intersect if and only if they end at the same node
        if (current1 != current2)
        {
            return null;
        }

        // At this stage we know that the lists converge, therefore their last n elements are the same.
        // If we just remove the first elements from the shorter list so that both lists end up with the same number of elements, we can then just go through both lists simultaneously until they reach a common element
        current1 = start1;
        current2 = start2;
        if (length1 < length2)
        {
            for (int i = length1; i < length2; i++)
            {
                current1 = current1.Next!;
            }
        }
        else if (length2 < length1)
        {
            for (int i = length2; i < length1; i++)
            {
                current2 = current2.Next!;
            }
        }
        while (current1 != current2)
        {
            current1 = current1.Next!;
            current2 = current2.Next!;
        }

        return current1;
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
