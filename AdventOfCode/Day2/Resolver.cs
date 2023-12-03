namespace AdventOfCode.Day2
{
    public class Resolver : BaseResolver
    {
        private readonly Game _gameBag;
        private readonly IEnumerable<Game> _games;
        public Resolver() : base(2)
        {
            _gameBag = new Game(0, new Set[] { new Set(12, 13, 14) });
            _games = ParseGameData();
        }

        public override object ResolvePuzzle1() => _games.Select(game => game.GetSum(_gameBag)).Sum();
        public override object ResolvePuzzle2() => _games.Select(game => game.GetPowerSet()).Sum();

        private IEnumerable<Game> ParseGameData()
        {
            return Data.Select((game, index) =>
            {
                var sets = game.Split(new char[] { ':', ';' }, StringSplitOptions.None).Select(set =>
                 {
                     var cubes = set.Split(',', StringSplitOptions.None);
                     return new Set(GetCubeValue(cubes, Color.Red), GetCubeValue(cubes, Color.Green), GetCubeValue(cubes, Color.Blue));
                 }).ToArray();

                return new Game(index, sets);
            });
        }

        private int GetCubeValue(string[] cubes, Color color) => cubes.Where(
                _ => _.Contains(color.ToString().ToLower())
            ).Sum(_ => int.Parse(_.Split(" ", StringSplitOptions.None)[1]));
    }
}
