using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using System;

namespace SafeTurn.Application.Shops.GetShopQuery
{
    public class GetShop : IGetShop
    {
        private readonly IShopQueries _shopQueries;

        public GetShop(IShopQueries shopQueries)
        {
            _shopQueries = shopQueries;
        }

        public GetShopModel Execute(Guid id)
        {
            return _shopQueries.GetShop(id);
        }
    }
}
