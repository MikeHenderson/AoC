using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console
{
    public class Day7Solution : IAoCSolution
    {
        public class Node
        {
            public string Name;
            public int Weight;
            public IList<string> Names;
            public IList<Node> Children;
            public Node Parent;

            public Node(string s)
            {
                var parts = s.Split(' ');

                Name = parts[0];
                Weight = int.Parse(Regex.Replace(parts[1], "[()]", string.Empty));
                Names = parts.Where((x, i) => i >= 3).Select(x => x.Replace(",", string.Empty)).ToList();
            }

            public void GenerateChildNodes(IList<Node> input)
            {
                Children = Names.Select(x => input.First(y => y.Name.Equals(x))).ToList();

                foreach (var child in Children)
                    child.Parent = this;
            }

            public bool IsBalanced()
            {
                var groups = Children.GroupBy(x => x.CalculateWeight());
                return groups.Count() == 1;
            }

            public int CalculateWeight()
            {
                var childSum = Children.Sum(x => x.CalculateWeight());
                return childSum + Weight;
            }

            public (Node node, int targetWeight) GetUnbalancedChild()
            {
                var g = Children.GroupBy(x => x.CalculateWeight());
                var unbalancedChild = g.First(x => x.Count() == 1).First();
                var targetWeight = g.First(x => x.Count() > 1).Key;

                return (unbalancedChild, targetWeight);
            }
        }

        public int Day => 7;
        private IList<Node> _input;


        public string RunPart1()
        {
            // Traverse tree to get "top" node
            var head = _input.First();

            while (head.Parent != null)
                head = head.Parent;

            return head.Name;
        }

        public string RunPart2()
        {
            var head = _input.First();

            while (head.Parent != null)
                head = head.Parent;

            int weight = 0;

            while (!head.IsBalanced())
                (head, weight) = head.GetUnbalancedChild();

            var weightDiff = weight - head.CalculateWeight();
            return (head.Weight + weightDiff).ToString();
        }

        public void Initialize(IEnumerable<string> input)
        {
            _input = input.Select(x => new Node(x)).ToList();

            foreach (var node in _input)
                node.GenerateChildNodes(_input);
        }
    }
}