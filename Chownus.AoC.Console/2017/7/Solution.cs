using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._7
{
    public class Solution : IAoCSolution
    {
        public int Day => 7;

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.Select(x => new Console.Day7Solution.Node(x)).ToList();

            foreach (var node in input)
                node.GenerateChildNodes(input);

            // Traverse tree to get "top" node
            var head = input.First();

            while (head.Parent != null)
                head = head.Parent;

            return head.Name;
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.Select(x => new Console.Day7Solution.Node(x)).ToList();

            foreach (var node in input)
                node.GenerateChildNodes(input);

            var head = input.First();

            while (head.Parent != null)
                head = head.Parent;

            int weight = 0;

            while (!head.IsBalanced())
                (head, weight) = head.GetUnbalancedChild();

            var weightDiff = weight - head.CalculateWeight();
            return (head.Weight + weightDiff).ToString();
        }

        public void Initialize(IEnumerable<string> testData)
        {
            var input = testData.Select(x => new Console.Day7Solution.Node(x)).ToList();

            foreach (var node in input)
                node.GenerateChildNodes(input);
        }
    }
}