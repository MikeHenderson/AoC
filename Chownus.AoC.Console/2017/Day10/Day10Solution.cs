using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console
{
    public class Day10Solution : IAoCSolution
    {
        private IEnumerable<int> _input;

        public int Day => 10;

        public string RunPart1()
        {
            var list = GenerateList();
            var skipCount = 0;
            var current = list.First;

            foreach (var direction in _input)
            {
                current = ReverseSection(current, direction);

                current = Skip(current, skipCount);

                skipCount++;
            }

            return (list.First.Value * list.First.Next.Value).ToString();
        }

        private LinkedListNode<int> ReverseSection(LinkedListNode<int> current, int direction)
        {
            var subset = new int[direction];

            for (int i = 0; i < direction; i++)
            {
                subset[i] = current.Value;

                if(i < direction - 1)
                    current = GetNextOrFirst(current);
            }

            for (int i = 0; i < direction; i++)
            {
                current.Value = subset[i];

                if(i < direction - 1)
                    current = GetPreviousOrLast(current);
            }

            // Skip ahead forward to the next one
            return Skip(current, direction);
        }

        public string RunPart2()
        {
            return "";
        }

        public void Initialize(IEnumerable<string> input)
        {
            _input = input.First().Split(',').Select(int.Parse);
        }

        private LinkedList<int> GenerateList()
        {
            var list = new LinkedList<int>();

            var head = list.AddFirst(0);

            for (int i = 1; i <= 255; i++)
                head = list.AddAfter(head, i);

            return list;
        }

        // Create the behavior of a circularly linked list
        private LinkedListNode<int> GetNextOrFirst(LinkedListNode<int> current)
        {
            return current.Next ?? current.List.First;
        }

        private LinkedListNode<int> GetPreviousOrLast(LinkedListNode<int> current)
        {
            return current.Previous ?? current.List.Last;
        }

        private LinkedListNode<int> Skip(LinkedListNode<int> current, int count)
        {
            if (count == 0) return current;

            while (count > 0)
            {
                current = GetNextOrFirst(current);
                count--;
            }

            return current;
        }
    }
}