﻿using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode
{
    public static class ResolverTools
    {
        public static void Execute()
        {
            while (true)
            {
                Console.Write("Veuillez renseigner le jour du puzzle à résoudre: ");
                var inputDay = Console.ReadLine();

                if (!int.TryParse(inputDay, out int day))
                {
                    Console.WriteLine("Veuillez renseigner un nombre ! ");
                    continue;
                }

                var resolver = GetResolver(day);

                if (resolver == null)
                {
                    Console.WriteLine("Aucun puzzle trouvé pour le jour renseigné");
                    continue;
                }

                ExecuteWithPerformancesDisplay(() => resolver.ResolvePuzzle1(), 1);
                ExecuteWithPerformancesDisplay(() => resolver.ResolvePuzzle2(), 2);
            }
        }

        private static BaseResolver? GetResolver(int day)
        {
            var resolverFullName = $"AdventOfCode.Day{day}.Resolver";
            var resolverType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(BaseResolver).IsAssignableFrom(t) && t.IsClass && t.FullName == resolverFullName).FirstOrDefault();

            if (resolverType == null)
            {
                return null;
            }

            var resolverInstance = (BaseResolver?)Activator.CreateInstance(resolverType);

            return resolverInstance;
        }
        private static void ExecuteWithPerformancesDisplay(Func<object> method, int puzzleNumber)
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();
            var result = method();
            stopWatch.Stop();
            Console.WriteLine($"Solution du puzzle {puzzleNumber}: {result} en {stopWatch.Elapsed}");
        }
    }
}
