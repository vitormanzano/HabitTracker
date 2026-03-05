using HabitTracker.Core.Data;
using HabitTracker.Habits.Domain;
using HabitTracker.Habits.Domain.Habits;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Habits.Data.Repository
{
    public class HabitRepository(HabitContext context) : IHabitRepository
    {
        private readonly HabitContext _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(Habit habit)
        {
            await _context.Habits.AddAsync(habit);
        }

        public async Task<IEnumerable<Habit>> GetAllAsync()
        {
            return await _context.Habits
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Habit?> GetByIdAsync(Guid id)
        {
            return await _context.Habits
                .Include(h => h.Category)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Habit?> GetByTitleAsync(string title)
        {
            return await _context.Habits
                .Include(h => h.Category)
                .FirstOrDefaultAsync(h => h.Title.Equals(title));
        }

        public void UpdateAsync(Habit habit)
        {
            _context.Habits.Update(habit);
        }

        public void DeleteAsync(Habit habit)
        {
            _context.Habits
                .Remove(habit);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
