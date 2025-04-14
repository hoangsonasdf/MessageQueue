using Microsoft.Extensions.Options;
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
        private readonly RabbitSettings _settings;

        public RabbitMQPublisher(IOptions<RabbitSettings> options)
        {
            _settings = options.Value;
        }

        public async Task Publish<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = _settings.HostName };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: _settings.QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            await channel.BasicPublishAsync(exchange: "",
                                 routingKey: _settings.QueueName,
                                 body: body);
        }
    }
}
