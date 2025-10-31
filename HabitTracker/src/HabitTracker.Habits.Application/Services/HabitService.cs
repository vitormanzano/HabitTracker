using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Application.Services
{  
    public class HabitService : IHabitService
    {
        private readonly IHabitRepository _habitRepository;

        public HabitService(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public Task CreateAsync(CreateHabitDto habit)
        {
            throw new NotImplementedException();
        }

        public Task<Habit> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Habit>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CreateHabitDto habit)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }   
    }
}
