using Moq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using System;
using Xunit;

namespace SafeTurn.Application.Shops.PublishShopCommand
{
    public class PublishShopTest
    {
        private PublishShop _service;
        private Mock<IShopRepository> _shopRepo;
        private Mock<IUnitOfWork> _uow;

        public PublishShopTest()
        {
            _shopRepo = new Mock<IShopRepository>();
            _shopRepo.Setup(x => x.Update(It.IsAny<Shop>()))
                .Verifiable();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Save()).Verifiable();

            _service = new PublishShop(_shopRepo.Object, _uow.Object);

        }

        [Fact]
        public void PublishShop()
        {
            var returnShop = new Shop("codede", "name")
            {
                Published = false
            };
            _shopRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnShop)
                .Verifiable();
            var model = new PublishShopModel()
            {
                ShopId = Guid.NewGuid(),
                Publish = true
            };

            _service.Execute(model);
            _shopRepo.VerifyAll();
            _uow.VerifyAll();
        }

        [Fact]
        public void PublishShopAlready()
        {
            var returnShop = new Shop("codede", "name")
            {
                Published = true
            };
            _shopRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnShop)
                .Verifiable();
            var model = new PublishShopModel()
            {
                ShopId = Guid.NewGuid(),
                Publish = true
            };

            _service.Execute(model);
            _shopRepo.VerifyAll();
            _uow.VerifyAll();
        }

        [Fact]
        public void UnpublishShop()
        {
            var returnShop = new Shop("codede", "name")
            {
                Published = true
            };
            _shopRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnShop)
                .Verifiable();
            var model = new PublishShopModel()
            {
                ShopId = Guid.NewGuid(),
                Publish = false
            };

            _service.Execute(model);
            _shopRepo.VerifyAll();
            _uow.VerifyAll();
        }

        [Fact]
        public void UnpublishShopAlready()
        {
            var returnShop = new Shop("codede", "name")
            {
                Published = false
            };
            _shopRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnShop)
                .Verifiable();
            var model = new PublishShopModel()
            {
                ShopId = Guid.NewGuid(),
                Publish = false
            };

            _service.Execute(model);
            _shopRepo.VerifyAll();
            _uow.VerifyAll();
        }
    }
}
