using HabitTracker.Habits.Application.Dtos.Category;
using HabitTracker.Habits.Application.Dtos.Habits;
using HabitTracker.Habits.Domain.Exceptions;
using HabitTracker.Habits.Domain;
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

        public async Task DeleteAsync(Guid id)
        {
            var habit = await habitRepository.GetByIdAsync(id);

            if (habit == null)
                throw new HabitNotFoundException();

            habitRepository.DeleteAsync(habit);
            await habitRepository.UnitOfWork.CommitAsync();
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var categoryExists = await habitRepository.GetCategoryByNameAsync(createCategoryDto.Name);

            if (categoryExists != null)
                throw new CategoryAlreadyExistsException();

            await habitRepository.CreateCategoryAsync(new Category(createCategoryDto.Name));
            await habitRepository.UnitOfWork.CommitAsync();
        }

        public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await habitRepository.GetCategoryByIdAsync(id);

            if (category == null)
                throw new CategoryNotFoundException();

            return new CategoryResponseDto(category.Id, category.Name);
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var categories = await habitRepository.GetAllCategoriesAsync();

            if (!categories.Any())
                throw new CategoryNotFoundException();

            return categories.Select(category => new CategoryResponseDto(category.Id, category.Name));
        }

        public async Task DeleteCategoryByIdAsync(Guid id)
        {
            var category = await habitRepository.GetCategoryByIdAsync(id);

            if (category == null)
                throw new CategoryNotFoundException();

            habitRepository.DeleteCategory(category);
            await habitRepository.UnitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            habitRepository?.Dispose();
        }
    }
}
