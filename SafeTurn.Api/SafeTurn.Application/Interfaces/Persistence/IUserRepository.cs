using SafeTurn.Domain.Users;

namespace SafeTurn.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
    }
}
