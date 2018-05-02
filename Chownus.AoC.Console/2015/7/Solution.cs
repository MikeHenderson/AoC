using System;
using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2015._7
{
    public class Solution : IAoCSolution
    {
        public int Day => 7;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            return GetSignal(testData).Invoke().ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var list = testData.ToList();
            list.Add(GetSignal(testData).Invoke() + " -> b");
            return GetSignal(list).Invoke().ToString();
        }

        private static Func<ushort> GetSignal(IEnumerable<string> testData)
        {
            var values = new Dictionary<string, ushort>();
            var gates = new Dictionary<string, Func<ushort>>();

            foreach (var c in testData)
            {
                var command = c.GetUppercase();
                var parts = c.Split(' ');
                var target = parts.Last();

                // SET GATE
                if (command.Count == 0)
                {
                    if (ushort.TryParse(parts[0], out ushort x))
                    {
                        if (gates.ContainsKey(target)) gates[target] = () => x;
                        else gates.Add(target, () => x);

                        if (values.ContainsKey(target)) values[target] = x;
                        else values.Add(target, x);
                    }
                    else
                    {
                        gates.Add(target, () =>
                        {
                            if (values.ContainsKey(target)) return values[target];

                            var val = gates[parts[0]].Invoke();
                            values.Add(target, val);
                            return val;
                        });
                    }

                    continue;
                }

                switch (command[0].Value)
                {
                    case "NOT":
                        gates.Add(target, () => (ushort)~gates[parts[1]].Invoke());
                        break;
                    case "AND":
                        gates.Add(target, () =>
                        {
                            if (values.ContainsKey(target)) return values[target];

                            var val = (ushort)(ushort.TryParse(parts[0], out var v)
                                ? v & gates[parts[2]].Invoke()
                                : gates[parts[0]].Invoke() & gates[parts[2]].Invoke());
                            values.Add(target, val);

                            return val;
                        });
                        break;
                    case "OR":
                        gates.Add(target, () =>
                        {
                            if (values.ContainsKey(target)) return values[target];

                            var val = (ushort)(ushort.TryParse(parts[0], out var v)
                                ? v | gates[parts[2]].Invoke()
                                : gates[parts[0]].Invoke() | gates[parts[2]].Invoke());
                            values.Add(target, val);

                            return val;
                        });
                        break;
                    case "RSHIFT":
                        gates.Add(target, () =>
                        {
                            if (values.ContainsKey(target)) return values[target];

                            var val = (ushort)(gates[parts[0]].Invoke() >> int.Parse(parts[2]));
                            values.Add(target, val);

                            return val;
                        });
                        break;
                    case "LSHIFT":
                        gates.Add(target, () =>
                        {
                            if (values.ContainsKey(target)) return values[target];

                            var val = (ushort)(gates[parts[0]].Invoke() << int.Parse(parts[2]));
                            values.Add(target, val);

                            return val;
                        });
                        break;
                }
            }

            return gates["a"];
        }
    }
}