using AdventOfCode.Extensions;

namespace AdventOfCode.Day8
{
    public class Resolver : BaseResolver
    {
        private readonly (string, string)[] _directionsReplacer = new (string, string)[] { ("L", "0"), ("R", "1") };
        private readonly Dictionary<string, string[]> _maps = new Dictionary<string, string[]>();
        private readonly int[] _directions;
        public Resolver() : base(8)
        {
            _maps = ParseData();
            _directions = data[0].ReplaceOccurences(_directionsReplacer).Select(_ => int.Parse(_.ToString())).ToArray();
        }

        public override object ResolvePuzzle1() => ResolvePath(_maps.First(_ => _.Key == "AAA"));
        public override object ResolvePuzzle2() => throw new NotImplementedException();

        private Dictionary<string, string[]> ParseData()
        {
            return data.Skip(2).Select(x =>
            {
                var position = x.Split(" ")[0];
                var destinationL = x.Split(" ")[2].Replace("(", "").Replace(",", "");
                var destinationR = x.Split(" ")[3].Replace(")", "").Replace(",", "");
                return new KeyValuePair<string, string[]>(position, new string[] { destinationL, destinationR });
            }).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private long ResolvePath(KeyValuePair<string, string[]> map)
        {
            var steps = 0;
            while (map.Key != "ZZZ")
            {
                for (int directionIndex = 0; directionIndex < _directions.Length; directionIndex++)
                {
                    map = _maps.Where(_ => _.Key == map.Value[_directions[directionIndex]]).First();
                    steps++;
                    if (map.Key == "ZZZ") break;
                }
            }
            return steps;
        }
    }
}
