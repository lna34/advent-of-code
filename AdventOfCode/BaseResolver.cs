using System.Reflection;

namespace AdventOfCode
{
    public abstract class BaseResolver
    {
        protected string[] Data { get; }
        public BaseResolver(int day)
        {
            string pathToData = AppDomain.CurrentDomain.BaseDirectory;
            Data = File.ReadAllLines($@"{pathToData}\Day{day}\data.txt");
        }

        public abstract object ResolvePuzzle1();
        public abstract object ResolvePuzzle2();
    }
}
