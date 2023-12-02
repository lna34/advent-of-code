namespace AdventOfCode.DayTwo
{
    public class Game
    {
        public int Id { get; }
        public Game GameBag { get; }
        public Set[] Sets { get; }

        public Game(int id, Game gameBag, Set[] sets)
        {
            Id = id;
            Sets = sets;
            GameBag = gameBag;
        }

        public bool IsGameValid()
        {
            return !Sets.Any(set => !set.IsSetValid(GameBag.Sets.First()));
        }
    }
}
