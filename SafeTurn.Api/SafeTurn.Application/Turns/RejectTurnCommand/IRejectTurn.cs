namespace SafeTurn.Application.Turns.RejectTurnCommand
{
    public interface IRejectTurn
    {
        void Execute(RejectTurnModel model);
    }
}
