using HabitTracker.Core.DomainObjects;

namespace HabitTracker.Habits.Domain.Habits
{
    public class Habit : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int TimesCompleted { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public bool IsActive { get; private set; }

        protected Habit() { }

        public Habit(string title, string description, int timesCompleted, Guid categoryId)
        {
            Title = title;
            Description = description;
            TimesCompleted = timesCompleted;
            CategoryId = categoryId;
            IsActive = true;

            Validate();
        }

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;
        
        public void UpdateCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void UpdateDescription(string description) => Description = description;

        public void DidHabit() => TimesDidIt++;

        public void Validate()
        {
            AssertionConcern.ValidateIfEmpty(Title, "The title of the habit cannot be empty.");
            AssertionConcern.ValidateCharacters(Title, 3, 100, "The title of the habit must be between 3 and 100 characters.");
            AssertionConcern.ValidateIfEmpty(Description, "The description of the habit cannot be empty.");
            AssertionConcern.ValidateCharacters(Description, 5, 500, "The description of the habit must be between 5 and 500 characters.");
            AssertionConcern.ValidateMinimumMaximum(TimesDidIt, 0, int.MaxValue, "The frequency of the habit must be a non-negative integer.");
            AssertionConcern.ValidateIfEquals(CategoryId, Guid.Empty, "The category ID of the habit must be a valid GUID.");
        }
    }
}
