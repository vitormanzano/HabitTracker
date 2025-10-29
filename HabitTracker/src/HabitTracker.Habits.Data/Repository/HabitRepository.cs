using HabitTracker.Core.Data;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Data.Repository
{
    internal class HabitRepository(HabitContext context) : IHabitRepository
    {
        private readonly HabitContext _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
