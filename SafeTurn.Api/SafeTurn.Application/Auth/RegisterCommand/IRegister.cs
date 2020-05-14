using System.Threading.Tasks;

namespace SafeTurn.Application.Auth.RegisterCommand
{
    public interface IRegister
    {
        Task ExecuteAsync(RegisterModel model);
    }
}