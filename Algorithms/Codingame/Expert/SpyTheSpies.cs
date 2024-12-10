// https://www.codingame.com/training/expert/spy-the-spies

using System.Collections.Generic;

namespace Codingame.Expert.SpyTheSpies;

public class SpyTheSpies
{
    public List<(string Attribute, bool IsNegation)>? FindShortestPath(
        Dictionary<string, HashSet<string>> suspectsWithAttributes,
        HashSet<string> spies)
    {
        // Since a guess immediately eliminates all suspects that share it (or, if negated, don't share it), we never want to apply a guess on an attribute shared by both spies and innocents
        // This drastically reduces the number of guess combinations to try and gives the following algorithm:
        // - list all attributes that are shared only by spies or by innocents; store the former as regular guesses ("xxx") and the latter as negated guesses ("NOT xxx")
        // - recursively apply all these guesses, keeping track of the path applied for each combination and the best solution found
        // Note: because we use recursion/backtracking while needing to keep track of the path, identified spies etc. at each step, we create deep copies of each object (otherwise, with shallow copies, we would have to restore the state of each object as we backtrack)

        HashSet<string> identifiedSpies = new();
        List<(string Attribute, bool IsNegation)> path = new();
        int shortestPathLength = int.MaxValue;

        return _findShortestPath(suspectsWithAttributes, spies, identifiedSpies, path, shortestPathLength);
    }

    private List<(string Attribute, bool IsNegation)>? _findShortestPath(
        Dictionary<string, HashSet<string>> suspectsWithAttributes,
        HashSet<string> spies,
        HashSet<string> identifiedSpies,
        List<(string Attribute, bool IsNegation)> path,
        int shortestPathLength)
    {
        // Current path already as long as best solution so far
        if (path.Count == shortestPathLength)
        {
            return null;
        }

        // Find and recursively apply all possible guesses
        var possibleGuesses = _getPossibleGuesses(suspectsWithAttributes, spies);
        List<(string Attribute, bool IsNegation)>? newShortestPath = null;
        List<(string Attribute, bool IsNegation)>? currentShortestPath = null;
        foreach (var set in possibleGuesses)
        {
            // Build the path with the new guess
            // (deep copy in order to preserve the initial object for backtracking purposes)
            var currentPath = new List<(string Attribute, bool IsNegation)>();
            foreach (var x in path)
            {
                currentPath.Add((x.Attribute, x.IsNegation));
            }
            currentPath.Add((set.Key, set.Value));

            // Apply the guess
            var (currentSuspectsWithAttributes, currentIdentifiedSpies) = _applyGuess(suspectsWithAttributes, identifiedSpies, (Attribute: set.Key, IsNegation: set.Value));

            // Are all spies identified directly?...
            if (_areAllSpiesFound(currentIdentifiedSpies, spies))
            {
                return currentPath;
            }

            // ...or indirectly? (i.e. only spies remain in the suspects pool)
            HashSet<string> currentRemainingSuspects = [.. currentSuspectsWithAttributes.Keys];
            if (_areAllSpiesFound(currentRemainingSuspects, spies))
            {
                return currentPath;
            }

            // Recursion from the new current path
            currentShortestPath = _findShortestPath(currentSuspectsWithAttributes, spies, currentIdentifiedSpies, currentPath, shortestPathLength);
            if (currentShortestPath is not null && currentShortestPath.Count < shortestPathLength)
            {
                newShortestPath = currentShortestPath;
                shortestPathLength = newShortestPath.Count;
            }
        }
        return newShortestPath;

    }

    private Dictionary<string, bool> _getPossibleGuesses(
        Dictionary<string, HashSet<string>> suspectsWithAttributes,
        HashSet<string> spies)
    {
        // Build the list of innocents
        // And more importantly, "reverse" the suspect/attribute mappings to get the list of suspects matching each attribute. This will make it easier to find the attributes that are shared between spies only or innocents only
        HashSet<string> innocents = new();
        Dictionary<string, HashSet<string>> attributesWithSuspects = new();
        foreach (var suspect in suspectsWithAttributes.Keys)
        {
            if (!spies.Contains(suspect))
            {
                innocents.Add(suspect);
            }

            foreach (var attribute in suspectsWithAttributes[suspect])
            {
                if (!attributesWithSuspects.ContainsKey(attribute))
                {
                    attributesWithSuspects.Add(attribute, new());
                }
                attributesWithSuspects[attribute].Add(suspect);
            }
        }

        // Deduce the possible guesses
        Dictionary<string, bool> possibleGuesses = new();
        foreach (var set in attributesWithSuspects)
        {
            bool hasOnlySpies = true;
            bool hasOnlyInnocents = true;
            foreach (var suspect in set.Value)
            {
                if (!spies.Contains(suspect))
                {
                    hasOnlySpies = false;
                }
                if (!innocents.Contains(suspect))
                {
                    hasOnlyInnocents = false;
                }
            }
            if (hasOnlySpies)
            {
                possibleGuesses.Add(set.Key, false);
            }
            if (hasOnlyInnocents)
            {
                possibleGuesses.Add(set.Key, true);
            }
        }

        return possibleGuesses;
    }

    private (Dictionary<string, HashSet<string>> SuspectsWithAttributes, HashSet<string> IdentifiedSpies) _applyGuess(
        Dictionary<string, HashSet<string>> suspectsWithAttributes,
        HashSet<string> identifiedSpies,
        (string Attribute, bool IsNegation) guess)
    {
        // (deep copy in order to preserve the initial object for backtracking purposes)
        Dictionary<string, HashSet<string>> newSuspectsWithAttributes = new();
        foreach (var x in suspectsWithAttributes)
        {
            newSuspectsWithAttributes.Add(x.Key, new());
            foreach (var y in x.Value)
            {
                newSuspectsWithAttributes[x.Key].Add(y);
            }
        }

        // (deep copy in order to preserve the initial object for backtracking purposes)
        HashSet<string> newIdentifiedSpies = [.. identifiedSpies];

        // Actually apply the guess
        foreach (var suspect in suspectsWithAttributes.Keys)
        {
            if (suspectsWithAttributes[suspect].Contains(guess.Attribute))
            {
                // As written in the problem description:

                // 1) A non negation flags the suspect as a spy
                // Note: a negation flags the suspect as an innocent, but we don't need to keep track of the innocents
                if (!guess.IsNegation)
                {
                    newIdentifiedSpies.Add(suspect);
                }

                // 2) Any suspect matched by a guess is immediately discarded from the list of suspects
                newSuspectsWithAttributes.Remove(suspect);
            }
        }

        return (newSuspectsWithAttributes, newIdentifiedSpies);
    }

    private bool _areAllSpiesFound(HashSet<string> identifiedSpies, HashSet<string> spies)
    {
        if (identifiedSpies.Count != spies.Count)
        {
            return false;
        }

        bool allSpiesFound = true;
        foreach (var spy in spies)
        {
            if (!identifiedSpies.Contains(spy))
            {
                allSpiesFound = false;
                break;
            }
        }
        return allSpiesFound;
    }
}
