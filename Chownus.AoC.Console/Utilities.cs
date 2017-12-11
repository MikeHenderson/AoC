using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chownus.AoC.Console
{
    public static class Utilities
    {
        private static readonly Func<int, string> FormatPath = day => $".\\2017\\{day}\\input.txt";

        public static string ImportInput(int day)
        {
            return File.ReadAllText(FormatPath(day));
        }

        public static IList<string> ImportInputAsList(int day)
        {
            return File.ReadLines(FormatPath(day)).ToList();
        }

    }
}