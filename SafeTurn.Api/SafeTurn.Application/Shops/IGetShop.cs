using SafeTurn.Domain.Shops;
using System;

namespace SafeTurn.Application.Shops
{
    public interface IGetShop
    {
        Shop Execute(Guid id);
    }
}
