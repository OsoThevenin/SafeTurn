using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using System;

namespace SafeTurn.Application.Shops.GetShopQuery
{
    public class GetShop : IGetShop
    {
        private readonly IShopRepository _shopRepo;

        public GetShop(IShopRepository shopRepo)
        {
            _shopRepo = shopRepo;
        }

        public Shop Execute(Guid id)
        {
            return _shopRepo.GetByIdWithTurns(id);
        }
    }
}
