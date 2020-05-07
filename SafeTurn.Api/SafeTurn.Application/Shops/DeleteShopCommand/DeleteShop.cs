using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Shops.DeleteShopCommand
{
    public class DeleteShop : IDeleteShop
    {
        private readonly IShopRepository _shopRepo;
        private readonly IUnitOfWork _uow;

        public DeleteShop
        (
            IShopRepository shopRepo,
            IUnitOfWork uow
        )
        {
            _shopRepo = shopRepo;
            _uow = uow;
        }

        public void Execute(DeleteShopModel modal)
        {
            var shop = _shopRepo.Get(modal.ShopId);
            _shopRepo.Remove(shop);
            _uow.Save();  
        }
    }
}
