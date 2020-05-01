using CleanArchitecture.Domain.Common;
using System;

namespace SafeTurn.Domain.Shops
{
    public class Shop :IEntity
    {
        public Guid Id { get; set; }
    }
}
