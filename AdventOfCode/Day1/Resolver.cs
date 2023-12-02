namespace AdventOfCode.Day1
{
    public class Resolver : BaseResolver
    {
        public Resolver() : base(1) { }

        public override object ResolvePuzzle1()
        {
            return Data
                .Select(line =>
                {
                    var ligne = new string(line.Where(c => char.IsDigit(c)).ToArray());
                    return int.Parse($"{ligne.First()}{ligne.Last()}");
                }).Sum();
        }

        public override object ResolvePuzzle2()
        {
            return 0;
        }
    }
}
