using Moq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SafeTurn.Application.Shops.UpdateShopCommand
{
    public class UpdateShopTest
    {
        private UpdateShop _service;
        private Mock<IShopRepository> _shopRepo;
        private Mock<IUnitOfWork> _uow;
        UpdateShopModel model;

        public UpdateShopTest()
        {
            model = new UpdateShopModel()
            {
                MinutesForTurn = 5,
                Name = "name 2",
                SimultaneousTurns = 5
            };
            var returnShop = new Shop("code 1", "name 1")
            {
                MinutesForTurn = 1,
                SimultaneousTurns = 1
            };
            _shopRepo = new Mock<IShopRepository>();
            _shopRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnShop)
                .Verifiable();
            _shopRepo.Setup(x => x.Update(It.Is<Shop>(s => 
                    s.Name == model.Name
                    && s.MinutesForTurn == model.MinutesForTurn
                    && s.SimultaneousTurns == model.SimultaneousTurns
                    && s.Code == returnShop.Code)))
                .Verifiable();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Save()).Verifiable();

            _service = new UpdateShop(_shopRepo.Object, _uow.Object);
        }

        [Fact]
        public void UpdateShop()
        {
            _service.Execute(model);
            _shopRepo.VerifyAll();
            _uow.VerifyAll();
        }
    }
}
