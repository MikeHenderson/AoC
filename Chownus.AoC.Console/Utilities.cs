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
            return File.ReadAllText(FormatPath(day));
        }

        public static IList<string> ImportInputAsList(int day, int year)
        {
            return File.ReadLines(FormatPath(day)).ToList();
        }

    }
}