using System.Threading.Tasks;
using SafeTurn.Domain.Users;

namespace SafeTurn.Application.Auth.RegisterCommand
{
    public interface IRegister
    {
        Task<CreateUserResponse> ExecuteAsync(RegisterModel model);
    }
}