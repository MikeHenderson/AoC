using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Chownus.AoC.Console._2015._12
{
    public class Solution : IAoCSolution
    {
        public int Day => 12;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            return Regex.Matches(testData.First(), @"\-?\d+")
                .Cast<Match>()
                .Sum(x => int.Parse(x.Value))
                .ToString();
        }

        // Took a little help from the Advent of Code reddit solution board because I saw this
        // solution and was interested in seeing LINQ and polymorphism work in tandem
        public string RunPart2(IEnumerable<string> testData)
        {
            var obj = JsonConvert.DeserializeObject(testData.First()) as JObject;

            return CalculateSum(obj).ToString();
        }

        private static int CalculateSum(JObject obj)
        {
            // skip any object that has a property in it with a value of "red"
            if (obj.Properties().Select(x => x.Value).OfType<JValue>().Any(x => x.Value.Equals("red")))
                return 0;

            return obj.Properties().Sum((dynamic x) => CalculateSum(x.Value));
        }

        // provide overloads for array or values to get the potential number values
        private static int CalculateSum(JArray arr)
        {
            return arr.Sum((dynamic x) => CalculateSum(x));
        }

        private static int CalculateSum(JValue value)
        {
            return value.Type == JTokenType.Integer ? int.Parse(value.Value.ToString()) : 0;
        }
    }
}