using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Application.Services
{
    public interface IHabitService : IDisposable
    {
        public Task CreateAsync(CreateHabitDto habit);
        public Task<HabitResponseDto> GetByIdAsync(Guid Id);
        public Task<IEnumerable<HabitResponseDto>> GetAllAsync();
        public Task DeleteAsync(CreateHabitDto habit);
    }
}
