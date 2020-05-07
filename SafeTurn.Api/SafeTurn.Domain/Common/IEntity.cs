using System;

namespace CleanArchitecture.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}