﻿// https://www.codingame.com/training/medium/telephone-numbers

using System.Collections.Generic;
using System.Text;

namespace Codingame.Medium.TelephoneNumbersSolver;

public class TelephoneNumbersSolver
{
    public int GetNumberOfRequiredNodes(string[] phoneNumbers)
    {
        HashSet<string> nodes = new();
        StringBuilder currentNodePath = new();

        foreach (var number in phoneNumbers)
        {
            currentNodePath.Clear();
            foreach (char digitChar in number)
            {
                currentNodePath.Append(digitChar - '0');
                nodes.Add(currentNodePath.ToString());
            }
        }
        return nodes.Count;
    }
}