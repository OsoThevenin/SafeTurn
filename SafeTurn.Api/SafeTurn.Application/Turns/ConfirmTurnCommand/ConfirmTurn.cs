using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Turns.ConfirmTurnCommand
{
    public class ConfirmTurn : IConfirmTurn
    {
        private readonly ITurnRepository _turnRepo;
        private readonly IUnitOfWork _uow;

        public ConfirmTurn
        (
            ITurnRepository turnRepo,
            IUnitOfWork uow
        ) {
            _turnRepo = turnRepo;
            _uow = uow;
        }

        public void Execute(ConfirmTurnModel model)
        {
            var turn = _turnRepo.Get(model.TurnId);
            turn.ConfirmTurn();
            _turnRepo.Update(turn);
            _uow.Save();
        }
    }
}
