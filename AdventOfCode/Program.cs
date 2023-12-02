using AdventOfCode;
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

        var resolver = GetResolver(day);

        if (resolver != null)
        {
            Console.WriteLine("Solution du puzzle 1: " + resolver.ResolvePuzzle1());
            Console.WriteLine("Solution du puzzle 2: " + resolver.ResolvePuzzle2());
        }
    }
}

BaseResolver? GetResolver(int day)
{
    var resolverFullName = $"AdventOfCode.Day{day}.Resolver";
    var resolverType = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => typeof(BaseResolver).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && t.FullName == resolverFullName).First();
    var resolverInstance = (BaseResolver?)Activator.CreateInstance(resolverType);

    return resolverInstance;
}