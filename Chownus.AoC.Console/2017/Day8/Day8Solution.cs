using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console
{
    public class Day8Solution : IAoCSolution
    {
        public int Day => 8;
        private IEnumerable<string> _input;

        private static readonly IDictionary<string, Func<int, int, bool>> _operators = new Dictionary<string, Func<int, int, bool>>
        {
            { ">", (x, y) => x > y},
            { ">=", (x, y) => x >= y},
            { "<", (x, y) => x < y},
            { "<=", (x, y) => x <= y},
            { "!=", (x, y) => x != y},
            { "==", (x, y) => x == y},
        };

        private static readonly IDictionary<string, Func<int, int, int>> _modifiers = new Dictionary<string, Func<int, int, int>>
        {
            { "inc", (x, y) => x + y },
            { "dec", (x, y) => x - y }
        };


        public string RunPart1()
        {
            var registers = new Dictionary<string, int>();

            foreach (var instruction in _input)
                 ExecuteInstruction(instruction, registers);

            return registers.Max(x => x.Value).ToString();
        }

        public string RunPart2()
        {
            var registers = new Dictionary<string, int>();
            int maxValue = 0;

            foreach (var instruction in _input)
            {
                var currentMax = ExecuteInstruction(instruction, registers);

                if (currentMax > maxValue)
                    maxValue = currentMax;
            }

            return maxValue.ToString();
        }

        private int ExecuteInstruction(string instruction, IDictionary<string, int> registers)
        {
            var parts = instruction.Split(' ');

            var targetRegister = parts[0];
            var modifier = parts[1];
            var modifierValue = int.Parse(parts[2]);

            if (!registers.ContainsKey(targetRegister))
                registers.Add(targetRegister, 0);

            var checkRegister = parts[4];
            var operand = parts[5];
            var checkValue = int.Parse(parts[6]);

            if (!registers.ContainsKey(checkRegister))
                registers.Add(checkRegister, 0);

            bool conditionMet = _operators[operand](registers[checkRegister], checkValue);

            if (conditionMet)
                registers[targetRegister] = _modifiers[modifier](registers[targetRegister], modifierValue);

            return registers.Max(x => x.Value);
        }

        public void Initialize(IEnumerable<string> input)
        {
            _input = input;
        }
    }
}