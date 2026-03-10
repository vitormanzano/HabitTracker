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

        public Habit(string title, string description, Guid categoryId)
        {
            Title = title;
            Description = description;
            TimesCompleted = 0;
            CategoryId = categoryId;
            IsActive = true;

            Validate();
        }

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;

        public void UpdateTitle(string title)
        {
            ValidateTitle(title);
            Title = title;
        }

        private void ValidateTitle(string title)
        {
            AssertionConcern.ValidateIfEmpty(Title, "The title of the habit cannot be empty.");
            AssertionConcern.ValidateCharacters(Title, 3, 100, "The title of the habit must be between 3 and 100 characters.");
        }

        public void UpdateDescription(string description)
        {
            ValidateDescription(description);
            Description = description;
        }

        private void ValidateDescription(string description)
        {
            AssertionConcern.ValidateIfEmpty(Description, "The description of the habit cannot be empty.");
            AssertionConcern.ValidateCharacters(Description, 5, 500, "The description of the habit must be between 5 and 500 characters.");
        }

        public void UpdateCategory(Category category)
        {
            ValidateCategoryId(category.Id);
            Category = category;
            CategoryId = category.Id;
        }

        private void ValidateCategoryId(Guid categoryId)
        {
            AssertionConcern.ValidateIfEquals(CategoryId, Guid.Empty, "The category ID of the habit must be a valid GUID.");
        }

        public void DidHabit() => TimesCompleted++;
        public void UndidHabit() => TimesCompleted = TimesCompleted > 0 ? TimesCompleted - 1 : 0;

        public void Validate()
        {
            ValidateTitle(Title);
            ValidateDescription(Description);
            AssertionConcern.ValidateMinimumMaximum(TimesCompleted, 0, int.MaxValue, "The times completed of the habit must be a non-negative integer.");
        }
    }
}
