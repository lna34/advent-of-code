namespace AdventOfCode
{
    public class BaseResolver
    {
        protected string[] Data { get; }
        public BaseResolver(int day)
        {
            Data = File.ReadAllLines(@$"C:\Users\Luc\source\repos\AdventOfCode\AdventOfCode\Day{day}\data.txt");
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
