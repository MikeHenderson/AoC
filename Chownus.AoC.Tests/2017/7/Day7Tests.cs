﻿using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._7;
using Xunit;

namespace Chownus.AoC.Tests._2017._7
{
    public class Day7Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day7Tests()
        {
            _input = new List<string>
            {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };

            _testObject = new Solution();
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);
            Assert.Equal("tknk", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);
            Assert.Equal("60", solution);
        }
    }
}