public class MetricsConfig {
    private readonly IConfiguration configuration;

    public MetricsConfig(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public int PollingInterval => int.Parse(configuration["Metrics.PollingInterval"]);
}