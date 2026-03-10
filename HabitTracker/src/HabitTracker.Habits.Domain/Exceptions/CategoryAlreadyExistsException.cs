namespace HabitTracker.Habits.Domain.Exceptions
{
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException() : base("Category already exists.")
        {
        }
    }
}
