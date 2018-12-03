using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chownus.AoC.Console._2018._3
{
    public class Solution : IAoCSolution
    {
        public int Day => 3;
        public int Year => 2018;

        public string RunPart1(IEnumerable<string> testData)
        {
            var grid = new char[1000, 1000];
            var total = 0;

            foreach (var line in testData)
            {
                var parts = line.Split(' ');

                var coords = parts[2].Split(',');
                var startX = int.Parse(coords[0]);
                var startY = int.Parse(coords[1].Remove(coords[1].Length - 1));

                var dim = parts[3].Split('x');
                var w = int.Parse(dim[0]);
                var h = int.Parse(dim[1]);

                for (int i = startX; i < startX + w; i++)
                {
                    for (int j = startY; j < startY + h; j++)
                    {
                        if (grid[i, j] == '\0') grid[i, j] = 'O';
                        else if (grid[i, j] == 'O')
                        {
                            grid[i, j] = 'X';
                            total++;
                        }
                    }
                }
            }

            return total.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var grid = testData.Select((x, i) =>
            {
                var parts = x.Split(' ');

                var coords = parts[2].Split(',');
                var startX = int.Parse(coords[0]);
                var startY = int.Parse(coords[1].Remove(coords[1].Length - 1));

                var dim = parts[3].Split('x');
                var w = int.Parse(dim[0]);
                var h = int.Parse(dim[1]);

                return new
                {
                    Id = i + 1,
                    Area = new Rectangle
                    {
                        Location = new Point(startX, startY),
                        Size = new Size(w,h)
                    }
                };
            }).ToList();

            bool IsWithinRangeOf(Rectangle f, Rectangle s) => Rectangle.Intersect(f, s) != Rectangle.Empty;

            foreach (var p in grid)
            {
                if (grid.Where(x => x.Id != p.Id).All(x => !IsWithinRangeOf(p.Area, x.Area)))
                    return p.Id.ToString();
            }

            return string.Empty;
        }
    }
}