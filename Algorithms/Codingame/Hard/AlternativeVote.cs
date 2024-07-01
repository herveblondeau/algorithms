// https://www.codingame.com/training/hard/alternative-vote

using System.Collections.Generic;
using System.Linq;

namespace Codingame.Hard.AlternativeVote;

public class AlternativeVote
{
    public List<string> GetEliminations(List<string> candidateNames, List<List<int>> voters)
    {
        List<string> eliminations = new();
        List<int> remainingCandidates = Enumerable.Range(1, candidateNames.Count).ToList();

        var nbRounds = remainingCandidates.Count;
        for (int _ = 0; _ < nbRounds; _++) // there are as many rounds as candidates
        {
            // Hold a voting round
            Dictionary<int, int> nbVotes = new();
            foreach (var i in remainingCandidates)
            {
                nbVotes[i] = 0;
            }

            foreach (var preferences in voters)
            {
                nbVotes[preferences[0]]++;
            }

            // Find the least favorite candidate
            // The "<=" comparison is extremely important and cannot be replaced with "<". The equality part ensures that, when there are multiple candidates with the least amount of votes, the first one in the candidates list will be selected
            var leastFavoriteCandidate = nbVotes.Aggregate((l, r) => l.Value <= r.Value ? l : r).Key;

            // Remove that candidate from all preferences
            foreach (var preferences in voters)
            {
                preferences.Remove(leastFavoriteCandidate);
            }
            remainingCandidates.Remove(leastFavoriteCandidate);

            // And add them to the elimination pool
            eliminations.Add(candidateNames[leastFavoriteCandidate - 1]);
        }

        return eliminations;
    }
}
