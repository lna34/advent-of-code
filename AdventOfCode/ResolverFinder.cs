using System.Reflection;

namespace AdventOfCode
{
    public static class ResolverFinder
    {
        public static BaseResolver? GetResolver(int day)
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
    }
}
