using HabitTracker.Core.Data;
using HabitTracker.Habits.Domain;
using HabitTracker.Habits.Domain.Habits;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Habits.Data
{
    public class HabitContext: DbContext, IUnitOfWork
    {
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Category> Categories { get; set; }

        public HabitContext(DbContextOptions<HabitContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))
                )
            )
                property.SetMaxLength(100);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HabitContext).Assembly);
        }

        public async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;

                if (entry.State == EntityState.Modified)
                    entry.Property("CreatedAt").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
