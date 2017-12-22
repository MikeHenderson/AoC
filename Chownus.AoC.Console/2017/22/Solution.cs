using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._22
{
    public class Solution : IAoCSolution
    {
        public int Day => 22;
        public int Year => 2017;
        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.ToList();
            var map = new Dictionary<(int, int), bool>();

            var midX = input.Count / 2;
            var midY = input.First().Length / 2;

            var j = 0;

            foreach (var line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    bool isInfected = line[i] == '#';

                    map.Add((i-midX, j-midY), isInfected);
                }

                j++;
            }

            var c = new Carrier();

            int countdown = 10000;
            int burstCounter = 0;

            while (countdown > 0)
            {
                if(!map.ContainsKey((c.X,c.Y))) map.Add((c.X,c.Y), false);
                bool isInfected = map[(c.X, c.Y)];

                c.Turn(isInfected ? 1 : -1);

                if (isInfected) burstCounter++;
                map[(c.X, c.Y)] = !isInfected;

                //The virus carrier moves forward one node in the direction it is facing.
                c.Move();

                countdown--;
            }

            return burstCounter.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.ToList();
            var map = new Dictionary<(int, int), char>();
            var midX = input.Count / 2;
            var midY = input.First().Length / 2;

            var j = 0;

            foreach (var line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    map.Add((i - midX, j - midY), line[i] == '#' ? 'I' : 'C');
                }

                j++;
            }

            var c = new Carrier();

            int countdown = 10000000;
            int burstCounter = 0;

            while (countdown > 0)
            {
                if (!map.ContainsKey((c.X, c.Y))) map.Add((c.X, c.Y), 'C');
                var current = map[(c.X, c.Y)];

                if (current == 'C')
                {
                    c.Turn(-1);
                    map[(c.X, c.Y)] = 'W';
                }
                else if (current == 'I')
                {
                    c.Turn(1);
                    map[(c.X, c.Y)] = 'F';
                }
                else if (current == 'F')
                {
                    c.Reverse();
                    map[(c.X, c.Y)] = 'C';
                }
                else
                {
                    burstCounter++;
                    map[(c.X, c.Y)] = 'I';
                }

                c.Move();

                countdown--;
            }

            return burstCounter.ToString();
        }
    }

    public class Carrier
    {
        public Carrier()
        {
            Facing = 'n';
        }

        public int X;
        public int Y;
        public char Facing;

        private IList<char> dir = new List<char> { 'n', 'e', 's', 'w' };


        public void Move()
        {
            switch (Facing)
            {
                case 'n':
                    Y--;
                    break;
                case 'e':
                    X++;
                    break;
                case 's':
                    Y++;
                    break;
                case 'w':
                    X--;
                    break;
            }
        }

        public void Turn(int rotation)
        {
            switch (Facing)
            {
                case 'n' when rotation == -1:
                    Facing = 'w';
                    return;
                case 'w' when rotation == 1:
                    Facing = 'n';
                    return;
                default:
                    Facing = dir[dir.IndexOf(Facing) + rotation];
                    return;
            }
        }

        public void Reverse()
        {
            if (Facing == 'n')
                Facing = 's';
            else if (Facing == 's')
                Facing = 'n';
            else if (Facing == 'e')
                Facing = 'w';
            else
                Facing = 'e';
        }
    }
}