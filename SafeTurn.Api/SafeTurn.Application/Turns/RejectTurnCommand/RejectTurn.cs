using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Turns.RejectTurnCommand
{
    public class RejectTurn : IRejectTurn
    {
        private readonly ITurnRepository _turnRepo;
        private readonly IUnitOfWork _uow;

        public RejectTurn
        (
            ITurnRepository turnRepo,
            IUnitOfWork uow
        )
        {
            _turnRepo = turnRepo;
            _uow = uow;
        }

        public void Execute(RejectTurnModel model)
        {
            var turn = _turnRepo.Get(model.TurnId);
            _turnRepo.Remove(turn);
            _uow.Save();
        }
    }
}
