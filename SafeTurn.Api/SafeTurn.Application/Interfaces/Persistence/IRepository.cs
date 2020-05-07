using System;
using System.Linq;

namespace SafeTurn.Application.Interfaces.Persistence
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
