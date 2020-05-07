using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Persistence.DataAccess;

namespace SafeTurn.Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _database;

        public UnitOfWork(ApplicationDbContext database)
        {
            _database = database;
        }

        public void Save()
        {
            _database.Save();
        }
    }
}
