using HabitTracker.Habits.Domain.Habits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HabitTracker.Habits.Data.Configurations
{
    public class HabitConfiguration : IEntityTypeConfiguration<Habit>
    {
        public void Configure(EntityTypeBuilder<Habit> builder)
        {
            builder.ToTable("Habits");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnType("VARCHAR(255)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(255)");

            builder.Property(p => p.Frequency)
                .IsRequired()
                .HasColumnType("INTEGER");
        }
    }
}
