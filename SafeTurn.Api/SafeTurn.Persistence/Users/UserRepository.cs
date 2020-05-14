using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Users;
using SafeTurn.Persistence.DataAccess;
using SafeTurn.Persistence.Identity;
using SafeTurn.Persistence.Shared;

namespace SafeTurn.Persistence.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly UserManager<AppUser> _userManager;
        

        public UserRepository(UserManager<AppUser> userManager, ApplicationDbContext database) : base(database)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateAsync(string firstName, string lastName, string email, string userName, string password)
        {
            var appUser = new AppUser { Email = email, UserName = userName };
            var identityResult = await _userManager.CreateAsync(appUser, password);

            if (!identityResult.Succeeded) throw new Exception("not valid");
          
            var user = new User(firstName, lastName, appUser.Id, appUser.UserName);
            _database.Users.Add(user);
            _database.Save();

            return user;
        }

        public User FindByName(string userName)
        {
            return _database.Users.Single(u => u.Email == userName);
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(new AppUser() { UserName = user.Email, Email = user.Email }, password);
        }
        
        public User GetByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
