using System;

public class RabbitMQMetricsService : IHostedService
{
    private bool started;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        started = false;
        return Task.CompletedTask;
    }
}
