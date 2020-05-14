using System;
using System.Threading.Tasks;
using SafeTurn.Application.Interfaces.Persistence;

namespace SafeTurn.Application.Auth.RegisterCommand
{
    public class Register : IRegister
    {
        private readonly IUserRepository _userRepo;

        public Register(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task ExecuteAsync(RegisterModel model)
        {
            if (model.Password != model.RepeatPassword) throw new Exception("eres caca");
            await _userRepo.CreateAsync(model.Name, model.Surname, model.Email, model.Password);
        }
    }
}