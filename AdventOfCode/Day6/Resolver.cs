namespace AdventOfCode.Day6
{
    public class Resolver : BaseResolver
    {
        private readonly IEnumerable<Course> _courses;
        public Resolver(): base(6)
        {
            _courses = ParseCourseData();
        }

        public override object ResolvePuzzle1() => _courses.Select(_ => _.ComputeNumberOfSuccess()).Aggregate((curr, next) => curr*next);

        public override object ResolvePuzzle2()
        {
            var time = "";
            var distance = "";

            foreach (var course in _courses)
            {
                time += course.MaximumAllowedTime.ToString();
                distance += course.BestDistance.ToString();
            }

            var result = new Course(long.Parse(time), long.Parse(distance)).ComputeNumberOfSuccess();

            return result;
        }

        public List<Course> ParseCourseData()
        {
            var time = data[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var distance = data[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return time.Select((temps, index) => new Course(long.Parse(time[index]), long.Parse(distance[index]))).ToList();
        }
    }
}