using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._8
{
    public class Solution : IAoCSolution
    {
        public int Day => 8;

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


        public string RunPart1(IEnumerable<string> testData)
        {
            var registers = new Dictionary<string, int>();

            foreach (var instruction in testData)
                 ExecuteInstruction(instruction, registers);

            return registers.Max(x => x.Value).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var registers = new Dictionary<string, int>();
            return testData.Select(instruction => ExecuteInstruction(instruction, registers))
                .Max()
                .ToString();
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
    }
}