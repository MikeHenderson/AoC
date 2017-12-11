﻿using System;
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
            var current = new Point(0, 0, 0);
            var path = new List<Point> { current };

            int max = 0;

            foreach (var direction in _input)
            {
                var point = actions[direction];
                current = AddPoint(current, point);

                // I can go the distance! I have found my way, if I can be-e strong! I know every mile would be worth my while
                // if I can go the distance I'll be right where I-I-I.... belooooooooong!
                var distance = CalculateDistance(current);
                if (distance > max)
                    max = distance;
            }

            return max.ToString();
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
    }
}