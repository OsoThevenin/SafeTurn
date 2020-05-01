using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Turns;
using SafeTurn.Persistence.DataAccess;
using SafeTurn.Persistence.Shared;

namespace SafeTurn.Persistence.Turns
{
    public class TurnRepository : Repository<Turn>, ITurnRepository
    {
        public TurnRepository(ApplicationDbContext database) : base(database)
        {
        }

    }
}
