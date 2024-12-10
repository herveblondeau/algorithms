// https://www.codingame.com/training/expert/spy-the-spies

using System.Collections.Generic;

namespace Codingame.Expert.SpyTheSpies;

public class SpyTheSpies
{
    public List<(string Attribute, bool IsNegation)>? FindShortestPath(Dictionary<string, HashSet<string>> suspectsWithAttributes, HashSet<string> spies)
    {
        HashSet<string> identifiedSpies = new();
        List<(string Attribute, bool IsNegation)> path = new();
        int shortestPathLength = int.MaxValue;

        return _findShortestPath(suspectsWithAttributes, spies, identifiedSpies, path, shortestPathLength);
    }

    private List<(string Attribute, bool IsNegation)>? _findShortestPath(Dictionary<string, HashSet<string>> suspectsWithAttributes, HashSet<string> spies, HashSet<string> identifiedSpies, List<(string Attribute, bool IsNegation)> path, int shortestPathLength)
    {
        // Current path already longer than best solution so far?
        if (path.Count >= shortestPathLength)
        {
            return null;
        }

        // Recursively apply all possible sets
        var possibleSets = _getPossibleSets(suspectsWithAttributes, spies);
        // var newShortestPath = null;
        List<(string Attribute, bool IsNegation)>? newShortestPath = null;
        List<(string Attribute, bool IsNegation)>? currentShortestPath = null;
        foreach (var set in possibleSets)
        {
            var currentPath = new List<(string Attribute, bool IsNegation)>();
            foreach (var x in path)
            {
                currentPath.Add((x.Attribute, x.IsNegation));
            }
            currentPath.Add((set.Key, set.Value.IsNegation));
            if (currentPath.Count == 1)
            {

            }

            var (currentSuspectsWithAttributes, currentIdentifiedSpies) = _applyAttribute(suspectsWithAttributes, spies, identifiedSpies, set.Key, set.Value.IsNegation);

            // Spies found?
            if (currentIdentifiedSpies.Count == spies.Count)
            {
                bool spiesFound = true;
                foreach (var spy in spies)
                {
                    if (!currentIdentifiedSpies.Contains(spy))
                    {
                        spiesFound = false;
                        break;
                    }
                }
                if (spiesFound)
                {
                    return currentPath;
                }
            }

            // All innocents removed?
            if (currentSuspectsWithAttributes.Keys.Count == spies.Count)
            {
                bool spiesFound = true;
                foreach (var spy in spies)
                {
                    if (!currentSuspectsWithAttributes.ContainsKey(spy))
                    {
                        spiesFound = false;
                        break;
                    }
                }
                if (spiesFound)
                {
                    return currentPath;
                }
            }

            currentShortestPath = _findShortestPath(currentSuspectsWithAttributes, spies, currentIdentifiedSpies, currentPath, shortestPathLength);
            if (currentShortestPath is not null && currentShortestPath.Count < shortestPathLength)
            {
                newShortestPath = currentShortestPath;
                shortestPathLength = newShortestPath.Count;
            }
        }
        return newShortestPath;

    }

    private Dictionary<string, (HashSet<string> Suspects, bool IsNegation)> _getPossibleSets(Dictionary<string, HashSet<string>> suspectsWithAttributes, HashSet<string> spies)
    {
        Dictionary<string, (HashSet<string> Suspects, bool IsNegation)> possibleSets = new();

        HashSet<string> suspects = new();
        HashSet<string> innocents = new();
        // HashSet<string> attributes = new();
        Dictionary<string, HashSet<string>> attributesWithSuspects = new();
        foreach (var suspect in suspectsWithAttributes.Keys)
        {
            suspects.Add(suspect);

            if (!spies.Contains(suspect))
            {
                innocents.Add(suspect);
            }

            foreach (var attribute in suspectsWithAttributes[suspect])
            {
                // attributes.Add(attribute);
                if (!attributesWithSuspects.ContainsKey(attribute))
                {
                    attributesWithSuspects.Add(attribute, new());
                }
                attributesWithSuspects[attribute].Add(suspect);
            }
        }

        // List sets with only spies and sets with only innocents
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
                possibleSets.Add(set.Key, (Suspects: set.Value, IsNegation: false));
            }
            if (hasOnlyInnocents)
            {
                possibleSets.Add(set.Key, (Suspects: set.Value, IsNegation: true));
            }
        }

        return possibleSets;
    }

    private (Dictionary<string, HashSet<string>> SuspectsWithAttributes, HashSet<string> IdentifiedSpies) _applyAttribute(Dictionary<string, HashSet<string>> suspectsWithAttributes, HashSet<string> spies, HashSet<string> identifiedSpies, string attribute, bool isNegation)
    {
        Dictionary<string, HashSet<string>> newSuspectsWithAttributes = new();
        foreach (var x in suspectsWithAttributes)
        {
            newSuspectsWithAttributes.Add(x.Key, new());
            foreach (var y in x.Value)
            {
                newSuspectsWithAttributes[x.Key].Add(y);
            }
        }

        HashSet<string> newIdentifiedSpies = [.. identifiedSpies];

        foreach (var suspect in suspectsWithAttributes.Keys)
        {
            if (suspectsWithAttributes[suspect].Contains(attribute))
            {
                if (!isNegation)
                {
                    newIdentifiedSpies.Add(suspect);
                }
                newSuspectsWithAttributes.Remove(suspect);
            }
        }

        return (newSuspectsWithAttributes, newIdentifiedSpies);
    }
}
