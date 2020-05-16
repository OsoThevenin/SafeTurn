
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SafeTurn.Application.Interfaces.Infrastucture;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Users;
using System;
using System.Collections.Generic;

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
            if (!response.IsSuccess) return response;
            response = await SendConfirmationEmail(model);
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
            try
            {
                var token = await _userRepo.GetTokenEmailAsync(model.Email);
                var callbackUrl = _config["Smtp:ClientUrl"]
                    + "login/valid_token/"
                    + model.Email + "/"
                    + Uri.EscapeDataString(token);
                await _emailService.SendRegisterConfirmationEmailAsync(model.Email, model.Name, callbackUrl);
                return new CreateUserResponse()
                {
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new CreateUserResponse()
                {
                    IsSuccess = false,
                    Errors = new List<Exception>() { e }
                };
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