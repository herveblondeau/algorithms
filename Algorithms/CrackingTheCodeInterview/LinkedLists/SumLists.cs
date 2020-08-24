using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.CrackingTheCodeInterview.LinkedLists.SumLists
{
    // Source: "Cracking the coding interview" book (2.5 - Sum Lists)
    public class SumLists
    {
        // Base problem
        public static LinkedListNode SumReverseOrderNumbers(LinkedListNode number1Start, LinkedListNode number2Start)
        {
            int number1 = _toInt(number1Start);
            int number2 = _toInt(number2Start);
            int sum = number1 + number2;

            return _toLinkedList(sum);
        }

        // Follow up
        public static LinkedListNode SumForwardOrderNumbers(LinkedListNode number1Start, LinkedListNode number2Start)
        {
            // TODO: implement
            return null;
        }

        private static int _toInt(LinkedListNode start)
        {
            int power = 0;
            int number = 0;
            LinkedListNode current = start;
            while (current != null)
            {
                number += current.Value * (int)Math.Pow(10, power);
                power++;
                current = current.Next;
            }

            return number;
        }

        private static LinkedListNode _toLinkedList(int number)
        {
            if (number == 0)
                return null;

            LinkedListNode start = new LinkedListNode(number % 10);
            number = number / 10;

            LinkedListNode current = start;
            while (number > 0)
            {
                current.Next = new LinkedListNode(number % 10);
                current = current.Next;
                number = number / 10;
            }

            return start;
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
