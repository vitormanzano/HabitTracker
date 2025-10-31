namespace HabitTracker.Habits.Application.Dtos.Habits
{
    public record HabitResponseDto(
        string Title,
        string Description,
        Guid CategoryId
    );

}
