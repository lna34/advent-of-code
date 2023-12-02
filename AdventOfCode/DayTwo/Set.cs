namespace AdventOfCode.DayTwo
{
    public class Set
    {
        public Cube[] Cubes { get; }

        public Set(Cube[] cubes)
        {
            Cubes = cubes;
        }

        public bool IsSetValid(Set gameBag)
        {
            return !Cubes.Any(cube =>
                 gameBag.Cubes.FirstOrDefault(gameBagCube => gameBagCube.Color == cube.Color)?.Value < cube.Value
             );
        }
    }
}
