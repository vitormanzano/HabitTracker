using HabitTracker.Habits.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HabitTracker.Habits.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(127)");

            // 1 : N | Category : Habits
            builder.HasMany(p => p.Habits)
                .WithOne(h => h.Category)
                .HasForeignKey(h => h.CategoryId);
        }
    }
}
