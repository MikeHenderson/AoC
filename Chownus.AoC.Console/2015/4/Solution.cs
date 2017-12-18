using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Chownus.AoC.Console._2015._4
{
    public class Solution : IAoCSolution
    {
        public int Day => 4;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.First();

            var counter = 0;
            bool hashFound = false;
            while (!hashFound)
            {
                if (GetHash($"{input}{counter}").StartsWith("00000"))
                    hashFound = true;
                else
                    counter++;

            }

            return counter.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.First();

            var counter = 0;
            bool hashFound = false;
            while (!hashFound)
            {
                if (GetHash($"{input}{counter}").StartsWith("000000"))
                    hashFound = true;
                else
                    counter++;

            }

            return counter.ToString();
        }

        private string GetHash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return string.Join(string.Empty, hash.Select(x => x.ToString("X2")));
            }
        }
    }
}
