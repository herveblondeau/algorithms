using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues.QueueViaStacks
{
    // Source: "Cracking the coding interview" book (3.4 - Queue via stacks)
    public class QueueViaStacks
    {
        // Simulating a queue with a stack would imply adding elements at the bottom of the stack, which is impossible
        // However, using a temporary stack, we can make sure the elements are always kept in the FIFO order
        // When we want to enqueue a value, we:
        // - pop all elements to a temporary stack, reversing their order
        // - add the value to the actual stack, making it the bottom element
        // - pop the temporary stack elements back to the actual stack
        private Stack<int> _values;
        private Stack<int> _temp;

        public QueueViaStacks()
        {
            _values = new Stack<int>();
            _temp = new Stack<int>();
        }

        // O(n) time
        public void Enqueue(int value)
        {
            // Pop all elements from the actual stack and push them to the temporary stack
            // This reverses their order
            while (_values.Count > 0)
            {
                _temp.Push(_values.Pop());
            }

            // Push the new value to the actual stack
            // The value therefore goes at the bottom
            _values.Push(value); ;

            // Pop all elements from the actual stack and push them to the temporary stack
            // This places them in their initial order, on top of the new value
            while (_temp.Count > 0)
            {
                _values.Push(_temp.Pop());
            }
        }

        public int Dequeue()
        {
            if (_values.Count > 0)
            {
                return _values.Pop();
            }

            return Int32.MinValue;
        }

        public int Peek()
        {
            if (_values.Count > 0)
            {
                return _values.Peek();
            }

            return Int32.MinValue;
        }

    }
}
