namespace HabitTracker.Habits.Domain.Exceptions
{
    public class HabitAlreadyExistsException : Exception
    {
        public HabitAlreadyExistsException() : base("Habit already exists.")
        {
        }
    }
}
