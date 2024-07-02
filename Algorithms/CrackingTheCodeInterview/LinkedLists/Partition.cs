namespace Algorithms.CrackingTheCodeInterview.LinkedLists.Partition;

// Source: "Cracking the coding interview" book (2.4 - Partition)
public class Partition
{
    public LinkedListNode? PartitionAroundThreshold(LinkedListNode start, int threshold)
    {
        // We go through the initial list and create two resulting linked lists
        // Every element lower than the threshold is placed in the "lower" list, all others in the "higher" list
        // At the end, we point the last element of the "lower" list to the first element of the "higher" list
        LinkedListNode? lower = null; // "lower" list's current element
        LinkedListNode? higher = null; // "higher" list's current element

        LinkedListNode? current = start; // keeps track of the current element of the input list
        LinkedListNode? firstLower = null; // stores the very first element of the "lower" list so that it can be returned
        LinkedListNode? firstHigher = null; // stores the first element of the "higher" list

        while (current != null)
        {
            if (current.Value < threshold)
            {
                if (lower == null)
                {
                    firstLower = current;
                }
                else
                {
                    lower.Next = current;
                }
                lower = current;
            }
            else
            {
                if (higher == null)
                {
                    firstHigher = current;
                }
                else
                {
                    higher.Next = current;
                }
                higher = current;
            }

            current = current.Next;
        }

        if (lower is not null)
        {
            lower.Next = firstHigher; // merge the two lists
        }
        if (higher is not null)
        {
            higher.Next = null; // very important to prevent potentially infinite loops
        }

        return firstLower;
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
