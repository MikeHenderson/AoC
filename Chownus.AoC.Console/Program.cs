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
                .Reverse();

            foreach (var impl in solutionImplementations)
            {
                var solution = (IAoCSolution) Activator.CreateInstance(impl);

                if (solution.Year == 2015) continue;
                var input = Utilities.ImportInputAsList(solution.Day, solution.Year);

                System.Console.WriteLine($"Day {solution.Day}, {solution.Year} - Part 1 Answer: {solution.RunPart1(input)}");
                System.Console.WriteLine($"Day {solution.Day}, {solution.Year} - Part 2 Answer: {solution.RunPart2(input)}");
            }

            System.Console.ReadKey();
        }
    }
}
