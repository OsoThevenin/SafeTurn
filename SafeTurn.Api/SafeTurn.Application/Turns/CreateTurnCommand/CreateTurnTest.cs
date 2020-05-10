using Moq;
using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Turns.CreateTurnCommand
{
    public class CreateTurnTest
    {
        private Mock<IShopRepository> _shopRepo;
        private Mock<ITurnRepository> _turnRepo;
        private Mock<IUnitOfWork> _uow;
        private CreateTurn _service;

        public CreateTurnTest()
        {
            _shopRepo = new Mock<IShopRepository>();
            _turnRepo = new Mock<ITurnRepository>();
            _uow = new Mock<IUnitOfWork>();
            _service = new CreateTurn(_shopRepo.Object, _turnRepo.Object, _uow.Object);
        }


    }
}
