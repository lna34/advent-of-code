namespace AdventOfCode.Day2
{
    public class Game
    {
        public int Id { get; }
        public Set[] Sets { get; }

        public Game(int id, Set[] sets)
        {
            Id = id;
            Sets = sets;
        }
        
        public int GetPowerSet() => Sets.Max(_ => _.Red) * Sets.Max(_ => _.Blue) * Sets.Max(_ => _.Green);
        public int GetSum(Game gameBag) => IsGameValid(gameBag) ? Id : 0;
        public bool IsGameValid(Game gameBag)
        {
            return !Sets.Any(set => !set.IsSetValid(gameBag.Sets.First()));
        }
    }
}
