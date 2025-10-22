using HabitTracker.Core.DomainObjects;

namespace HabitTracker.Habits.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            Name = name;
        }
    }
}
