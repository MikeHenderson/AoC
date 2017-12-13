using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._13
{
    public class Solution : IAoCSolution
    {
        public int Day => 13;

        public string RunPart1(IEnumerable<string> testData)
        {
            var grid = BuildGrid(testData);

            return CalculateSeverity(grid, 0).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var grid = BuildGrid(testData);
            var minDelay = 0;

            while (CalculateSeverity(grid, minDelay, true) > 0)
            {
                minDelay++;
            }

            return minDelay.ToString();
        }

        private int CalculateSeverity(IDictionary<int, PacketScanner> grid, int delay, bool breakIfCaught = false)
        {
            int severity = 0;

            for (int j = 0; j <= grid.Keys.Last(); j++)
            {
                if (grid[j] == null || !grid[j].WillHit(j + delay))
                    continue;

                // Short circuit for time's sake
                if (breakIfCaught)
                {
                    severity = 1;
                    break;
                }

                severity += j * grid[j].Depth;
            }

            return severity;
        }

        private IDictionary<int, PacketScanner> BuildGrid(IEnumerable<string> input)
        {
            var grid = new Dictionary<int, PacketScanner>();

            var counter = 0;
            foreach (var line in input)
            {
                var parts = line.Split(':').Select(x => int.Parse(x.Trim())).ToList();

                if (parts[0] > counter)
                {
                    while (counter < parts[0])
                    {
                        grid.Add(counter, null);
                        counter++;
                    }

                    grid.Add(counter, new PacketScanner { Depth = parts[1] });
                }
                else
                {
                    grid.Add(counter, new PacketScanner { Depth = parts[1] });
                }

                counter++;
            }

            return grid;
        }
    }
}