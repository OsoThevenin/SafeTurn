using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Auth.AuthenticateCommand;

namespace SafeTurn.Api.Login
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase {
        private readonly IAuthenticate _login;

        public AuthController(
            IAuthenticate login
        ) {
            _login = login;
        }

        public IActionResult Login(AuthenticateModel model)
        {
            var user = _login.Execute(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }
    }
}