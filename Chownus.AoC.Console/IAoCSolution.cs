﻿using System.Collections.Generic;

namespace Chownus.AoC.Console
{
    public interface IAoCSolution
    {
        int Day { get; }
        int Year { get; }
        string RunPart1(IEnumerable<string> testData);
        string RunPart2(IEnumerable<string> testData);
    }
}
