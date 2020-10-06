using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues.SortStack
{
    // Source: "Cracking the coding interview" book (3.5 - Sort stack)
    public class SortStack
    {
        // We use integers instead of a generic type as the focus of the problem is not on genericity

        // This problem is very similar to 3.4 (Queue via stacks). The only difference is that we don't want new elements added at the bottom, but at a position based on their order
        // So the algorithm is also almost the same. The only difference is when we pop all elements to a temporary stack, we push the new element not at the end but at its correct position
        private Stack<int> _values;
        private Stack<int> _temp;

        public SortStack()
        {
            _values = new Stack<int>();
            _temp = new Stack<int>();
        }

        // O(n) time
        public void Enqueue(int value)
        {
            // Pop all elements from the actual stack and push them to the temporary stack
            // This reverses their order
            int current;
            bool hasBeenInserted = false;
            while (_values.Count > 0)
            {
                current = _values.Pop();

                // Insert the value at the correct position
                if (value < current && !hasBeenInserted)
                {
                    _temp.Push(value);
                    hasBeenInserted = true;
                }

                _temp.Push(current);
            }

            // If there was no element to begin with, we insert the value as the only element
            if (!hasBeenInserted)
            {
                _temp.Push(value);
            }

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
