namespace HabitTracker.Habits.Application.Exceptions
{
    public class HabitAlreadyExistsException : Exception
    {
        public HabitAlreadyExistsException() : base("Habit already exists.")
        {
        }
    }
}
