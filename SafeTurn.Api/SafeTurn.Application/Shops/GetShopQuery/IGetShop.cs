using SafeTurn.Domain.Shops;
using System;

namespace SafeTurn.Application.Shops.GetShopQuery
{
    public interface IGetShop
    {
        GetShopModel Execute(Guid id);
    }
}
