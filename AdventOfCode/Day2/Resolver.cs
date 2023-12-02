namespace AdventOfCode.Day2
{
    public class Resolver : BaseResolver
    {
        private readonly Game _gameBag;
        private readonly IReadOnlyCollection<Game> _games;
        public Resolver() : base(2)
        {
            _gameBag = new Game(0, new Set[]
            {
                new Set(12,13,14)
            });

            _games = ParseGameData();
        }

        public override int ResolvePuzzle1()
        {
            return _games.Select(game => game.GetSum(_gameBag)).Sum();
        }

        public override int ResolvePuzzle2()
        {
            return _games.Select(game => game.GetPowerSet()).Sum();
        }

        private List<Game> ParseGameData()
        {
            char[] setDelimiters = { ':', ';' };
            char cubesDelimiter = ',';

            return Data.Select((game, index) =>
            {
                var sets = game.Split(setDelimiters, StringSplitOptions.None).Select(set =>
                {
                    var cubes = set.Split(cubesDelimiter, StringSplitOptions.None);
                    var red = GetCubeCount(cubes, nameof(Color.Red).ToLower());
                    var green = GetCubeCount(cubes, nameof(Color.Green).ToLower());
                    var blue = GetCubeCount(cubes, nameof(Color.Blue).ToLower());
                    return new Set(red, green, blue);
                }).ToArray();

                return new Game(index, sets);
            }).ToList();
        }

        private int GetCubeCount(string[] cubes, string color)
        {
            return cubes.Where(_ => _.Contains(color)).Sum(_ => int.Parse(_.Split(" ", StringSplitOptions.None)[1])); 
        }
    }
}
