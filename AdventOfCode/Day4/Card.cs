namespace AdventOfCode.Day4
{
    public class Card
    {
        public int Id { get; }
        public IEnumerable<int> GameNumbers { get; }
        public IEnumerable<int> MyNumbers { get; }
        public int Copies { get; set; }
        public int CommonNumbers => GameNumbers.Intersect(MyNumbers).Count();

        public Card(int id, IEnumerable<int> gameNumbers, IEnumerable<int> myNumbers)
        {
            Id = id;
            GameNumbers = gameNumbers;
            MyNumbers = myNumbers;
            Copies = 1;
        }
        
        public double ComputePoints() => CommonNumbers != 0 ? Math.Pow(2, CommonNumbers - 1) : 0;
    }
}
