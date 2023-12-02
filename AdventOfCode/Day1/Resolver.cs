namespace AdventOfCode.Day1
{
    public class Resolver : BaseResolver
    {
        public Resolver() : base(1) { }

        public override int ResolvePuzzle1()
        {
            return Data
                .Select(line => new string(line.Where(c => char.IsDigit(c)).ToArray()))
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => Convert.ToInt32($"{line.First()}{line.Last()}"))
                .Sum();
        }

        public override int ResolvePuzzle2()
        {
            return Data
                .Select(line => new string(line.Where(c => char.IsDigit(c)).ToArray()))
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => Convert.ToInt32($"{line.First()}{line.Last()}"))
                .Sum();
        }
    }
}
