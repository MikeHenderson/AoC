using System;
using System.Collections.Generic;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2015._6
{
    public class Solution : IAoCSolution
    {
        public int Day => 6;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var lights = new bool[1000,1000];
            var turnOn = new Func<bool, bool>(x => true);
            var turnOff = new Func<bool, bool>(x => false);
            var toggle = new Func<bool, bool>(x => !x);

            foreach (var command in testData)
            {
                var digits = command.GetDigits();
                var x1 = int.Parse(digits[0].Value);
                var y1 = int.Parse(digits[1].Value);
                var x2 = int.Parse(digits[2].Value);
                var y2 = int.Parse(digits[3].Value);

                Func<bool, bool> action;

                if (command.StartsWith("toggle"))
                    action = toggle;
                else if (command.StartsWith("turn on"))
                    action = turnOn;
                else
                    action = turnOff;

                for (int y = y1; y <= y2; y++)
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        lights[x, y] = action(lights[x, y]);
                    }
                }
            }

            var count = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (lights[x, y]) count++;
                }
            }

            return count.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var lights = new int[1000, 1000];
            var turnOn = new Func<int, int>(x => x+1);
            var turnOff = new Func<int, int>(x => x > 0 ? x-1 : 0);
            var toggle = new Func<int, int>(x => x+2);

            foreach (var command in testData)
            {
                var digits = command.GetDigits();
                var x1 = int.Parse(digits[0].Value);
                var y1 = int.Parse(digits[1].Value);
                var x2 = int.Parse(digits[2].Value);
                var y2 = int.Parse(digits[3].Value);

                Func<int, int> action;

                if (command.StartsWith("toggle"))
                    action = toggle;
                else if (command.StartsWith("turn on"))
                    action = turnOn;
                else
                    action = turnOff;

                for (int y = y1; y <= y2; y++)
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        lights[x, y] = action(lights[x, y]);
                    }
                }
            }

            var count = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                   count += lights[x,y];
                }
            }

            return count.ToString();
        }
    }
}
