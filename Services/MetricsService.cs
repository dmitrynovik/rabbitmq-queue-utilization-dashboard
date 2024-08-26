using System;

public class MetricsService : IHostedService
{
    private readonly MetricsConfig metricsConfig;
    private readonly RabbitMQService rabbitMQService;
    private readonly LokiService lokiService;
    private readonly ILogger<MetricsService> log;
    private bool started;

    public MetricsService(MetricsConfig metricsConfig, 
        RabbitMQService rabbitMQService,
        LokiService lokiService,
        LoggerFactory loggerFactory)
    {
        this.metricsConfig = metricsConfig;
        this.rabbitMQService = rabbitMQService;
        this.lokiService = lokiService;
        log = loggerFactory.CreateLogger<MetricsService>();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
       started = true;
       while (started) {
           var queues = await rabbitMQService.getQueues();
           log.LogInformation("received queues: " + queues.Length);
           
           foreach (var queue in queues) {
              var qu = RabbitMQService.convert(queue);
              lokiService.LogQueueResponse(qu);
           }
           
           Thread.Sleep(metricsConfig.PollingInterval);
       }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        started = false;
        return Task.CompletedTask;
    }
}
