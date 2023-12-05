using System.Collections.Concurrent;

namespace AdventOfCode.Day5
{
    public class Resolver : BaseResolver
    {
        private readonly List<List<(double source, double destination, double range)>> _maps;
        private readonly double[] _seeds;
        public Resolver() : base(5) 
        {
            _maps = ParseMapData();
            _seeds = ParseSeedsData();
        }

        public override object ResolvePuzzle1() => _seeds.Select(seed => GetSeedLocation(seed)).Min();
        public override object ResolvePuzzle2() => ComputePuzzle2();

        private double ComputePuzzle2()
        {
            var seeds = _seeds.Where((s, index) => index % 2 == 0).ToList();
            var counter = _seeds.Where((s, index) => index % 2 != 0).ToList();
            var results = new List<double>();

            Parallel.For(0, seeds.Count(), i =>
            {
                double minimumSeedLocation = -1;
                for (int j = 0; j < counter[i]; j++)
                {
                    double seedLocation = GetSeedLocation(seeds[i] + j);
                    minimumSeedLocation = minimumSeedLocation == -1
                     ? seedLocation : (seedLocation < minimumSeedLocation) 
                        ? seedLocation : minimumSeedLocation;
                }
                results.Add(minimumSeedLocation);
            });

            return results.Min();
        }

        private double GetSeedLocation(double seed)
        {
            foreach (var map in _maps)
            {
                foreach (var subMap in map)
                {
                    if (seed >= subMap.source && seed <= subMap.source + subMap.range)
                    {
                        seed = subMap.destination + (seed - subMap.source);
                        break;
                    }
                }
            }

            return seed;
        }

        private List<List<(double source, double destination, double range)>> ParseMapData()
        {
            var maps = new List<List<(double source, double destination, double range)>>();
            var map = new List<(double source, double destination, double range)>();
          
            for (int dataIndex = 2; dataIndex < Data.Length; dataIndex++)
            {
                var line = Data[dataIndex];
                if (line.Contains("map")) continue;

                if (string.IsNullOrWhiteSpace(line))
                {
                    maps.Add(map);
                    map = new List<(double source, double destination, double range)>();
                    continue;
                }

                map.Add((double.Parse(line.Split(" ")[1]), double.Parse(line.Split(" ")[0]), double.Parse(line.Split(" ")[2])));
            }
            maps.Add(map);
            return maps;
        }

        private double[] ParseSeedsData()
        {
           return Data[0].Split(" ")
                    .Where(_ => _.All(char.IsDigit))
                    .Select(_ => double.Parse(_)).ToArray();
        }


    }
}
