using AdventOfCode.AdventOfCodeDayOne;
using AdventOfCode.DayTwo;

string[] linesToBeDecoded = File.ReadAllLines(@"C:\Users\Luc\source\repos\AdventOfCode\AdventOfCode\DayOne\puzzle_1_data.txt");
var decoder = new Decoder(linesToBeDecoded);
int dayOneResultPuzzle1 = decoder.ResolvePuzzle1();
Console.WriteLine(dayOneResultPuzzle1);

string[] gameData = File.ReadAllLines(@"C:\Users\Luc\source\repos\AdventOfCode\AdventOfCode\DayTwo\game_data.txt");

var gameBag = new Game(0, null, new Set[]
{
    new Set(new Cube[]
    {
        new Cube(Color.Red, 12),
        new Cube(Color.Green, 13),
        new Cube(Color.Blue, 14),
    })
});

var gameResolver = new GameResolver(gameBag, gameData);
var result = gameResolver.Resolve();
Console.WriteLine(gameData);