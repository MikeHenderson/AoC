using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2018._4
{
    public class Solution : IAoCSolution
    {
        public int Day => 4;
        public int Year => 2018;

        public class Guard
        {
            public int Id;
            public IDictionary<int, int> SleepLog { get; set; } = new Dictionary<int, int>();
        }

        public string RunPart1(IEnumerable<string> testData)
        {
            var sleepTimes = GenerateSleepTable(testData);

            var mostSlept = sleepTimes.Values.Aggregate((x, y) => x.SleepLog.Sum(xx => xx.Value) > y.SleepLog.Sum(xx => xx.Value) ? x : y);
            var minuteMostSlept = mostSlept.SleepLog.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return (mostSlept.Id * minuteMostSlept).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var sleepTimes = GenerateSleepTable(testData);

            var mostSlept = sleepTimes.Values.Where(x => x.SleepLog.Count > 0).Aggregate((x, y) => x.SleepLog.Max(xx => xx.Value) > y.SleepLog.Max(xx => xx.Value) ? x : y);
            var minuteMostSlept = mostSlept.SleepLog.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return (mostSlept.Id * minuteMostSlept).ToString();
        }

        private static Dictionary<int, Guard> GenerateSleepTable(IEnumerable<string> data)
        {
            var journal = data.Select(x =>
                {
                    var parts = x.Split('[', ']');

                    return new
                    {
                        Date = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Command = parts[2].Trim(),
                        Id = parts[2].GetDigits().Count > 0
                            ? int.Parse(Regex.Replace(parts[2], @"[^\d]", string.Empty))
                            : -1
                    };
                })
                .OrderBy(x => x.Date)
                .ToList();

            var sleepTimes = new Dictionary<int, Guard>();
            var currentId = 0;
            var sleptAt = 0;

            foreach (var entry in journal)
            {
                if (entry.Id > 0)
                {
                    if (!sleepTimes.ContainsKey(entry.Id))
                        sleepTimes.Add(entry.Id, new Guard {Id = entry.Id});

                    currentId = entry.Id;
                }
                else if (entry.Command.StartsWith("f"))
                {
                    sleptAt = entry.Date.Minute;
                }
                else if (entry.Command.StartsWith("w"))
                {
                    for (int i = sleptAt; i < entry.Date.Minute; i++)
                    {
                        if (!sleepTimes[currentId].SleepLog.ContainsKey(i))
                            sleepTimes[currentId].SleepLog[i] = 1;
                        else
                            sleepTimes[currentId].SleepLog[i]++;
                    }
                }
            }

            return sleepTimes;
        }
    }
}