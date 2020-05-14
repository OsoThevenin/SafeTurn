using System;
using CleanArchitecture.Domain.Common;

namespace SafeTurn.Domain.Users
{
    public class RefreshToken : IEntity
    {
        public Guid Id { get; set; }
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public int UserId { get; private set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; private set; }

        public RefreshToken(string token, DateTime expires,int userId,string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
