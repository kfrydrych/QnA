using Microsoft.EntityFrameworkCore.Infrastructure;
using QnA.Domain.Common;
using System;

namespace QnA.Persistence.Exceptions
{
    public class ResourceOwnerNotProvidedException : Exception
    {
        public readonly Type Type;

        public ResourceOwnerNotProvidedException(Type type, AuditableEntity entity)
            : base($"{entity.GetType().ShortDisplayName()} resource has no owner")
        {
            Type = type;
        }
    }
}
