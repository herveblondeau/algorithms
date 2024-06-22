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
            int number1 = _reverseToInt(number1Start);
            int number2 = _reverseToInt(number2Start);
            int sum = number1 + number2;

            return _toReverse(sum);
        }

        // Follow up
        public static LinkedListNode SumForwardOrderNumbers(LinkedListNode number1Start, LinkedListNode number2Start)
        {
            int number1 = _forwardToInt(number1Start);
            int number2 = _forwardToInt(number2Start);
            int sum = number1 + number2;

            return _toForward(sum);
        }

        private static int _reverseToInt(LinkedListNode start)
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

        private static LinkedListNode _toReverse(int number)
        {
            if (number == 0)
                return null;

            LinkedListNode start = new(number % 10);
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

        private static int _forwardToInt(LinkedListNode start)
        {
            if (start == null)
                return -1;

            // Loop a first time to get the list length
            int length = 0;
            LinkedListNode current = start;
            while (current != null)
            {
                length++;
                current = current.Next;
            }

            // Loop a second time to compute the number
            int number = 0;
            int power = length - 1;
            current = start;
            while (current != null)
            {
                number += current.Value * (int)Math.Pow(10, power);
                power--;
                current = current.Next;
            }

            return number;
        }

        private static LinkedListNode _toForward(int number)
        {
            if (number == 0)
                return null;

            // Example with 3628
            int tenPowered = Convert.ToInt32(Math.Pow(10, number.ToString().Length - 1)); // -> 10^3, i.e. 1000
            int digit = number / tenPowered; // ->3628 / 1000, i.e. 3
            LinkedListNode start = new(digit);
            LinkedListNode current = start;
            do
            {
                number -= tenPowered * digit; // after first iteration -> 3628 - 1000 * 3; i.e. 628
                tenPowered /= 10; // -> after first iteration -> 1000 / 10, i.e. 100
                digit = number / tenPowered; // after first iteration -> 628 / 100, i.e. 6

                current.Next = new LinkedListNode(digit);
                current = current.Next;
            } while (tenPowered > 1);

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
