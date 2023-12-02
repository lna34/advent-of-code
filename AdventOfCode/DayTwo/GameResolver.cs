namespace AdventOfCode.DayTwo
{
    public class GameResolver
    {
        private string[] _gameData;
        private Game _gameBag;

        public GameResolver(Game gameBag, string[] gameData)
        {
            _gameData = gameData;
            _gameBag = gameBag;
        }

        public int ResolvePuzzle1()
        {
            var games = ParseGameData();
            return games.Where(_ => _.IsGameValid()).Select(_ => _.Id).Sum();
        }

        public int ResolvePuzzle2()
        {
            var games = ParseGameData();
            return games.Select(_ => _.Sets.Max(_ => _.Red) * _.Sets.Max(_ => _.Blue) * _.Sets.Max(_ => _.Green)).Sum();
        }


        private List<Game> ParseGameData()
        {
            char[] setDelimiters = { ':', ';' };
            char cubesDelimiter = ',';
            var games = new List<Game>();

            for (int gameIndex = 0; gameIndex < _gameData.Length; gameIndex++)
            {
                var sets = _gameData[gameIndex].Split(setDelimiters, StringSplitOptions.None);
                var gameSets = new List<Set>();

                for (int setIndex = 0; setIndex < sets.Length; setIndex++)
                {
                    if (setIndex == 0)
                    {
                        continue;
                    }

                    var cubes = sets[setIndex].Split(cubesDelimiter, StringSplitOptions.None);
                    var red = GetCubeCount(cubes, nameof(Color.Red).ToLower());
                    var green = GetCubeCount(cubes, nameof(Color.Green).ToLower());
                    var blue = GetCubeCount(cubes, nameof(Color.Blue).ToLower());

                    gameSets.Add(new Set(red, green, blue));
                }

                games.Add(new Game(gameIndex + 1, _gameBag, gameSets.ToArray()));
            }

            return games;
        }

        private int GetCubeCount(string[] cubes, string color)
        {
            return cubes.Where(_ => _.Contains(color)).Sum(_ => int.Parse(_.Split(" ", StringSplitOptions.None)[1])); 
        }

    }
}
