// Source: "Cracking the coding interview" book (2.8 - Loop Detection)

namespace CrackingTheCodeInterview.LinkedLists.LoopDetection;

public class LoopDetection
{
    public static LinkedListNode? GetLoopStart(LinkedListNode start)
    {
        // This algorithm is simple, taks O(n) time and O(1) space, but it modifies the list
        // We go through the elements, modifying each one to point to itself
        // As soon as we reach an element that points to itself, it means we have come back to a loop start
        LinkedListNode? current = start;
        if (current == null)
        {
            return null;
        }

        LinkedListNode temp;
        while (current != null && current != current.Next)
        {
            temp = current;
            current = current.Next;
            temp.Next = temp;
        }

        return current;
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
