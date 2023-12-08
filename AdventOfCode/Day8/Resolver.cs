namespace AdventOfCode.Day8
{
    public class Resolver : BaseResolver
    {
        private readonly Dictionary<string, string[]> _maps = new Dictionary<string, string[]>();
        private readonly int[] _directions;
        public Resolver() : base(8)
        {
            _maps = ParseData();
            _directions = Data[0].Replace("L", "0").Replace("R", "1").Select(_ => int.Parse(_.ToString())).ToArray();
        }

        public override object ResolvePuzzle1()
        {
            var actualMap = _maps.First(_ => _.Key == "AAA");
            var steps = 0;
            while (actualMap.Key != "ZZZ")
            {
                for (int directionIndex = 0; directionIndex < _directions.Length; directionIndex++)
                {
                    actualMap = _maps.Where(_ => _.Key == actualMap.Value[_directions[directionIndex]]).First();
                    steps++;
                    if (actualMap.Key == "ZZZ") break;
                }
            }
            return steps;
        }

        public override object ResolvePuzzle2()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, string[]> ParseData()
        {
            return Data.Skip(2).Select(x =>
            {
                var position = x.Split(" ")[0];
                var destinationL = x.Split(" ")[2].Replace("(", "").Replace(",", "");
                var destinationR = x.Split(" ")[3].Replace(")", "").Replace(",", "");
                return new KeyValuePair<string, string[]>(position, new string[] { destinationL, destinationR });
            }).ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
