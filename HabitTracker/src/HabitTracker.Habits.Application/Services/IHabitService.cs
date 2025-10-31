using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Application.Services
{
    public interface IHabitService : IDisposable
    {
        public Task CreateAsync(CreateHabitDto habit);
        public Task<Habit> GetByIdAsync(Guid Id);
        public Task<IEnumerable<Habit>> GetAllAsync();
        public Task DeleteAsync(CreateHabitDto habit);
    }
}
