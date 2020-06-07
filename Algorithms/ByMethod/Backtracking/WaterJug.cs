using System;
using System.Collections.Generic;
using System.Linq;

namespace ByMethod.Backtracking
{
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

        // TODO: improve the algorithm to return the shortest path
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

            // Note: in the link above, the initial solution was using memoization by just returning the result of the following combination of paths
            // We have modified the solution to use a backtracking method:
            // - we return only if one of the paths yields a solution
            // - otherwise, we remove the current position from the solution (actual backtracking)
            if (MemoizationSolve(0, right)               // empty left
             || MemoizationSolve(left, 0)                // empty right
             || MemoizationSolve(_leftCapacity, right)   // fill left
             || MemoizationSolve(left, _rightCapacity)   // fill right
             || MemoizationSolve(left - Math.Min(left, _rightCapacity - right), right + Math.Min(left, _rightCapacity - right))  // pour left into right
             || MemoizationSolve(left + Math.Min(right, _leftCapacity - left), right - Math.Min(right, _leftCapacity - left))     // pour right into left
            )
            {
                return true;
            }

            RemoveCurrentPositionFromSolution();

            return false;
        }

        private bool IsAlreadyVisited(int left, int right)
        {
            return _solution.Contains((left, right));
        }

        private void AppendCurrentPositionToSolution(int left, int right)
        {
            _solution.Add((left, right));
        }

        private void RemoveCurrentPositionFromSolution()
        {
            _solution.Remove(_solution.Last());
        }

        private bool IsSolved(int left, int right)
        {
            return (left == _target && right == 0)
                || (left == 0 && right == _target);
        }
    }
}