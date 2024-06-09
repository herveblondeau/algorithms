using System;
using System.Linq;

namespace ByTheme.Sorting
{
    public class Sorting
    {
        public T[] QuickSort<T>(T[] elements) where T : IComparable<T>
        {
            if (elements.Length <= 1)
            {
                return elements;
            }

            var pivot = elements[0];
            var less = elements[1..].Where(e => e.CompareTo(pivot) <= 0).ToArray();
            var greater = elements[1..].Where(e => e.CompareTo(pivot) > 0).ToArray();
            T[] sorted = [..QuickSort(less), pivot, ..QuickSort(greater)];
            return sorted;
        }
    }
}
