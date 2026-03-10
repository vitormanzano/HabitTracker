namespace HabitTracker.Habits.Domain.Exceptions
{
    public class HabitNotFoundException : Exception
    {
        public HabitNotFoundException() : base("Habit not found.")
        {
        }
    }
}
