using System.Text.RegularExpressions;

namespace Chownus.AoC.Console.Common.Helpers
{
    public static class RegexHelper
    {
        public static MatchCollection GetDigits(this string s)
        {
            return Regex.Matches(s, "\\d+");
        }

        public static MatchCollection GetUppercase(this string s)
        {
            return Regex.Matches(s, "[A-Z]+");
        }
    }
}
