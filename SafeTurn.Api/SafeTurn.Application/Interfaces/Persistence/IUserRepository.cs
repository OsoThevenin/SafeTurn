using System.Threading.Tasks;
using SafeTurn.Domain.Users;

namespace SafeTurn.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
        Task<CreateUserResponse> CreateAsync(string firstName, string lastName, string email, string password);
        Task DeleteAsync(string email);
        Task<string> GetTokenEmailAsync(string email);
    }
}
