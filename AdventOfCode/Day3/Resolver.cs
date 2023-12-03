using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    internal class Resolver : BaseResolver
    {
        public Resolver(): base(3) { }

        public override object ResolvePuzzle1()
        {
            var adjacentsNumbers = ComputeNumbersAdjacentsWithSymbols();
        
            return adjacentsNumbers.Sum();
        }

        public override object ResolvePuzzle2()
        {
            var adjacentsNumbers = ComputeNumbersAdjacentsToAsterisk();
            return adjacentsNumbers.Sum();
        }

        private List<int> ComputeNumbersAdjacentsWithSymbols()
        {
            var adjacentsNumbers = new List<int>();

            for (int lineIndex = 0; lineIndex < Data.Length; lineIndex++)
            {
                var currentLine = Data[lineIndex];
                var previousLine = lineIndex == 0 ? null : Data[lineIndex - 1];
                var nextLine = lineIndex >= Data.Length - 1 ? null : Data[lineIndex + 1];

                for (int charIndex = 0; charIndex < currentLine.Length; charIndex++)
                {
                    if (
                        char.IsDigit(currentLine[charIndex]) 
                        && (DigitHasAdjacentSymbols(currentLine, charIndex)
                        || DigitHasAdjacentSymbols(nextLine, charIndex)
                        || DigitHasAdjacentSymbols(previousLine, charIndex)))
                    {
                        var result = BuildNumberHavingAdjacentSymbols(currentLine, charIndex);
                        adjacentsNumbers.Add(result.Number);
                        charIndex = result.NewIndex;
                    }
                }
            }

            return adjacentsNumbers;
        }

        private List<int> ComputeNumbersAdjacentsToAsterisk()
        {
            var numbersToBeReturned = new List<int>();

            for (int lineIndex = 0; lineIndex < Data.Length; lineIndex++)
            {
                var currentLine = Data[lineIndex];
                var previousLine = lineIndex == 0 ? null : Data[lineIndex - 1];
                var nextLine = lineIndex >= Data.Length - 1 ? null : Data[lineIndex + 1];

                for (int charIndex = 0; charIndex < currentLine.Length; charIndex++)
                {
                    if(currentLine[charIndex] == '*')
                    {
                        List<(string line, int index)> asteriskAdjacents = new List<(string line, int index)>();
                        asteriskAdjacents.AddRange(GetGearAdjacents(currentLine, charIndex));
                        asteriskAdjacents.AddRange(GetGearAdjacents(nextLine, charIndex));
                        asteriskAdjacents.AddRange(GetGearAdjacents(previousLine, charIndex));

                        if(asteriskAdjacents.Count >= 2)
                        {
                            numbersToBeReturned.Add(asteriskAdjacents.Select(_ =>
                             {
                                 var num = BuildNumberHavingAdjacentSymbols(_.line, _.index).Number; 
                                 return num;
                             }).Aggregate((current, next) => current * next));
                        }
                    }
                }
            }

            return numbersToBeReturned;
        }

        private List<(string line, int index)> GetGearAdjacents(string? line, int index)
        {
            if (line == null)
            {
                return new List<(string line, int index)>();
            }
            var adjacents = new List<(string line, int index)>();
            var hasAdjacentOnPreviousChar = index > 0 ? char.IsDigit(line[index - 1])  : false;
            var hasAdjacentOnNextChar = index < line.Length - 1 ? char.IsDigit(line[index + 1])  : false;
            var hasAdjacentOnCurrentChar = index > 0 ? char.IsDigit(line[index]) : false;
            
            if((hasAdjacentOnPreviousChar && hasAdjacentOnNextChar && hasAdjacentOnCurrentChar) || (hasAdjacentOnNextChar && hasAdjacentOnCurrentChar) || (hasAdjacentOnPreviousChar && hasAdjacentOnCurrentChar))
            {
                adjacents.Add((line, index));
                return adjacents;
            }
            if (hasAdjacentOnNextChar)
            {
                adjacents.Add((line, index + 1));

            }
            if (hasAdjacentOnPreviousChar)
            {
                adjacents.Add((line, index - 1));
            }

            return adjacents;
        }

        private bool DigitHasAdjacentSymbols(string? line, int index)
        {
            if (line == null)
            {
                return false;
            }
            var hasAdjacentOnPreviousChar = index > 0 ? !char.IsDigit(line[index - 1]) && line[index - 1] != '.' : false;
            var hasAdjacentOnNextChar = index < line.Length - 1 ? !char.IsDigit(line[index + 1]) && line[index + 1] != '.' : false;
            var hasAdjacentOnCurrentChar =  !char.IsDigit(line[index]) && line[index] != '.';

            return hasAdjacentOnPreviousChar || hasAdjacentOnNextChar || hasAdjacentOnCurrentChar;
        }

        private (int NewIndex, int Number) BuildNumberHavingAdjacentSymbols(string line, int charIndex)
        {
            while (charIndex - 1 >= 0 && char.IsDigit(line[charIndex - 1]))
            {
                charIndex = charIndex - 1;
            }

            var number = "";

            while (charIndex < line.Length && char.IsDigit(line[charIndex]))
            {
                var currentDigit = line[charIndex];
                number += currentDigit;
                charIndex = charIndex + 1;
            }

            charIndex -= 1;

            return (charIndex, int.Parse(number));
        }

    }
}
