using SafeTurn.Domain.Shops;
using System;

namespace SafeTurn.Application.Shops.GetShopQuery
{
    public interface IGetShop
    {
        Shop Execute(Guid id);
    }
}
