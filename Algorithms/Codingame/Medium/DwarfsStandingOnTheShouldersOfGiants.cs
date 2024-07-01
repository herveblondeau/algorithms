// https://www.codingame.com/training/medium/dwarfs-standing-on-the-shoulders-of-giants

using System;
using System.Collections.Generic;

namespace Codingame.Medium.DwarfsStandingOnTheShouldersOfGiants;

public class DwarfsStandingOnTheShouldersOfGiants
{
    private Dictionary<int, int> _longestInfluences { get; set; }

    public int GetLongestInfluence(Dictionary<int, List<int>> relations)
    {
        // Keeps track of the longest influence for each person (memoization)
         _longestInfluences = new Dictionary<int, int>();

        // Compute the longest influence for each person
        int maxSubDepth = 0;
        foreach (var v in relations.Keys)
        {
            maxSubDepth = Math.Max(maxSubDepth, _getInfluence(v, relations));
        }

        return maxSubDepth + 1;
    }

    private int _getInfluence(int person, Dictionary<int, List<int>> relations)
    {
        // Memorized result
        if (_longestInfluences.ContainsKey(person))
        {
            return _longestInfluences[person];
        }

        // Exit condition
        if (!relations.ContainsKey(person) || relations[person].Count == 0)
        {
            return 0;
        }

        // Recursion
        int maxSubDepth = 0;
        foreach (var v in relations[person])
        {
            maxSubDepth = Math.Max(maxSubDepth, _getInfluence(v, relations));
        }

        // Memorization
        _longestInfluences[person] = 1 + maxSubDepth;

        return maxSubDepth + 1;
    }
}
