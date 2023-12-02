namespace AdventOfCode.DayTwo
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public class Cube
    {
        public Color Color { get; }
        public int Value { get; }

        public Cube(Color color, int value)
        {
            Value = value;
            Color = color;
        }
    }
}
