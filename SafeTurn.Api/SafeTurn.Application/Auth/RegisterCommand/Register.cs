
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SafeTurn.Application.Interfaces.Infrastucture;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Users;

namespace SafeTurn.Application.Auth.RegisterCommand
{
    public class Register : IRegister
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        private readonly IEmailService _emailService;

        public Register(
            IConfiguration config,
            IUserRepository userRepo,
            IEmailService emailService
        ) {
            _config = config;
            _userRepo = userRepo;
            _emailService = emailService;
        }

        public async Task<CreateUserResponse> ExecuteAsync(RegisterModel model)
        {
            var response = await CreateUser(model);
            if (response.IsSuccess) response = await SendConfirmationEmail(model);
            if (!response.IsSuccess)
            {
                await DeleteUser(model.Email);
            }
            return response;
        }


        private async Task<CreateUserResponse> CreateUser(RegisterModel model) {
            var response = new CreateUserResponse();
            if (model.Password != model.RepeatPassword)
                response.Errors.Add(new RegisterExceptionWrongRepeat());
            if (!ValidEmail(model.Email))
                response.Errors.Add(new RegisterExceptionInvalidEmail());
            if (response.Errors.Count > 0)
            {
                response.IsSuccess = false;
                return response;
            }
            return await _userRepo.CreateAsync(model.Name, model.Surname, model.Email, model.Password);
        }
        
        private async Task DeleteUser(string email)
        {
            await _userRepo.DeleteAsync(email);
        }

        private async Task<CreateUserResponse> SendConfirmationEmail(RegisterModel model)
        {
            var token = _userRepo.GetTokenEmailAsync(model.Email);
            var callbackLink = _config["Smtp:ClientUrl"]
                + 
            try
            {
                _emailService.SendRegisterConfirmationEmailAsync(model.Email, model.Name, )
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private bool ValidEmail(string email)
        {
            try
            {
                var m = new MailAddress(email);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}