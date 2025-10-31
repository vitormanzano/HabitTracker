namespace HabitTracker.Habits.Application.Dtos.Habits
{
    public record CreateHabitDto(
        string Title,
        string Description,
        Guid CategoryId);
}
