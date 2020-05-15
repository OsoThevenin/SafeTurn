using System;

namespace SafeTurn.Application.Auth.RegisterCommand
{
    public class RegisterExceptionWrongRepeat : Exception
    {
        public RegisterExceptionWrongRepeat() : base("Password and repeat password do not match") { }  
    }

    public class RegisterExceptionInvalidEmail : Exception
    {
        public RegisterExceptionInvalidEmail() : base("Invalid Email") { }  
    }
}
