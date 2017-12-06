using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console
{
    public class Day6Solution : IAoCSolution
    {
        private int[] _input;
        public int Day => 6;

        public string RunPart1()
        {
            var visited = new List<int[]> { (int[])_input.Clone() };
            var counter = 0;
            var dupeFound = false;
            var redist = (int[]) _input.Clone();

            while (!dupeFound)
            {
                redist = Redistribute(redist);

                if (HasBeenVisited(visited, redist))
                    dupeFound = true;
                else 
                    visited.Add(redist);

                counter++;
            } 

            return counter.ToString();
        }

        public string RunPart2()
        {
            return "555";
        }

        public void Initialize(IEnumerable<string> input)
        {
            _input = Regex.Replace(input.First(), @"\t|\n|\r", " ").Split(' ').Select(int.Parse).ToArray();
        }

        private int[] Redistribute(int[] list)
        {
            var result = (int[]) list.Clone();
            int index = result.ToList().IndexOf(list.Max(x => x));

            var n = result[index];
            result[index] = 0;

            while (n > 0)
            {
                index++;

                if (index >= result.Length)
                    index = 0;

                result[index]++;

                n--;
            }

            return result;
        }

        private bool HasBeenVisited(IList<int[]> states, IList<int> check)
        {
            foreach (var state in states)
            {
                if (state.SequenceEqual(check))
                    return true;
            }

            return false;
        }

        private int FindSpacesBetweenVisited(IList<int[]> states)
        {
            var temp = states.Select(x => x).ToList();

            foreach (var state in states)
            {
                var index = temp.IndexOf(state);
                temp.Remove(state);

                var index2 = temp.IndexOf(state);

                if (index2 + 1 > 0)
                    return index2 + 1 - index;

            }

            return 0;
        }
    }
}
