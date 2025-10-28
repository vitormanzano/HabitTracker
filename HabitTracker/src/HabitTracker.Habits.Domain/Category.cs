using HabitTracker.Core.DomainObjects;

namespace HabitTracker.Habits.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            Name = name;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.ValidateIfEmpty(Name, "The name of the category cannot be empty.");
            AssertionConcern.ValidateCharacters(Name, 3, 100, "The name of the category must be between 3 and 100 characters.");
        }
    }
}
