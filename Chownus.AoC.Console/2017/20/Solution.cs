using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2017._20
{
    public class Solution : IAoCSolution
    {
        public int Day => 20;
        public int Year => 2017;

        private static readonly Func<string, IList<long>> getDigits = s => Regex.Matches(s, @"[+-]?\d+(\.\d+)?")
        .Cast<Match>()
        .Select(x => long.Parse(x.Value))
        .ToList();

        public string RunPart1(IEnumerable<string> testData)
        {
            var particles = testData.Select(line => getDigits(line))
                .Select((values, i) => new Particle
                {
                    Index = i,

                    XPos = values[0],
                    YPos = values[1],
                    ZPos = values[2],

                    XVel = values[3],
                    YVel = values[4],
                    ZVel = values[5],

                    XAcc = values[6],
                    YAcc = values[7],
                    ZAcc = values[8]
                })
                .ToList();

            for(int i = 0; i < 999999; i++)
                particles.ForEach(x => x.Tick());

            return particles.OrderBy(x => x.GetDistance()).First().Index.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            throw new NotImplementedException();
        }
    }

    public class Particle
    {
        public int Index;
        public long XPos;
        public long YPos;
        public long ZPos;

        public long XVel;
        public long YVel;
        public long ZVel;

        public long XAcc;
        public long YAcc;
        public long ZAcc;

        public long GetDistance()
        {
            return Math.Abs(XPos) + Math.Abs(YPos) + Math.Abs(ZPos);
        }

        public string GetPosition()
        {
            return $"{XPos},{YPos},{ZPos}";
        }

        public void Tick()
        {
            //Increase the X velocity by the X acceleration.
            XVel += XAcc;

            //Increase the Y velocity by the Y acceleration.
            YVel += YAcc;

            //Increase the Z velocity by the Z acceleration.
            ZVel += ZAcc;

            //Increase the X position by the X velocity.
            XPos += XVel;

            //Increase the Y position by the Y velocity.
            YPos += YVel;

            //Increase the Z position by the Z velocity.
            ZPos += ZVel;
        }
    }
}