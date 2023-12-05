using System.Collections.Concurrent;

namespace AdventOfCode.Day5
{
    public class Resolver : BaseResolver
    {
        private (double[] seeds, List<List<(double source, double destination, double range)>> maps) _data;
        public Resolver() : base(5) 
        {
            _data = ParseData();
        }

        public override object ResolvePuzzle1() => _data.seeds.Select(seed => GetSeedLocation(seed)).Min();
        public override object ResolvePuzzle2() => ComputePuzzle2();

        private double ComputePuzzle2()
        {
            var seeds = _data.seeds.Where((s, index) => index % 2 == 0).ToList();
            var counter = _data.seeds.Where((s, index) => index % 2 != 0).ToList();
            var results = new List<double>();

            Parallel.For(0, seeds.Count(), i =>
            {
                double resultLocal = -1;
                var maSeed = seeds[i];
                for (int j = 0; j < counter[i]; j++)
                {
                    double seedLocation = GetSeedLocation(maSeed + j);
                    resultLocal = resultLocal == -1
                     ? seedLocation : (seedLocation < resultLocal) 
                        ? seedLocation : resultLocal;
                }
                results.Add(resultLocal);
            });

            return results.Min();
        }

        private double GetSeedLocation(double seed)
        {
            foreach (var map in _data.maps)
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

        private (double[] seeds, List<List<(double source, double destination, double range)>> maps) ParseData()
        {
            var maps = new List<List<(double source, double destination, double range)>>();
            var map = new List<(double source, double destination, double range)>();
            var seeds = Data[0].Split(" ")
                      .Where(_ => _.All(char.IsDigit))
                      .Select(_ => double.Parse(_)).ToArray();

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
            return (seeds, maps);
        }


    }
}
