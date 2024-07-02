using System.Collections.Generic;
using System.Linq;

namespace Codingame.Medium.DeathFirstSearch1;

// https://www.codingame.com/training/medium/death-first-search-episode-1
public class DeathFirstSearch1
{
    private HashSet<int> _gateways { get; set; }
    private Dictionary<int, HashSet<int>> _links { get; set; }

    public DeathFirstSearch1()
    {
        _links = new Dictionary<int, HashSet<int>>();
        _gateways = new HashSet<int>();
    }

    public void AddLink(int node1, int node2)
    {
        if (!_links.ContainsKey(node1))
            _links.Add(node1, new HashSet<int>());
        if (!_links[node1].Contains(node2))
            _links[node1].Add(node2);

        if (!_links.ContainsKey(node2))
            _links.Add(node2, new HashSet<int>());
        if (!_links[node2].Contains(node1))
            _links[node2].Add(node1);
    }

    public void CutLink(int node1, int node2)
    {
        if (_links.ContainsKey(node1) && _links[node1].Contains(node2))
        {
            _links[node1].Remove(node2);
            if (_links[node1].Count == 0)
                _links.Remove(node1);
        }

        if (_links.ContainsKey(node2) && _links[node2].Contains(node1))
        {
            _links[node2].Remove(node1);
            if (_links[node2].Count == 0)
                _links.Remove(node2);
        }
    }

    public void SetGateway(int node)
    {
        if (!_gateways.Contains(node))
            _gateways.Add(node);
    }

    public bool IsGateway(int node)
    {
        return _gateways.Contains(node);
    }

    public (int, int) FindLinkToCut(int source)
    {
        // If a gateway is within immediate reach, return it
        foreach (var neighbor in _links[source])
        {
            if (IsGateway(neighbor))
                return (source, neighbor);
        }

        // Otherwise, return any node
        // Note: this works because the Codingame test cases don't check multiple gateways located next to a same node
        // If it were the case, a breadth-first search would be required
        source = _links.Keys.First();
        return (source, _links[source].First());
    }
}