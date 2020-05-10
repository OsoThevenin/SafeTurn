using Moq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using System;
using Xunit;

namespace SafeTurn.Application.Shops.DeleteShopCommand
{
    public class DeleteShopTest
    {
        private DeleteShop _service;
        private Mock<IShopRepository> _shopRepo;
        private Mock<IUnitOfWork> _uow;
        private DeleteShopModel model;

        public DeleteShopTest()
        {
            _shopRepo = new Mock<IShopRepository>();
            _shopRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(It.IsAny<Shop>)
                .Verifiable();
            _shopRepo.Setup(x => x.Remove(It.IsAny<Shop>()))
                .Verifiable();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Save()).Verifiable();

            _service = new DeleteShop(_shopRepo.Object, _uow.Object);

            model = new DeleteShopModel()
            {
                ShopId = Guid.NewGuid()
            };
        }

        [Fact]
        public void CreateShop()
        {
            _service.Execute(model);
            _shopRepo.VerifyAll();
            _uow.VerifyAll();
        }
    }
}
