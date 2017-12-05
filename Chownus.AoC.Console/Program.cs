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
                .Where(type => typeof(IAoCSolution).IsAssignableFrom(type) && !type.IsInterface);

            foreach (var impl in solutionImplementations)
            {
                var solution = (IAoCSolution) Activator.CreateInstance(impl);
                var input = Utilities.ImportInputAsList(solution.Day);

                solution.Initialize(input);
                System.Console.WriteLine($"Day {solution.Day} - Part 1 Answer: {solution.RunPart1()}");

                solution.Initialize(input);
                System.Console.WriteLine($"Day {solution.Day} - Part 2 Answer: {solution.RunPart2()}");
            }

            System.Console.ReadKey();
        }
    }
}
