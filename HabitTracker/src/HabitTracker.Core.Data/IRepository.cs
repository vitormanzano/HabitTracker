using HabitTracker.Core.DomainObjects;

namespace HabitTracker.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot // One repository per aggregate root
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
