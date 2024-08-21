using System;

public class MetricsService : IHostedService
{
    private readonly RabbitMQService rabbitMQService;
    private readonly ILogger<MetricsService> log;
    private bool started;

    public MetricsService(RabbitMQService rabbitMQService, LoggerFactory loggerFactory)
    {
        this.rabbitMQService = rabbitMQService;
        log = loggerFactory.CreateLogger<MetricsService>();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
       started = true;
       while (started) {
           var queueResponse = await rabbitMQService.getQueues();
           log.LogInformation("received queues: " + queueResponse.Length);
           Thread.Sleep(10000);
       }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        started = false;
        return Task.CompletedTask;
    }
}
