using System.Collections.Generic;

public class FirstDuplicate
{
    public T Find<T>(T[] elements)
    {
        HashSet<T> visited = new HashSet<T>();

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
}
