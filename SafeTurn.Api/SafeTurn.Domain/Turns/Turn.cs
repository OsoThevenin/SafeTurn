using CleanArchitecture.Domain.Common;
using System;

namespace SafeTurn.Domain.Turns
{
    public class Turn : IEntity
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }

        public Turn(string clientName)
        {
            ClientName = clientName;
        }
    }
}
