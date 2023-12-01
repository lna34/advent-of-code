using AdventOfCode.AdventOfCodeDayOne;

string[] linesToBeDecoded = File.ReadAllLines(@"C:\Users\Luc\source\repos\AdventOfCode\AdventOfCode\AdventOfCodeDayOne\data.txt");
int dayOneResult = new Decoder(linesToBeDecoded).Resolve();
Console.WriteLine(dayOneResult);