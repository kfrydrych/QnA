using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QnA.Application.Interfaces;
using QnA.Application.Messages;
using System.Text;
using System.Threading.Tasks;

namespace QnA.Infrastructure
{
    public class MessageBroker : IMessageBroker
    {
        private TopicClient _topicClient;
        private readonly IConfiguration _configuration;

        public MessageBroker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Publish<T>(T @event) where T : IMessage
        {
            var eventName = @event.GetType().Name;

            _topicClient = new TopicClient(_configuration.GetConnectionString("AzureServiceBus"), eventName);

            var data = JsonConvert.SerializeObject(@event);
            var message = new Message(Encoding.UTF8.GetBytes(data));

            await _topicClient.SendAsync(message);
        }
    }
}
