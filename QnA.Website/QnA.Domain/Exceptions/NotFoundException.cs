using System;

namespace QnA.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public readonly Type Type;

        public NotFoundException(Type type, string message) : base(message)
        {
            Type = type;
        }
    }
}
