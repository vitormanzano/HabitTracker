using HabitTracker.Habits.Application.Dtos.Category;
using HabitTracker.Habits.Application.Dtos.Habits;

namespace HabitTracker.Habits.Application.Services
{
    public interface IHabitService : IDisposable
    {
        public Task CreateAsync(CreateHabitDto habit);
        public Task<HabitResponseDto> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);

        public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        public Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id);
        public Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
        public Task DeleteCategoryByIdAsync(Guid id);
    }
}
