using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console
{
    public class Day11Solution : IAoCSolution
    {
        private IEnumerable<string> _input;

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


        public string RunPart1()
        {
            // Start at home
            var current = new Point(0, 0, 0);

            foreach (var direction in _input)
            {
                var point = actions[direction];
                current = AddPoint(current, point);
            }

            return CalculateDistance(current).ToString();
        }

        public string RunPart2()
        {
            return string.Empty;
        }

        public void Initialize(IEnumerable<string> input)
        {
            _input = input.First().Split(',');
        }

        private Point AddPoint(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        private int CalculateDistance(Point p)
        {
            return (Math.Abs(p.X) + Math.Abs(p.Y) + Math.Abs(p.Z)) / 2;
        }


       
    }

    public class Point
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X;
        public int Y;
        public int Z;

        public bool IsHome()
        {
            return X == 0 && Y == 0 && Z == 0;
        }
    }
}