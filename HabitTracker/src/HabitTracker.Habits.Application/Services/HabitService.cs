using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Application.Exceptions;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Application.Services
{  
    public class HabitService(IHabitRepository habitRepository) : IHabitService
    {
        public async Task CreateAsync(CreateHabitDto habit)
        {
            await habitRepository.CreateAsync(new Habit(
                habit.Title,
                habit.Description,
                habit.CategoryId
                ));

            await habitRepository.UnitOfWork.CommitAsync();
        }

        public async Task<HabitResponseDto> GetByIdAsync(Guid id)
        {
            var habit = await habitRepository.GetByIdAsync(id);
            
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
            var habits =  await habitRepository.GetAllAsync();

            if (!habits.Any())
                throw new HabitNotFoundException();

            return habits.Select(habit => new HabitResponseDto(
                habit.Title,
                habit.Description,
                habit.CategoryId
                ));
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            habitRepository?.Dispose();
        }   
    }
}
