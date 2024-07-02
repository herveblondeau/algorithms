using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues.StackOfPlates;

// Source: "Cracking the coding interview" book (3.3 - Stack of plates)
public class StackOfPlates
{
    // We use integers instead of a generic type as the focus of the problem is not on genericity

    private Stack<int> _activeStack; // This is the working stack, where elements are pushed until it reaches full capacity
    private Stack<Stack<int>> _savedStacks; // Full stacks are saved here

    private int _capacity;

    public StackOfPlates(int capacity)
    {
        _savedStacks = new Stack<Stack<int>>();
        _activeStack = new Stack<int>();
        _capacity = capacity;
    }

    public void Push(int n)
    {
        // If the active stack is full, we save it and create a new active stack
        if (_activeStack.Count == _capacity)
        {
            _savedStacks.Push(_activeStack);
            _activeStack = new Stack<int>();
        }

        _activeStack.Push(n);
    }

    public int Pop()
    {
        int result = _activeStack.Count > 0 ? _activeStack.Pop() : Int32.MinValue;

        // If the active stack is now empty, we restore the last saved stack to become the new active one
        if (_activeStack.Count == 0 && _savedStacks.Count > 0)
        {
            _activeStack = _savedStacks.Pop();
        }

        return result;
    }

    public int Peek()
    {
        return _activeStack?.Count > 0 ? _activeStack.Peek() : Int32.MinValue;
    }

    public bool IsEmpty()
    {
        return _activeStack.Count == 0 && _savedStacks.Count == 0;
    }
}
