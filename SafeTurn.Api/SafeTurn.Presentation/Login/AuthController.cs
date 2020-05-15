using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Auth.AuthenticateCommand;
using SafeTurn.Application.Auth.RegisterCommand;

namespace SafeTurn.Api.Login
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase {
        
        private readonly IAuthenticate _login;
        private readonly IRegister _register;

        public AuthController(
            IAuthenticate login,
            IRegister register
        ) {
            _login = login;
            _register = register;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticateModel model)
        {
            var user = _login.Execute(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(RegisterModel model)
        {
            try
            {
                var response = await _register.ExecuteAsync(model);
                if (response.IsSuccess) return Ok();
                return BadRequest(response.Errors.Select(e => e.Message));
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }
    }
}