namespace AdventOfCode.Extensions
{
    public static class CharExtensions
    {
        public static bool IsNum(this char c)
        {
            return c >= '0' && c <= '9';
        }
    }

}
