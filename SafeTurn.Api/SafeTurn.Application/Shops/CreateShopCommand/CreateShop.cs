
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;

namespace SafeTurn.Application.Shops.CreateShopCommand
{
    public class CreateShop : ICreateShop
    {
        private readonly IShopRepository _shopRepo;
        private readonly IUnitOfWork _uow;

        public CreateShop(
            IShopRepository shopRepo,
            IUnitOfWork uow
        ) {
            _shopRepo = shopRepo;
            _uow = uow;
        }

        public void Execute(CreateShopModel model)
        {
            _shopRepo.Add(new Shop(model.Code, model.Name));
            _uow.Save();
        }
    }
}
