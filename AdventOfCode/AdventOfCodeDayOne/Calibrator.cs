namespace AdventOfCode.AdventOfCodeDayOne
{
    public class Calibrator
    {
        private string[] _linesToBeDecoded;

        public Calibrator(string[] linesToBeDecoded) 
        {
            _linesToBeDecoded = linesToBeDecoded; 
        }

        public int Resolve()
        {
            return _linesToBeDecoded
                .Select(line => new string(line.Where(c => char.IsDigit(c)).ToArray()))
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => Convert.ToInt32($"{line.First()}{line.Last()}"))
                .Sum();
        }
    }
}
