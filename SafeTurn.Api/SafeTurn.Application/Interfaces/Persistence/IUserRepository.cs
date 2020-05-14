using System.Threading.Tasks;
using SafeTurn.Domain.Users;

namespace SafeTurn.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
        Task CreateAsync(string firstName, string lastName, string email, string password);
    }
}
