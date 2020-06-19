using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.CrackingTheCodeInterview.LinkedLists.RemoveDups
{
    public class RemoveDups
    {
        // First part of the problem: 0(n) space
        public static void RemoveDuplicatesWithBuffer(LinkedListNode start)
        {
            LinkedListNode current;

            HashSet<LinkedListNode> existingNodes = new HashSet<LinkedListNode>();
            current = start;
            while (current != null)
            {
                existingNodes.Add(current);
                while (current.Next != null && existingNodes.Contains(current.Next))
                {
                    current.Next = current.Next.Next;
                }
                current = current.Next;
            }
        }

        // Second part of the problem: O(1) space
        // TODO: improve with one less nested loop
        public static void RemoveDuplicatesWithoutBuffer(LinkedListNode start)
        {
            LinkedListNode current;
            LinkedListNode lookup;

            current = start;
            while (current != null)
            {
                lookup = current;
                while (lookup.Next != null)
                {
                    if (current.Equals(lookup.Next))
                    {
                        lookup.Next = lookup.Next.Next;
                    }
                    else
                    {
                        lookup = lookup.Next;
                    }
                }
                current = current.Next;
            }
        }
    }

    // Extremely basic linked list implementation for the purpose of the problem
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

}
