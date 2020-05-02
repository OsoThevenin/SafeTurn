
using System;
using System.Linq;
using CleanArchitecture.Domain.Common;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Persistence.DataAccess;

namespace SafeTurn.Persistence.Shared
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly ApplicationDbContext _database;

        public Repository(ApplicationDbContext database)
        {
            _database = database;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T Get(Guid id)
        {
            return _database.Set<T>()
                .Single(p => p.Id == id);
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }
    }
}
