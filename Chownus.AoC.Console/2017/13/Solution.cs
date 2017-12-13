using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._13
{
    public class PacketScanner
    {
        public int CurrentDepth = 0;
        public int Depth;
        public Direction Direction;

        public void Advance()
        {
            if (Direction == Direction.Down)
            {
                if (CurrentDepth == Depth - 1)
                {
                    CurrentDepth--;
                    Direction = Direction.Up;
                }
                else
                {
                    CurrentDepth++;
                }
            }
            else
            {
                if (CurrentDepth == 0)
                {
                    CurrentDepth++;
                    Direction = Direction.Down;
                }
                else
                {
                    CurrentDepth--;
                }
            }
        }

    }

    public enum Direction
    {
        Down,
        Up
    }

    public class Solution : IAoCSolution
    {
        public int Day => 13;

        public string RunPart1(IEnumerable<string> testData)
        {
            var grid = new Dictionary<int, PacketScanner>();

            var counter = 0;
            foreach (var line in testData)
            {
                var parts = line.Split(':').Select(x => int.Parse(x.Trim())).ToList();

                if (parts[0] > counter)
                {
                    while (counter < parts[0])
                    {
                        grid.Add(counter, null);
                        counter++;
                    }

                    grid.Add(counter, new PacketScanner {Depth = parts[1]});
                }
                else
                {
                    grid.Add(counter, new PacketScanner{ Depth = parts[1] });
                }

                counter++;
            }

            int severity = 0;

            for (int i = 0; i <= grid.Keys.Last(); i++)
            {
                if (grid[i] == null)
                {
                    AdvanceScanners(grid);
                    continue;
                }

                if (grid[i].CurrentDepth == 0)
                    severity += i * grid[i].Depth;

                AdvanceScanners(grid);
            }

            return severity.ToString();

        }

        public void AdvanceScanners(IDictionary<int, PacketScanner> scanners)
        {
            foreach (var scanner in scanners.Select(x => x.Value))
            {
                if (scanner == null) continue;

                scanner.Advance();
            }
        }


        public string RunPart2(IEnumerable<string> testData)
        {
            return null;
        }
    }
}