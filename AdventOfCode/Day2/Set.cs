namespace AdventOfCode.Day2
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }
    public class Set
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public Set(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public bool IsSetValid(Set gameBag)
        {
            return gameBag.Red >= Red && gameBag.Green >= Green && gameBag.Blue >= Blue;
        }

    }
}
