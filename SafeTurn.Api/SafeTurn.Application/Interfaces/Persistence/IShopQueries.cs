using SafeTurn.Application.Shops.GetShopQuery;
using System;

namespace SafeTurn.Application.Interfaces.Persistence
{
    public interface IShopQueries
    {
        GetShopModel GetShop(Guid id);
    }
}
