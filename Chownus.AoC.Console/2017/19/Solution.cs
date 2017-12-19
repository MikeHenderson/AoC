using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2017._19
{
    public class Solution : IAoCSolution
    {
        public int Day => 19;
        public int Year => 2017;
        public string RunPart1(IEnumerable<string> testData)
        {
            var lines = testData.ToList();
            char[,] map = new char[lines.Count, lines[0].Length];

            // Build map
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }

            // Find starting point
            int r = 0;
            int c = 0;

            for (int i = 0; i < map.GetLength(1); i++)
            {
                if (map[0,i] == '|')
                    c = i;
            }

            var collectedLetters = new List<char>();
            var endFound = false;
            var endpointFound = false;
            char dir = 's';

            while (!endFound)
            {
                while (!endpointFound)
                {
                    if (IsLetter(map[r, c]))
                        collectedLetters.Add(map[r, c]);

                    if (dir == 's')
                    {
                        if (r == map.GetLength(0) || IsEmpty(map[r+1,c]))
                        {
                            endFound = true;
                            break;
                        }

                        r++;
                    }
                    else if (dir == 'n')
                    {
                        if (r == 0 || IsEmpty(map[r - 1, c]))
                        {
                            endFound = true;
                            break;
                        }
                        r--;
                    }
                    else if (dir == 'e')
                    {
                        if (c == map.GetLength(1) || IsEmpty(map[r, c+1]))
                        {
                            endFound = true;
                            break;
                        }
                        c++;
                    }
                    else if (dir == 'w' || IsEmpty(map[r, c-1]))
                    {
                        if (c == 0)
                        {
                            endFound = true;
                            break;
                        }
                        c--;
                    }

                    if (map[r, c] == '+') endpointFound = true;
                }

                if (endFound) break;

                // get new direction
                if (dir == 's' || dir == 'n')
                {
                    // look west
                    if (map[r, c - 1] > 0 && map[r, c - 1] != (char) 32)
                        dir = 'w';
                    else
                        dir = 'e';
                }
                else
                {
                    if (map[r - 1, c] > 0 && map[r - 1, c] != (char) 32)
                        dir = 'n';
                    else
                        dir = 's';
                }

                endpointFound = false;

            }
            

            return string.Join(string.Empty, collectedLetters);
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var lines = testData.ToList();
            char[,] map = new char[lines.Count, lines[0].Length];

            // Build map
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }

            // Find starting point
            int r = 0;
            int c = 0;

            for (int i = 0; i < map.GetLength(1); i++)
            {
                if (map[0, i] == '|')
                    c = i;
            }

            var steps = 0;
            var endFound = false;
            var endpointFound = false;
            char dir = 's';

            while (!endFound)
            {
                while (!endpointFound)
                {
                    steps++;
                    if (dir == 's')
                    {
                        if (r == map.GetLength(0) || IsEmpty(map[r + 1, c]))
                        {
                            endFound = true;
                            break;
                        }

                        r++;
                    }
                    else if (dir == 'n')
                    {
                        if (r == 0 || IsEmpty(map[r - 1, c]))
                        {
                            endFound = true;
                            break;
                        }
                        r--;
                    }
                    else if (dir == 'e')
                    {
                        if (c == map.GetLength(1) || IsEmpty(map[r, c + 1]))
                        {
                            endFound = true;
                            break;
                        }
                        c++;
                    }
                    else if (dir == 'w' || IsEmpty(map[r, c - 1]))
                    {
                        if (c == 0)
                        {
                            endFound = true;
                            break;
                        }
                        c--;
                    }

                    if (map[r, c] == '+') endpointFound = true;
                }

                if (endFound) break;

                // get new direction
                if (dir == 's' || dir == 'n')
                {
                    // look west
                    if (map[r, c - 1] > 0 && map[r, c - 1] != (char)32)
                        dir = 'w';
                    else
                        dir = 'e';
                }
                else
                {
                    if (map[r - 1, c] > 0 && map[r - 1, c] != (char)32)
                        dir = 'n';
                    else
                        dir = 's';
                }

                endpointFound = false;

            }


            return steps.ToString();
        }

        private bool IsLetter(char c)
        {
            return Regex.IsMatch(c.ToString(), "[A-Z]");
        }

        // bit of a hack
        private bool IsEmpty(char c)
        {
            return c == (char) 32;
        }
    }
}