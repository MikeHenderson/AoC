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
                bool isInfected = IsInfected(c, map);

                c.Turn(isInfected ? 1 : -1);

                UpdateMap(c, map, !isInfected, ref burstCounter);


                //The virus carrier moves forward one node in the direction it is facing.
                c.Move();

                countdown--;
            }

            return burstCounter.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            throw new NotImplementedException();
        }

        private bool IsInfected(Carrier c, IDictionary<(int,int), bool> map)
        {
            if (map.ContainsKey((c.X, c.Y)))
                return map[(c.X, c.Y)];

            return false;
        }

        private void UpdateMap(Carrier c, IDictionary<(int, int), bool> map, bool isInfected, ref int counter)
        {
            if (map.ContainsKey((c.X, c.Y)))
                map[(c.X, c.Y)] = isInfected;
            else 
                map.Add((c.X, c.Y), isInfected);

            if (isInfected) counter++;
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
    }
}