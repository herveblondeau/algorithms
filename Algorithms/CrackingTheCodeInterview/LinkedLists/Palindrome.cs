using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.LinkedLists.Palindrome
{
    // Source: "Cracking the coding interview" book (2.6 - Palindrome)
    public class Palindrome
    {
        public static bool IsPalindrome(LinkedListNode start)
        {
            // This can be debated but we consider an empty list to not be a palindrome
            if (start == null)
            {
                return false;
            }

            // Build the reverse of the list
            LinkedListNode initialCurrent = start;
            LinkedListNode reverseCurrent = new LinkedListNode(start.Value);
            while (initialCurrent.Next != null)
            {
                LinkedListNode reversePrevious = new LinkedListNode(initialCurrent.Next.Value);
                reversePrevious.Next = reverseCurrent;

                initialCurrent = initialCurrent.Next;
                reverseCurrent = reversePrevious;
            }

            // Compare both lists
            initialCurrent = start;
            while (initialCurrent != null)
            {
                if (initialCurrent.Value != reverseCurrent.Value)
                {
                    return false;
                }

                initialCurrent = initialCurrent.Next;
                reverseCurrent = reverseCurrent.Next;
            }

            return true;
        }
    }

    // Extremely basic singly linked list implementation for the purpose of the problem
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
