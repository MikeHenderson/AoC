using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console.Common
{
    public class DuetProgram
    {
        public Queue<long> Queue = new Queue<long>();
        public bool Terminated;
        public bool Waiting;
        public int SentCount;
        public readonly IDictionary<string, long> CommandsCount;
        public readonly IDictionary<char, long> Registers;

        private int _index;

        public DuetProgram()
        {
            CommandsCount = new Dictionary<string, long>();
            Registers = new Dictionary<char, long>();
        }

        public DuetProgram(IDictionary<char, long> registers) 
        {
            CommandsCount = new Dictionary<string, long>();
            Registers = registers;
        }

        public void RunNextCommand(IList<string> commands)
        {
            if (_index >= commands.Count) Terminated = true;

            if (Terminated) return;

            var parts = commands[_index].Split(' ');

            if(!CommandsCount.ContainsKey(parts[0])) CommandsCount.Add(parts[0], 0);
            CommandsCount[parts[0]]++;

            if (int.TryParse(parts[1], out var jgz) && (parts[0] == "jgz" || parts[0] == "jnz"))
            {
                if (jgz > 0)
                    _index += (int)GetValue(parts[2]);

                return;
            }

            var x = parts[1][0];

            if (!Registers.ContainsKey(x))
                Registers.Add(x, 0);

            switch (parts[0])
            {
                case "snd":
                    SentCount++;
                    break;

                case "set":
                    Registers[x] = GetValue(parts[2]);
                    break;

                case "add":
                    Registers[x] += GetValue(parts[2]);
                    break;

                case "sub":
                    Registers[x] -= GetValue(parts[2]);
                    break;

                case "mul":
                    Registers[x] *= GetValue(parts[2]);
                    break;

                case "mod":
                    Registers[x] %= GetValue(parts[2]);
                    break;

                case "rcv":
                    if (!Queue.Any())
                    {
                        Waiting = true;
                        return;
                    }

                    Waiting = false;
                    Registers[x] = Queue.Dequeue();
                    break;

                case "jgz":
                    if (Registers[x] > 0)
                    {
                        _index += (int)GetValue(parts[2]);
                        return;
                    }
                    break;

                case "jnz":
                    if (Registers[x] != 0)
                    {
                        _index += (int)GetValue(parts[2]);
                        return;
                    }
                    break;
            }

            _index++;
        }

        public void RunNextCommand(IList<string> commands, DuetProgram other)
        {
            if (Terminated || _index >= commands.Count) return;

            if (Waiting && other.Waiting)
            {
                Terminated = true;
                return;
            }

            var parts = commands[_index].Split(' ');

            if (!CommandsCount.ContainsKey(parts[0])) CommandsCount.Add(parts[0], 0);
            CommandsCount[parts[0]]++;

            if (int.TryParse(parts[1], out var snd) && parts[0] == "snd")
            {
                other.Queue.Enqueue(snd);
                SentCount++;
                return;
            }

            if (int.TryParse(parts[1], out var jgz) && parts[0] == "jgz")
            {
                if (jgz > 0)
                    _index += (int)GetValue(parts[2]);

                return;
            }

            var x = parts[1][0];

            if (!Registers.ContainsKey(x))
                Registers.Add(x, 0);

            switch (parts[0])
            {
                case "snd":
                    other.Queue.Enqueue(GetValue(parts[1]));
                    SentCount++;
                    break;

                case "set":
                    Registers[x] = GetValue(parts[2]);
                    break;

                case "add":
                    Registers[x] += GetValue(parts[2]);
                    break;

                case "mul":
                    Registers[x] *= GetValue(parts[2]);
                    break;

                case "mod":
                    Registers[x] %= GetValue(parts[2]);
                    break;

                case "rcv":
                    if (!Queue.Any())
                    {
                        Waiting = true;
                        return;
                    }

                    Waiting = false;
                    Registers[x] = Queue.Dequeue();
                    break;

                case "jgz":
                    if (Registers[x] > 0)
                    {
                        _index += (int)GetValue(parts[2]);
                        return;
                    }
                    break;
            }

            _index++;
        }

        private long GetValue(string s)
        {
            var isDigit = long.TryParse(s, out var temp);
            if (isDigit) return temp;

            return Registers.ContainsKey(s[0]) ? Registers[s[0]] : 0;
        }

    }
}
