using HabitTracker.Habits.Domain.Exceptions;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Domain.Service
{
    public class TimesCompletedService(IHabitRepository habitRepository) : ITimesCompletedService
    {
        public async Task<bool> MarkAsCompleted(Guid habitId)
        {
            var habit = await habitRepository.GetByIdAsync(habitId);

            if (habit == null)
                throw new HabitNotFoundException();

            habit.CompleteHabit();
            habitRepository.UpdateAsync(habit);

            return await habitRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> UnmarkAsCompleted(Guid habitId)
        {
            var habit = await habitRepository.GetByIdAsync(habitId);

            if (habit == null)
                throw new HabitNotFoundException();

            habit.UncompleteHabit();
            habitRepository.UpdateAsync(habit);

            return await habitRepository.UnitOfWork.CommitAsync();
        }
    }
}
