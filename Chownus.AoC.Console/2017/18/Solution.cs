using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console.Common;

namespace Chownus.AoC.Console._2017._18
{
    public class Solution : IAoCSolution
    {
        public int Day => 18;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            var commands = testData.ToList();
            var registers = new Dictionary<char, long>();
            long lastSoundPlayed = 0;
            bool received = false;
            int i = 0;

            while (!received)
            {
                var parts = commands[i].Split(' ');
                var x = parts[1][0];

                if (!registers.ContainsKey(x))
                    registers.Add(x, 0);

                switch (parts[0])
                {
                    case "snd":
                        lastSoundPlayed = registers[x];
                        break;

                    case "set":
                        registers[x] = GetValue(parts[2], registers);
                        break;

                    case "add":
                        registers[x] += GetValue(parts[2], registers);
                        break;

                    case "mul":
                        registers[x] *= GetValue(parts[2], registers);
                        break;

                    case "mod":
                        registers[x] %= GetValue(parts[2], registers);
                        break;

                    case "rcv":
                        if (registers[x] != 0)
                            received = true;
                        break;

                    case "jgz":
                        if (registers[x] > 0)
                        {
                            i += (int)GetValue(parts[2], registers);
                            continue;
                        }
                        break;
                }

                i++;
            }

            return lastSoundPlayed.ToString();
        }

        private long GetValue(string s, IDictionary<char, long> registers)
        {
            var isDigit = long.TryParse(s, out var temp);
            if (isDigit) return temp;

            return registers.ContainsKey(s[0]) ? registers[s[0]] : 0;
        }


        public string RunPart2(IEnumerable<string> testData)
        {
            var commands = testData.ToList();
            var a = new DuetProgram(new Dictionary<char, long> {{'p', 0}});
            var b = new DuetProgram(new Dictionary<char, long> {{'p', 1}});

            while (!a.Terminated && !b.Terminated)
            {
                a.RunNextCommand(commands, b);
                b.RunNextCommand(commands, a);
            }

            return b.SentCount.ToString();
        }
    }
}