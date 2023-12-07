namespace AdventOfCode.Day6
{
    public class Course
    {
        public long BestDistance { get; }
        public long MaximumAllowedTime { get; }

        public Course(long maximumAllowedTime, long bestDistance)
        {
            BestDistance = bestDistance;
            MaximumAllowedTime = maximumAllowedTime;
        }

        public long ComputeNumberOfSuccess()
        {
            long recordBeatenCounter = 0;
            for (int buttonPressed = 0; buttonPressed < MaximumAllowedTime; buttonPressed++)
            {
                if (buttonPressed * (MaximumAllowedTime - buttonPressed) > BestDistance)
                {
                    recordBeatenCounter++;
                }
            }
            return recordBeatenCounter;
        }
    }
}