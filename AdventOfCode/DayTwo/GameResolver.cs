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

        public int Resolve()
        {
            var games = ParseGameData();
            return games.Where(_ => _.IsGameValid()).Select(_ => _.Id).Sum();
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
                    Cube[] gameCubes = BuildCubes(cubes);
                    gameSets.Add(new Set(gameCubes));
                }

                games.Add(new Game(gameIndex + 1, _gameBag, gameSets.ToArray()));
            }

            return games;
        }

        private Cube[] BuildCubes(string[] cubes)
        {
            return cubes.Select(cube =>
            {
                var cubeVa = cube.Split(" ", StringSplitOptions.None).Where(_ => _ != "").ToArray();
                if (!Enum.TryParse(cubeVa[1], true, out Color color))
                {
                    throw new Exception();
                }
                if (!int.TryParse(cubeVa[0], out int value))
                {
                    throw new Exception();
                }

                return new Cube(color, value);
            }).ToArray();
        }
    }
}
