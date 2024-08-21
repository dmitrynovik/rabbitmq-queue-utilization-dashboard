
using Microsoft.Extensions.Configuration;

public class RabbitMQConfig {
    private readonly IConfiguration configuration;

    public RabbitMQConfig(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public string Host => configuration["RabbitMQ.Host"];
}