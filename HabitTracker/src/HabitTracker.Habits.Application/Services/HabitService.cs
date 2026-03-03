using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Application.Exceptions;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Application.Services
{  
    public class HabitService(IHabitRepository habitRepository) : IHabitService
    {
        public async Task CreateAsync(CreateHabitDto habit)
        {
            var habitExists = await habitRepository.GetByTitleAsync(habit.Title);

            if (habitExists != null)
                throw new HabitAlreadyExistsException();

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

        public async Task CompleteHabitAsync(Guid id)
        {
            var habit = await habitRepository.GetByIdAsync(id);

            if (habit == null)
                throw new HabitNotFoundException();

            habit.DidHabit();
            await habitRepository.UnitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var habit = await habitRepository.GetByIdAsync(id);

            if (habit == null)
                throw new HabitNotFoundException();

            habitRepository.DeleteAsync(habit);
            await habitRepository.UnitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            habitRepository?.Dispose();
        }
    }
}
