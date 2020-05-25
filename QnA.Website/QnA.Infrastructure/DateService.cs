using QnA.Domain.Interfaces;
using System;

namespace QnA.Infrastructure
{
    public class DateService : IDateService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
