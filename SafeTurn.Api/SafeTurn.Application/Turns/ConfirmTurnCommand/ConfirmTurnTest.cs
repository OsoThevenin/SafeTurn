
using Moq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Turns;
using System;
using System.Collections.Generic;
using Xunit;

namespace SafeTurn.Application.Turns.ConfirmTurnCommand
{
    public class ConfirmTurnTest
    {
        private readonly ConfirmTurn _service;
        private readonly Mock<ITurnRepository> _turnRepo;
        private readonly Mock<IUnitOfWork> _uow;

        public ConfirmTurnTest()
        {
            _turnRepo = new Mock<ITurnRepository>();
            _uow = new Mock<IUnitOfWork>();
            _service = new ConfirmTurn(_turnRepo.Object, _uow.Object);

        }

        [Fact]
        public void ConfirmTurn()
        {
            var returnTurn = new Turn(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<string>(), new List<int>())
            {
                Confirmed = false
            };
            var model = new ConfirmTurnModel() { TurnId = Guid.NewGuid() };
            _turnRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnTurn)
                .Verifiable();
            _turnRepo.Setup(x => x.Update(It.Is<Turn>(t => t.Confirmed == true)))
                .Verifiable();
            _uow.Setup(x => x.Save()).Verifiable();
            
            _service.Execute(model);
            _turnRepo.VerifyAll();
            _uow.VerifyAll();
        }


        [Fact]
        public void ConfirmTurnAlreadyConfirmed()
        {
            var returnTurn = new Turn(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<string>(), new List<int>())
            {
                Confirmed = true
            };
            var model = new ConfirmTurnModel() { TurnId = Guid.NewGuid() };
            _turnRepo.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(returnTurn)
                .Verifiable();
            //_turnRepo.Setup(x => x.Update(It.Is<Turn>(t => t.Confirmed == true)))
            //    .Verifiable();
            //_uow.Setup(x => x.Save()).Verifiable();


            Assert.Throws<TurnExceptionAlreadyEXist>(() => _service.Execute(model));
            _turnRepo.VerifyAll();
            _uow.VerifyAll();
        }
    }
}
