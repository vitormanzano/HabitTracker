namespace HabitTracker.Habits.Domain.Service
{
    public interface ITimesCompletedService
    {
        Task<bool> MarkAsCompleted(Guid habitId);
        Task<bool> UnmarkAsCompleted(Guid habitId);
    }
}
