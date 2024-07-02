using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues.StackMin;

// Source: "Cracking the coding interview" book (3.2 - Stack Min)
public class StackMin
{
    // We use integers instead of a generic type as the focus of the problem is not on genericity
    private Stack<int> _stack;

    // The first thought would be to use a single min variable, but it couldn't be updated in O(1) time when popping
    // In order to ensure O(1) time for all operations, we need another stack that keeps the min value at each stage
    private Stack<int> _mins;

    public StackMin()
    {
        _stack = new Stack<int>();
        _mins = new Stack<int>();
    }

    public void Push(int n)
    {
        _stack.Push(n);
        _mins.Push(_mins.Count > 0 ? Math.Min(_mins.Peek(), n) : n);
    }

    public int Pop()
    {
        _mins.Pop();
        return _stack.Pop();
    }

    public int Peek()
    {
        return _stack.Peek();
    }

    public bool IsEmpty()
    {
        return _stack.Count == 0;
    }

    public int Min()
    {
        return _mins.Count > 0 ? _mins.Peek() : Int32.MaxValue;
    }
}
