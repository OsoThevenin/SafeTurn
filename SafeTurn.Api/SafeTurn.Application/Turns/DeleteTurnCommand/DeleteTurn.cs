using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Turns.DeleteTurnCommand
{
    public class DeleteTurn : IDeleteTurn
    {
        private readonly ITurnRepository _turnRepo;
        private readonly IUnitOfWork _uow;

        public DeleteTurn
        (
            ITurnRepository turnRepo,
            IUnitOfWork uow
        ) {
            _turnRepo = turnRepo;
            _uow = uow;
        }

        public void Execute(DeleteTurnModel model)
        {
            var turn = _turnRepo.Get(model.TurnId);
            _turnRepo.Remove(turn);
            _uow.Save();
        }
    }
}
