using HabitTracker.Core.DomainObjects;
using HabitTracker.Habits.Domain.Habits;

namespace HabitTracker.Habits.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Habit> Habits { get; private set; }

        protected Category() { }

        public Category(string name)
        {
            Name = name;

            Validate();
        }

        public void UpdateName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        private void ValidateName(string name)
        {
            AssertionConcern.ValidateIfEmpty(Name, "The name of the category cannot be empty.");
            AssertionConcern.ValidateCharacters(Name, 3, 100, "The name of the category must be between 3 and 100 characters.");
        }

        public void Validate()
        {
            ValidateName(Name);
        }
    }
}
