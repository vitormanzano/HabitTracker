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
                new Habit(string.Empty, "Description", Guid.NewGuid()));
            
            Assert.Equal("The title of the habit cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("a", "Description", Guid.NewGuid()));

            Assert.Equal("The title of the habit must be between 3 and 100 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit(new string('A', 101), string.Empty, Guid.NewGuid()));

            Assert.Equal("The title of the habit must be between 3 and 100 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", string.Empty, Guid.NewGuid()));

            Assert.Equal("The description of the habit cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", "abc", Guid.NewGuid()));

            Assert.Equal("The description of the habit must be between 5 and 500 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", new string('A', 501), Guid.NewGuid()));

            Assert.Equal("The description of the habit must be between 5 and 500 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Habit("new Habit", "Description", Guid.Empty));

            Assert.Equal("The category ID of the habit must be a valid GUID.", ex.Message);
        }
    }
}