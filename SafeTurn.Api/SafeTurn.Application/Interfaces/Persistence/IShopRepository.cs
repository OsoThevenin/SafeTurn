using SafeTurn.Domain.Shops;
using System;

namespace SafeTurn.Application.Interfaces.Persistence
{
    public interface IShopRepository : IRepository<Shop>
    {
        Shop GetByCodeWithTurns(string code);
        Shop GetByIdWithTurns(Guid id);
    }
}
