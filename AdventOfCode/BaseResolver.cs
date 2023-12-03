using System.Reflection;

namespace AdventOfCode
{
    public class BaseResolver
    {
        protected string[] Data { get; }
        public BaseResolver(int day)
        {
            string pathToData = AppDomain.CurrentDomain.BaseDirectory;
            Data = File.ReadAllLines($@"{pathToData}\Day{day}\data.txt");
        }

        public virtual object ResolvePuzzle1()
        {
            return 0;
        }

        public virtual object ResolvePuzzle2()
        {
            return 0;
        }
    }
}
