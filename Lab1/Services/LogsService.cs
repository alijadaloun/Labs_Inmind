using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Lab1.Services;

public class LogsService: BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public LogsService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Log log = new Log();

        var factory = new ConnectionFactory() { HostName = "localhost" };
        await using( var connection = await factory.CreateConnectionAsync(stoppingToken))
        await using (var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken))
        {
            await channel.QueueDeclareAsync(queue: "RabbitQueue", durable: true, exclusive: false, autoDelete: false,
                arguments: null, cancellationToken: stoppingToken);
            var message = JsonConvert.SerializeObject(log);
            var body = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "", body: body, basicProperties: new BasicProperties(), mandatory: true, cancellationToken: stoppingToken);
            //ready to be consumed by a consumer service

        }
            
    }

    
}