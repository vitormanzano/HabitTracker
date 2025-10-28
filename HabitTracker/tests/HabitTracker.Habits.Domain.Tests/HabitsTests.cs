using HabitTracker.Core.DomainObjects;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Domain.Tests
{
    public class HabitsTests
    {
        [Fact]
        public void Habit_Validate_ValidationsShouldReturnExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Habit(string.Empty, "Description", 2, Guid.NewGuid()));
            
            Assert.Equal("The title of the habit cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("a", "Description", 2, Guid.NewGuid()));

            Assert.Equal("The title of the habit must be between 3 and 100 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit(new string('A', 101), string.Empty, 2, Guid.NewGuid()));

            Assert.Equal("The title of the habit must be between 3 and 100 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", string.Empty, 2, Guid.NewGuid()));

            Assert.Equal("The description of the habit cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", "abc", 2, Guid.NewGuid()));

            Assert.Equal("The description of the habit must be between 5 and 500 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", new string('A', 501), 2, Guid.NewGuid()));

            Assert.Equal("The description of the habit must be between 5 and 500 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", "Description", -1, Guid.NewGuid()));

            Assert.Equal("The frequency of the habit must be a non-negative integer.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", "Description", 2, Guid.Empty));

            Assert.Equal("The category ID of the habit must be a valid GUID.", ex.Message);
        }
    }
}