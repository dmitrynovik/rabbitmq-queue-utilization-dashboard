
using System.Globalization;
using Microsoft.Extensions.Configuration;

public class RabbitMQConfig {
    private readonly IConfiguration configuration;

    public RabbitMQConfig(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public string Host => configuration["RabbitMQ.Host"];
    public string Schema => configuration["RabbitMQ.Schema"];
    public string User => configuration["RabbitMQ.User"];
    public string Password => configuration["RabbitMQ.Password"];
    public int Port => int.Parse(configuration["RabbitMQ.Port"]);

    public string GetUrl() => $"{Schema}://{User}:{Password}@{Host}:{Port}";
}