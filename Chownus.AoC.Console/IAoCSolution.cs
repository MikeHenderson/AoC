using System.Collections.Generic;

namespace Chownus.AoC.Console
{
    public interface IAoCSolution
    {
        int Day { get; }
        string RunPart1();
        string RunPart2();
        void Initialize(IEnumerable<string> input);
    }
}
