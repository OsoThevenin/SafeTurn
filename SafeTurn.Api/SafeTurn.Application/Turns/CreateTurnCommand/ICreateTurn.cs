namespace SafeTurn.Application.Turns.CreateTurnCommand
{
    public interface ICreateTurn
    {
        void Execute(CreateTurnModel model);
    }
}
