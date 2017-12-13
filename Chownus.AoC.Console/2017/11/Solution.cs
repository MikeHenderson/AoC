using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._11
{
    public class Solution : IAoCSolution
    {
        public int Day => 11;

        private readonly IDictionary<string, Point> actions = new Dictionary<string, Point>
        {
            { "n",new Point(0, 1, -1) },
            { "s", new Point(0, -1, 1) },
            { "ne", new Point(1, 0 , -1) },
            { "nw", new Point(-1, 1, 0) },
            { "se", new Point(1, -1, 0) },
            { "sw", new Point(-1, 0, 1) }
        };

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.First().Split(',');

            // Start at home
            var current = new Point(0, 0, 0);

            foreach (var direction in input)
            {
                var point = actions[direction];
                current = current.AddPoint(point);
            }

            return current.CalculateDistance().ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.First().Split(',');
            var current = new Point(0, 0, 0);

            int max = 0;

            foreach (var direction in input)
            {
                var point = actions[direction];
                current = current.AddPoint(point);

                // I can go the distance! I have found my way, if I can be-e strong! I know every mile would be worth my while
                // if I can go the distance I'll be right where I-I-I.... belooooooooong!
                var distance = current.CalculateDistance();
                if (distance > max)
                    max = distance;
            }

            return max.ToString();
        }

    }
}