using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class RabbitMQConsumer
    {
        private readonly RabbitSettings _settings;

        public RabbitMQConsumer(IOptions<RabbitSettings> options)
        {
            _settings = options.Value;
        }

        public async Task StartConsuming<T>(Func<T, Task> onMessageReceived)
        {
            var factory = new ConnectionFactory() { HostName = _settings.HostName };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: _settings.QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var deserialized = JsonSerializer.Deserialize<T>(message);
                    if (deserialized != null)
                    {
                        await onMessageReceived(deserialized);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Failed to process message: {ex.Message}");
                }

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(
                queue: _settings.QueueName,
                autoAck: true,
                consumer: consumer);
        }
    }
}
