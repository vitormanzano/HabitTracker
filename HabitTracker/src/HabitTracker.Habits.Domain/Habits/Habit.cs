using HabitTracker.Core.DomainObjects;

namespace HabitTracker.Habits.Domain.Habits
{
    public class Habit : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Frequency { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public bool IsActive { get; private set; }

        public Habit(string title, string description, int frequency, Guid categoryId)
        {
            Title = title;
            Description = description;
            Frequency = frequency;
            CategoryId = categoryId;
            IsActive = true;
        }

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;
        
        public void UpdateCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void UpdateDescription(string description) => Description = description;

        public void DidHabit() => Frequency++;
    }
}
