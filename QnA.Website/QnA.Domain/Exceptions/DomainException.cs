using System;

namespace QnA.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public readonly Type Type;

        public DomainException(Type type, string message) : base(message)
        {
            Type = type;
        }
    }
}
