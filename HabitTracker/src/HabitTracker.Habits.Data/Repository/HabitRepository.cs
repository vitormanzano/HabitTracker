using HabitTracker.Core.Data;
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
            await _context.AddAsync(habit);
        }

        public async Task<IEnumerable<Habit>> GetAllAsync()
        {
            return await _context.Habits
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Habit> GetByIdAsync(Guid id)
        {
            return await _context.Habits
                .FindAsync(id);
        }

        public async Task DeleteAsync(Habit habit)
        {
            _context.Habits
                .Remove(habit);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
