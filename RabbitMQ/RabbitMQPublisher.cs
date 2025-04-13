using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class RabbitMQPublisher
    {
        private readonly string _hostname;
        private readonly string _queueName;

        public RabbitMQPublisher(string hostname, string queueName)
        {
            _hostname = hostname;
            _queueName = queueName;
        }

        public async Task Publish<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            await channel.BasicPublishAsync(exchange: "",
                                 routingKey: _queueName,
                                 body: messageBody);
        }
    }
}
