using System;
using System.Collections.Generic;

// https://www.geeksforgeeks.org/water-jug-problem-using-memoization/?ref=rp
public class WaterJug
{
    private List<(int, int)> _solution;
    private int _leftCapacity;
    private int _rightCapacity;
    private int _target;

    public List<(int, int)> Solve(int leftCapacity, int rightCapacity, int target)
    {
        _solution = new List<(int, int)>();
        _leftCapacity = leftCapacity;
        _rightCapacity = rightCapacity;
        _target = target;
        var isSolved = MemoizationSolve(0, 0);

        return isSolved ? _solution : null;
    }

    private bool MemoizationSolve(int left, int right)
    {
        if (IsAlreadyVisited(left, right))
        {
            return false;
        }

        AppendCurrentPositionToSolution(left, right);

        if (IsSolved(left, right))
        {
            return true;
        }

        return MemoizationSolve(0, right)               // empty left
            || MemoizationSolve(left, 0)                // empty right
            || MemoizationSolve(_leftCapacity, right)   // fill left
            || MemoizationSolve(left, _rightCapacity)   // fill right
            || MemoizationSolve(left - Math.Min(left, _rightCapacity - right), right + Math.Min(left, _rightCapacity - right))  // pour left into right
            || MemoizationSolve(left + Math.Min(right, _leftCapacity - left), right - Math.Min(right, _leftCapacity - left))     // pour right into left
        ;
    }

    private bool IsAlreadyVisited(int left, int right)
    {
        return _solution.Contains((left, right));
    }

    private void AppendCurrentPositionToSolution(int left, int right)
    {
        _solution.Add((left, right));
    }

    private bool IsSolved(int left, int right)
    {
        return (left == _target && right == 0)
            || (left == 0 && right == _target);
    }
}
