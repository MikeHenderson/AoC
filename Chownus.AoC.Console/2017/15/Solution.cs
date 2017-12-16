using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chownus.AoC.Console._2017._15
{
    public class Solution : IAoCSolution
    {
        public int Day => 15;

        public string RunPart1(IEnumerable<string> testData)
        {
            var parts = testData.First().Split(',');
            var a = long.Parse(parts[0]);
            var b = long.Parse(parts[1]);

            var aFactor = 16807L;
            var bFactor = 48271L;
            var divider = 2147483647L;
            var counter = 0;

            for(long i = 0; i < 40000000; i++)
            {
                a = (a * aFactor) % divider;
                b = (b * bFactor) % divider;

                if(a%(255 | (255 << 8)) == b % (255 | (255 << 8)))
                    counter++;
            }

            return counter.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var parts = testData.First().Split(',');
            var a = long.Parse(parts[0]);
            var b = long.Parse(parts[1]);

            var aFactor = 16807L;
            var bFactor = 48271L;
            var divider = 2147483647L;
            var counter = 0;

            for (long i = 0; i < 40000000; i++)
            {
                do
                {
                    a = (a * aFactor) % divider;
                } while (a % 4 != 0);

                do
                {
                    b = (b * bFactor) % divider;
                } while (b % 8 != 0);

                if (a % (255 | (255 << 8)) == b % (255 | (255 << 8)))
                    counter++;
            }

            return counter.ToString();
        }
    }
}