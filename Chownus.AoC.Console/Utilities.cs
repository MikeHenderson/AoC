using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chownus.AoC.Console
{
    public static class Utilities
    {
        private static readonly Func<int, int, string> FormatPath = (day, year) => $".\\{year}\\{day}\\input.txt";

        public static string ImportInput(int day, int year)
        {
            return File.ReadAllText(FormatPath(day, year));
        }

        public static IList<string> ImportInputAsList(int day, int year)
        {
            return File.ReadLines(FormatPath(day, year)).ToList();
        }

        public static string FlipHorizontal(this string grid)
        {
            string[] rows = grid.Split('/');
            string[] newRows = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                newRows[i] = string.Join("", rows[i].Reverse());
            }

            return string.Join<string>("/", newRows);
        }

        public static string FlipVertical(this string grid)
        {
            string[] rows = grid.Split('/');
            string[] newRows = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                newRows[rows.Length - i - 1] = rows[i];
            }

            return string.Join<string>("/", newRows);
        }

        public static string Rotate(this string grid)
        {
            string[] rows = grid.Split('/');
            char[,] newRows = new char[rows.Length, rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    newRows[rows.Length - j - 1, i] = rows[i][j];
                }
            }

            string[] sNewRows = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    sNewRows[i] += newRows[i, j];
                }
            }

            return string.Join("/", sNewRows);
        }

    }
}