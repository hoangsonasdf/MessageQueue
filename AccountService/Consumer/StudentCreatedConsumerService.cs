using AccountService.Services.IServices;
using RabbitMQ.Events;
using RabbitMQ;
using Core.DTOs.Request;

namespace StudentService.Consumer
{
    public class StudentCreatedConsumerService : BackgroundService
    {
        private readonly RabbitMQConsumer _consumer;
        private readonly IServiceScopeFactory _scopeFactory;


        public StudentCreatedConsumerService(RabbitMQConsumer consumer, IServiceScopeFactory scopeFactory)
        {
            _consumer = consumer;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumer.StartConsuming<StudentCreatedEvent>(async (message) =>
            {
                Console.WriteLine($"[Consumer] Creating account for: {message.Name}");
                using var scope = _scopeFactory.CreateScope();
                var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();

                await accountService.AddAccount(new AddAccountRequest
                {
                    StudentId = message.Id,
                    UserName = message.Name,
                    Password = "123456",
                });
            });
        }
    }

}
