namespace HabitTracker.Habits.Application.Exceptions
{
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException() : base("Category already exists.")
        {
        }
    }
}
