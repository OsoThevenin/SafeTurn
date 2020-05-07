using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Shops.UpdateShopCommand
{
    public class UpdateShop : IUpdateShop
    {
        private readonly IShopRepository _shopRepo;
        private readonly IUnitOfWork _uow;

        public UpdateShop(
            IShopRepository shopRepo,
            IUnitOfWork uow
        ) {
            _shopRepo = shopRepo;
            _uow = uow;
        }

        public void Execute(UpdateShopModel model)
        {
            var shop = _shopRepo.Get(model.ShopId);
            shop.Update(model.Name, model.SimultaneousTurns, model.MinutesForTurn);
            _shopRepo.Update(shop);
            _uow.Save();
        }
    }
}
