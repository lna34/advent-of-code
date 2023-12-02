namespace AdventOfCode.DayTwo
{
    public class GameResolver 
    {
        private readonly string[] _gamesData;
        private readonly Game _gameBag;
        private readonly IReadOnlyCollection<Game> _games;
        public GameResolver(Game gameBag, string[] gameData)
        {
            _gameBag = gameBag;
            _gamesData = gameData;
            _games = ParseGameData();
        }

        public int ResolvePuzzle1()
        {
            return _games.Select(game => game.GetSum()).Sum();
        }

        public int ResolvePuzzle2()
        {
            return _games.Select(game => game.GetPowerSet()).Sum();
        }

        private List<Game> ParseGameData()
        {
            char[] setDelimiters = { ':', ';' };
            char cubesDelimiter = ',';

            return _gamesData.Select((game, index) =>
            {
                var sets = game.Split(setDelimiters, StringSplitOptions.None).Where(_ => !_.Contains("Game")).Select(set =>
                {
                    var cubes = set.Split(cubesDelimiter, StringSplitOptions.None);
                    var red = GetCubeCount(cubes, nameof(Color.Red).ToLower());
                    var green = GetCubeCount(cubes, nameof(Color.Green).ToLower());
                    var blue = GetCubeCount(cubes, nameof(Color.Blue).ToLower());
                    return new Set(red, green, blue);
                }).ToArray();

                return new Game(index, _gameBag, sets);
            }).ToList();
        }

        private int GetCubeCount(string[] cubes, string color)
        {
            return cubes.Where(_ => _.Contains(color)).Sum(_ => int.Parse(_.Split(" ", StringSplitOptions.None)[1])); 
        }

    }
}
