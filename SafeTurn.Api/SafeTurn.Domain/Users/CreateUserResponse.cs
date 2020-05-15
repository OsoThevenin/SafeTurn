using System;
using System.Collections.Generic;

namespace SafeTurn.Domain.Users
{
    public class CreateUserResponse
    {
        public bool IsSuccess { get; set; }
        public List<Exception> Errors { get; set; }

        public CreateUserResponse()
        {
            Errors = new List<Exception>();
        }
    }
}