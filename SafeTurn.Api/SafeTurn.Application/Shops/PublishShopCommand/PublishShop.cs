using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Shops.PublishShopCommand
{
    public class PublishShop : IPublishShop
    {
        private readonly IShopRepository _shopRepo;
        private readonly IUnitOfWork _uow;

        public PublishShop(
            IShopRepository shopRepo,
            IUnitOfWork uow
        ) {
            _shopRepo = shopRepo;
            _uow = uow;
        }

        public void Execute(PublishShopModel model)
        {
            var shop = _shopRepo.Get(model.ShopId);
            if (model.Publish) shop.Publish();
            else shop.Unpublish();
            _shopRepo.Update(shop);
            _uow.Save();
        }
    }
}
