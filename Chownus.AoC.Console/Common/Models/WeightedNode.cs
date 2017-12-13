using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console.Common.Models
{
    public class WeightedNode
    {
        public string Name;
        public int Weight;
        public IList<string> Names;
        public IList<WeightedNode> Children;
        public WeightedNode Parent;

        public WeightedNode(string s)
        {
            var parts = s.Split(' ');

            Name = parts[0];
            Weight = int.Parse(Regex.Replace(parts[1], "[()]", string.Empty));
            Names = parts.Where((x, i) => i >= 3).Select(x => x.Replace(",", string.Empty)).ToList();
        }

        public void GenerateChildNodes(IList<WeightedNode> input)
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

        public (WeightedNode node, int targetWeight) GetUnbalancedChild()
        {
            var g = Children.GroupBy(x => x.CalculateWeight());
            var unbalancedChild = g.First(x => x.Count() == 1).First();
            var targetWeight = g.First(x => x.Count() > 1).Key;

            return (unbalancedChild, targetWeight);
        }
    }
}