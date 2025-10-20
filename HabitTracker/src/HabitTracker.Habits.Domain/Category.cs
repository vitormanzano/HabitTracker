using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
