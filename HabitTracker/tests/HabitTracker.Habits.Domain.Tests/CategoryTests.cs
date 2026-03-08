using HabitTracker.Core.DomainObjects;

namespace HabitTracker.Habits.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void Test_Validate_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainException>(() => new Category(string.Empty));
            Assert.Equal("The name of the category cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Category("aa"));
            Assert.Equal("The name of the category must be between 3 and 100 characters.", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Category(new string('A', 101)));
            Assert.Equal("The name of the category must be between 3 and 100 characters.", ex.Message);
        }
    }
}
