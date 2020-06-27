using System.Threading.Tasks;

namespace QnA.Application.Interfaces
{
    public interface IMessageBroker
    {
        Task Publish<T>(T @event) where T : class;
    }
}