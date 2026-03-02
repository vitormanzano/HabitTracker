using HabitTracker.Core.Data;

namespace HabitTracker.Habits.Domain.Habits
{
    public interface IHabitRepository : IRepository<Habit>
    {
        Task CreateAsync(Habit habit);
        Task<Habit?> GetByIdAsync(Guid id);
        Task<IEnumerable<Habit>> GetAllAsync();
        void UpdateAsync(Habit habit);
        void DeleteAsync(Habit habit);
    }
}
