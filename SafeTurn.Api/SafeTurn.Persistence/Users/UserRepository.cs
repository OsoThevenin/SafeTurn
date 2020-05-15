using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.User;
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

        public async Task<CreateUserResponse> CreateAsync(string firstName, string lastName, string email, string password)
        {
            var response = new CreateUserResponse();
            var appUser = new AppUser { Email = email, UserName = email };
            var identityResult = await _userManager.CreateAsync(appUser, password);

            if (!identityResult.Succeeded) 
            {
                response.IsSuccess = false;
                response.Errors = new List<Exception>();
                foreach (var error in identityResult.Errors)
                {
                    response.Errors.Add(new UserExceptionCreate(error.Description));
                }
                return response;
            }
          
            var user = new User(firstName, lastName, appUser.Id, appUser.UserName);
            _database.Users.Add(user);
            _database.Save();
            response.IsSuccess = true;
            return response;
        }

        public async Task DeleteAsync(string email)
        {
            await _userManager.DeleteAsync(_userManager.Users.Single(u => u.Email == email));
            _database.Users.Remove(_database.Users.Single(u => u.Email == email));
            _database.Save();
        }

        public async Task<string> GetTokenEmailAsync(string email)
        {
            var user = _userManager.Users.Single(u => u.Email == email);
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
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
