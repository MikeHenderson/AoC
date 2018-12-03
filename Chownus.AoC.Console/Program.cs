using System;
using System.Linq;
using System.Reflection;

namespace Chownus.AoC.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionImplementations = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IAoCSolution).IsAssignableFrom(type) && !type.IsInterface)
                .Select(x => (IAoCSolution)Activator.CreateInstance(x))
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Day);

            foreach (var solution in solutionImplementations)
            {
                var input = Utilities.ImportInputAsList(solution.Day, solution.Year);

                System.Console.WriteLine($"Day {solution.Day}, {solution.Year} - Part 1 Answer: {solution.RunPart1(input)}");
                System.Console.WriteLine($"Day {solution.Day}, {solution.Year} - Part 2 Answer: {solution.RunPart2(input)}");
            }

            System.Console.ReadKey();
        }
    }
}
