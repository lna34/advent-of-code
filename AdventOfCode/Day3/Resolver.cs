using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Extensions;

namespace AdventOfCode.Day3
{
    internal class Resolver : BaseResolver
    {
        public Resolver(): base(3) { }

        public override object ResolvePuzzle1()
        {
            var numbersToBeReturned = ComputeNumbersAdjacentsWithSymbols();
        
            return numbersToBeReturned.Sum();
        }

        public override object ResolvePuzzle2()
        {
            var numbersToBeReturned = ComputeNumbersAdjacentsToAsterisk();
            return numbersToBeReturned.Sum();
        }

        private List<int> ComputeNumbersAdjacentsWithSymbols()
        {
            var numbersToBeReturned = new List<int>();

            for (int lineIndex = 0; lineIndex < Data.Length; lineIndex++)
            {
                var currentLine = Data[lineIndex];
                var previousLine = lineIndex == 0 ? null : Data[lineIndex - 1];
                var nextLine = lineIndex >= Data.Length - 1 ? null : Data[lineIndex + 1];

                for (int charIndex = 0; charIndex < currentLine.Length; charIndex++)
                {
                    if (char.IsDigit(currentLine[charIndex]))
                    {
                        var charHasAdjacent = 
                            NumberHasAdjacents(currentLine, charIndex) 
                            || NumberHasAdjacents(nextLine, charIndex) 
                            || NumberHasAdjacents(previousLine, charIndex);

                        if (charHasAdjacent)
                        {
                            var result = BuildNumber(currentLine, charIndex);
                            numbersToBeReturned.Add(result.Number);
                            charIndex = result.NewIndex;
                        }
                    }
                }
            }

            return numbersToBeReturned;
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
                            numbersToBeReturned.Add( asteriskAdjacents.Select(_ =>
                             {
                                 var num = BuildNumber(_.line, _.index).Number; 
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
            var hasAdjacentPrec = index > 0 ? char.IsDigit(line[index - 1])  : false;
            var hasAdjecentSuivant = index < line.Length - 1 ? char.IsDigit(line[index + 1])  : false;
            var hasAdjacentCar = index > 0 ? char.IsDigit(line[index]) : false;
            
            if((hasAdjacentPrec && hasAdjecentSuivant && hasAdjacentCar) || (hasAdjecentSuivant && hasAdjacentCar) || (hasAdjacentPrec && hasAdjacentCar))
            {
                adjacents.Add((line, index));
                return adjacents;
            }
            if (hasAdjecentSuivant)
            {
                adjacents.Add((line, index + 1));

            }
            if (hasAdjacentPrec)
            {
                adjacents.Add((line, index - 1));
            }

            return adjacents;
        }

        private bool NumberHasAdjacents(string? line, int index)
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

        private (int NewIndex, int Number) BuildNumber(string ligneEnCours, int charIndex)
        {
            while (charIndex - 1 >= 0 && char.IsDigit(ligneEnCours[charIndex - 1]))
            {
                charIndex = charIndex - 1;
            }

            var builtNumber = "";

            while (charIndex < ligneEnCours.Length && char.IsDigit(ligneEnCours[charIndex]))
            {
                var currentDigit = ligneEnCours[charIndex];
                builtNumber += currentDigit;
                charIndex = charIndex + 1;
            }

            charIndex -= 1;

            return (charIndex, int.Parse(builtNumber));
        }

    }
}
