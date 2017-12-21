using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Chownus.AoC.Console._2017._21
{
    // HOLY 2D MATRICES BATMAN!
    // THIS SOLUTION IS T3H BANTHA POODOO!
    public class Solution : IAoCSolution
    {
        public int Day => 21;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            return RunProggie(testData, 5).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            return RunProggie(testData, 18).ToString();
        }

        private int RunProggie(IEnumerable<string> testData, int n)
        {
            var split = new[] { " => " };
            var book = new Dictionary<string, string>();

            char[,] pixels = {
                {'.', '#', '.'},
                {'.', '.', '#'},
                {'#', '#', '#'}
            };

            foreach (var rule in testData.ToDictionary(x => x.Split(split, StringSplitOptions.None)[0],
                x => x.Split(split, StringSplitOptions.None)[1]))
            {
                var key = rule.Key;

                AddNewRule(key, rule.Value, book);
                AddNewRule(key.FlipHorizontal(), rule.Value, book);
                AddNewRule(key.FlipVertical(), rule.Value, book);

                // Rotations!
                for (int i = 0; i < 3; i++)
                {
                    var rotated = key.Rotate();
                    AddNewRule(rotated, rule.Value, book);
                    AddNewRule(rotated.FlipHorizontal(), rule.Value, book);
                    AddNewRule(rotated.FlipVertical(), rule.Value, book);

                    key = rotated;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (pixels.GetLength(0) % 2 == 0)
                    pixels = Enhance(pixels, 2, book);
                else
                    pixels = Enhance(pixels, 3, book);
            }

            return CountOn(pixels);
        }

        private char[,] Enhance(char[,] pic, int n, IDictionary<string, string> book)
        {
            var newSize = (pic.GetLength(0) / n) + pic.GetLength(0);
            var newM = new char[newSize, newSize];
            int x = 0;
            int y = 0;
            int lastX = 0;

            for (int i = 0; i < pic.GetLength(0); i += n)
            {
                var pass = 0;

                for (int j = 0; j < pic.GetLength(1); j += n)
                {
                    var sub = GetSubmatrix(pic, i, j, n);
                    string key = Flatten(sub);

                    var processed = Process(book[key], n);
                    y = pass * (n+1);
                    x = lastX;

                    for (int ii = 0; ii < processed.GetLength(0); ii++)
                    {
                        for (int jj = 0; jj < processed.GetLength(1); jj++)
                        {
                            newM[x, y] = processed[ii, jj];
                            y++;
                        }

                        y = pass * (n + 1);
                        x++;
                    }

                    pass++;
                }

                lastX = x;
            }

            return newM;
        }

        private void AddNewRule(string key, string value, IDictionary<string, string> book)
        {
            if(!book.ContainsKey(key))
                book.Add(key, value);
        }

        private char[,] GetSubmatrix(char[,] m, int i, int j, int n)
        {
            var sub = new char[n, n];
           
            for (var ii = 0; ii < n; ii++)
            {
                for (var jj = 0; jj < n; jj++)
                {
                    sub[ii, jj] = m[ii + i, jj + j];
                }
            }

            return sub;
        }

        private string Flatten(char[,] m)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    sb.Append(m[i, j]);
                }

                if(i < m.GetLength(0) - 1)
                    sb.Append('/');
            }

            return sb.ToString();
        }

        private char[,] Process(string p, int n)
        {
            var m = new char[n + 1, n + 1];
            p = p.Replace("/", string.Empty);

            var counter = 0;
            for (int r = 0; r < n + 1; r++)
            {
                for (int c = 0; c < n + 1; c++)
                {
                    m[r, c] = p[counter];
                    counter++;
                }
            }

            return m;
        }

        private int CountOn(char[,] m)
        {
            int counter = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == '#') counter++;
                }
            }

            return counter;
        }
    }
}