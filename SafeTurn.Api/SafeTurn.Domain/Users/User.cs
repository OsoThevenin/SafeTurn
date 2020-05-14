using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Common;

namespace SafeTurn.Domain.Users
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityId { get; set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        private User() { /* Required by EF */ }
        
        public User(string firstName, string lastName, string identityId, string email)
        {
            Name = firstName;
            Surname = lastName;
            IdentityId = identityId;
            Email = email;
        }

        public bool HasValidRefreshToken(string refreshToken)
        {
            return _refreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        public void AddRefreshToken(string token,int userId,string remoteIpAddress,double daysToExpire=5)
        {
            _refreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire),userId, remoteIpAddress));
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            _refreshTokens.Remove(_refreshTokens.First(t => t.Token == refreshToken));
        }
    }
}