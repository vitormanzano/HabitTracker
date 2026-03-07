using HabitTracker.Habits.Application.Dtos.Habits;

namespace HabitTracker.Habits.Application.Services
{
    public interface IHabitService : IDisposable
    {
        public Task CreateAsync(CreateHabitDto habit);
        public Task<HabitResponseDto> GetByIdAsync(Guid id);
        public Task<IEnumerable<HabitResponseDto>> GetAllAsync();
        public Task CompleteHabitAsync(Guid id);
        public Task UncompleteHabitAsync(Guid id);
        public Task DeleteAsync(Guid id);
    }
}
