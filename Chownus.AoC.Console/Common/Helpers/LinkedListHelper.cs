using System.Collections.Generic;

namespace Chownus.AoC.Console.Common.Helpers
{
    public static class LinkedListHelper
    {
        public static LinkedListNode<T> GetNextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        public static LinkedListNode<T> GetPreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }

        public static LinkedListNode<T> Skip<T>(this LinkedListNode<T> current, int count)
        {
            if (count == 0) return current;

            while (count > 0)
            {
                current = GetNextOrFirst(current);
                count--;
            }

            return current;
        }

        // Reverses the next N nodes in the list
        public static LinkedListNode<T> ReverseSection<T>(this LinkedListNode<T> current, int n)
        {
            var subset = new T[n];

            for (int i = 0; i < n; i++)
            {
                subset[i] = current.Value;

                if (i < n - 1)
                    current = current.GetNextOrFirst();
            }

            for (int i = 0; i < n; i++)
            {
                current.Value = subset[i];

                if (i < n - 1)
                    current = current.GetPreviousOrLast();
            }

            // Skip ahead forward to the next one
            return current.Skip(n);
        }
    }
}
