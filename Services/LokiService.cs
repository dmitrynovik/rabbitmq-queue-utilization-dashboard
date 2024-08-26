using Serilog;
using Serilog.Core;
using Serilog.Sinks.Grafana.Loki;

public class LokiService {
    private readonly Logger logger;

    public LokiService(LokiConfig lokiConfig) {
       logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.GrafanaLoki(
                lokiConfig.GetConnectionString(),
                [new() { Key = "service_name", Value = "rabbitmq-queue-utilization" }]
             )
            .CreateLogger();
    }

    public void LogQueueResponse(QueueMaxLenPolicyUtilization qu) {
        logger.Information(CreateQueueResponse(qu));
    }

    public string CreateQueueResponse(QueueMaxLenPolicyUtilization qu) => 
        $"vhost={qu.vhost} queue={qu.queue} utilisation={qu.utilization}";
}