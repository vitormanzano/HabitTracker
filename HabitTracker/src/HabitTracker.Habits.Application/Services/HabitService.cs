using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Application.Exceptions;
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

        public async Task CreateAsync(CreateHabitDto habit)
        {
            await _habitRepository.CreateAsync(new Habit(
                habit.Title,
                habit.Description,
                habit.CategoryId
                ));

            await _habitRepository.UnitOfWork.CommitAsync();
        }

        public async Task<HabitResponseDto> GetByIdAsync(Guid Id)
        {
            var habit = await _habitRepository.GetByIdAsync(Id);
            
            if (habit == null)
                throw new HabitNotFoundException();

            return new HabitResponseDto(
                habit.Title,
                habit.Description,
                habit.CategoryId
                );
        }

        public async Task<IEnumerable<HabitResponseDto>> GetAllAsync()
        {
            var habits =  await _habitRepository.GetAllAsync();

            if (!habits.Any())
                throw new HabitNotFoundException();

            return habits.Select(habit => new HabitResponseDto(
                habit.Title,
                habit.Description,
                habit.CategoryId
                ));
        }

        public Task DeleteAsync(CreateHabitDto habit)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _habitRepository?.Dispose();
        }   
    }
}
