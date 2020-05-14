namespace SafeTurn.Application.Auth.AuthenticateCommand
{
    public interface IAuthenticate
    {
        string Execute(AuthenticateModel model);
    }
}