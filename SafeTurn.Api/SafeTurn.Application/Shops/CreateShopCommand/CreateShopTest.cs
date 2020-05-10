using Moq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using Xunit;

namespace SafeTurn.Application.Shops.CreateShopCommand
{
    public class CreateShopTest
    {
        private CreateShop _service;
        private Mock<IShopRepository> _shopRepo;
        private Mock<IUnitOfWork> _uow;
        private CreateShopModel model;

        public CreateShopTest()
        {
            _shopRepo = new Mock<IShopRepository>();
            _shopRepo.Setup(x => x.Add(It.IsAny<Shop>())).Verifiable();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Save()).Verifiable();

            _service = new CreateShop(_shopRepo.Object, _uow.Object);

            model = new CreateShopModel()
            {
                Code = "Codigo",
                Name = "Nombre"
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
