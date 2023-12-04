﻿using AdventOfCode;
using System.Diagnostics;
using System.Reflection;

Execute();

void Execute()
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

        var resolver = ResolverFinder.GetResolver(day);

        if (resolver == null)
        {
            Console.WriteLine("Aucun puzzle trouvé pour le jour renseigné");
            continue;
        }

        ExecuteWithPerformancesDisplay(() => resolver.ResolvePuzzle1(), 1);
        ExecuteWithPerformancesDisplay(() => resolver.ResolvePuzzle2(), 2);
    }
}

void ExecuteWithPerformancesDisplay(Func<object> method, int puzzleNumber)
{
    Stopwatch stopWatch = new();
    stopWatch.Start();
    var result = method();
    stopWatch.Stop();
    Console.WriteLine($"Solution du puzzle {puzzleNumber}: {result} en {stopWatch.Elapsed}");
}