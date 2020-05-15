using System;

namespace SafeTurn.Domain.User
{
    public class UserExceptionCreate : Exception
    {
        public UserExceptionCreate(string message) : base(message) { }  
    }
}
