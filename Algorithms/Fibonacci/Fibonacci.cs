using System;

public class Fibonacci
{
    // Recursion
    // O(2^n) time
    public static long Recursion(long n)
    {
        if (n <= 2)
        {
            return 1;
        }

        return Recursion(n - 1) + Recursion(n - 2);
    }

    #region DYNAMIC PROGRAMMING

    // https://programming.guide/dynamic-programming-vs-memoization-vs-tabulation.html
    // O(n) time, O(n) space

    // Dynamic programming - Tabulation
    public static long Tabulation(long n)
    {
        long[] results = new long[n];
        results[0] = 1;
        results[1] = 1;
        for (int i = 2; i < n; i++)
        {
            results[i] = results[i - 2] + results[i - 1];
        }
        return results[n - 1];
    }

    // Dynamic programming - Memoization
    private static long[] _memoizationResults;
    public static long Memoization(long n)
    {
        _memoizationResults = new long[n];
        _memoizationResults[0] = 1;
        _memoizationResults[1] = 1;

        return _Memoization(n);
    }

    private static long _Memoization(long n)
    {
        if (_memoizationResults[n - 1] == 0)
        {
            _memoizationResults[n - 1] = _Memoization(n - 2) + _Memoization(n - 1);
        }

        return _memoizationResults[n - 1];
    }

    #endregion

    // Simple loop
    // O(n) time, O(1) space
    public static long SimpleLoop(long n)
    {
        long result = 1;
        if (n <= 2)
        {
            return result;
        }

        long previousPrevious = 1;
        long previous = 1;
        for (int i = 2; i < n; i++)
        {
            result = previousPrevious + previous;
            previousPrevious = previous;
            previous = result;
        }

        return result;
    }
}
