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
        
        public int GetSum() => IsGameValid() ? Id : 0;
        public int GetPowerSet() => Sets.Max(_ => _.Red) * Sets.Max(_ => _.Blue) * Sets.Max(_ => _.Green);
        public bool IsGameValid()
        {
            return !Sets.Any(set => !set.IsSetValid(GameBag.Sets.First()));
        }
    }
}
