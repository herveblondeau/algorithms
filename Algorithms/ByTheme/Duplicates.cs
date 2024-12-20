﻿using System.Collections.Generic;

namespace ByTheme.Duplicates;

public class Duplicates
{
    public T FindFirstDuplicate<T>(T[] elements)
    {
        HashSet<T> visited = new();

        for (int i = 0; i < elements.Length; i++)
        {
            if (visited.Contains(elements[i]))
            {
                return elements[i];
            }

            visited.Add(elements[i]);
        }

        throw new KeyNotFoundException();
    }

    public T FindFirstNonDuplicate<T>(T[] elements) where T : notnull
    {
        Dictionary<T, int> nbOccurrences = new();

        for (int i = 0; i < elements.Length; i++)
        {
            if (nbOccurrences.ContainsKey(elements[i]))
            {
                nbOccurrences[elements[i]]++;
            }
            else
            {
                nbOccurrences.Add(elements[i], 1);
            }
        }

        for (int i = 0; i < elements.Length; i++)
        {
            if (nbOccurrences[elements[i]] == 1)
            {
                return elements[i];
            }
        }

        throw new KeyNotFoundException();
    }
}