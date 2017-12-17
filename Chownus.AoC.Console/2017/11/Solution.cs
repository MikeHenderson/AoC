using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console.Common.Models;

namespace Chownus.AoC.Console._2017._11
{
    public class Solution : IAoCSolution
    {
        public int Day => 11;
        public int Year => 2017;

        private readonly IDictionary<string, HexPoint> _actions = new Dictionary<string, HexPoint>
        {
            { "n",new HexPoint(0, 1, -1) },
            { "s", new HexPoint(0, -1, 1) },
            { "ne", new HexPoint(1, 0 , -1) },
            { "nw", new HexPoint(-1, 1, 0) },
            { "se", new HexPoint(1, -1, 0) },
            { "sw", new HexPoint(-1, 0, 1) }
        };

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.First().Split(',');

            // Start at home
            var current = new HexPoint(0, 0, 0);

            foreach (var direction in input)
            {
                var point = _actions[direction];
                current = current.AddPoint(point);
            }

            return current.CalculateDistanceToRoot().ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.First().Split(',');
            var current = new HexPoint(0, 0, 0);

            int max = 0;

            foreach (var direction in input)
            {
                var point = _actions[direction];
                current = current.AddPoint(point);

                // I can go the distance! I have found my way, if I can be-e strong! I know every mile would be worth my while
                // if I can go the distance I'll be right where I-I-I.... belooooooooong!
                var distance = current.CalculateDistanceToRoot();
                if (distance > max)
                    max = distance;
            }

            return max.ToString();
        }

    }
}