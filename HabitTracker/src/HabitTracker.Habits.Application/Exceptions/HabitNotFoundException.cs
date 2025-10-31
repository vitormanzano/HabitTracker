namespace HabitTracker.Habits.Application.Exceptions
{
    public class HabitNotFoundException : Exception
    {
        public HabitNotFoundException() : base("Habit not found.")
        {
        }
    }
}
