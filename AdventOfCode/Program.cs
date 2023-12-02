using AdventOfCode.AdventOfCodeDayOne;
using AdventOfCode.DayTwo;

string[] linesToBeDecoded = File.ReadAllLines(@"C:\Users\Luc\source\repos\AdventOfCode\AdventOfCode\DayOne\puzzle_1_data.txt");
var decoder = new Decoder(linesToBeDecoded);
int dayOneResultPuzzle1 = decoder.ResolvePuzzle1();
Console.WriteLine(dayOneResultPuzzle1);

string[] gameData = File.ReadAllLines(@"C:\Users\Luc\source\repos\AdventOfCode\AdventOfCode\DayTwo\game_data.txt");

var gameBag = new Game(0, null, new Set[]
{
    new Set(12,13,14)
});

var gameResolver = new GameResolver(gameBag, gameData);
var resultPuzzle1 = gameResolver.ResolvePuzzle1();
var resultPuzzle2 = gameResolver.ResolvePuzzle2();
Console.WriteLine(resultPuzzle1);
Console.WriteLine(resultPuzzle2);