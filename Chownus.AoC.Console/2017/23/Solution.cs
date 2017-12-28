using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console.Common;

namespace Chownus.AoC.Console._2017._23
{
    public class Solution : IAoCSolution
    {
        public int Day => 23;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            var commands = testData.ToList();
            var program = new DuetProgram();

            while(!program.Terminated)
                program.RunNextCommand(commands);

            return program.CommandsCount["mul"].ToString();
        }


        public string RunPart2(IEnumerable<string> testData)
        {
            long a = 1;
            long b,c,d,e,f,g,h = 0;

            b = 93;
            c = b;
            b *= 100;
            b -= -100000;
            c = b;
            c -= -17000;

            do
            {
                f = 1;
                d = 2;
                e = 2;

                for (d = 2; d < b; d++)
                {
                    if (b % d != 0) continue;
                    f = 0;

                    break;
                }

                if (f == 0)
                    h++;

                g = b - c;
                b += 17;
            }
            while (g != 0);

            return h.ToString();
        }
    }
}