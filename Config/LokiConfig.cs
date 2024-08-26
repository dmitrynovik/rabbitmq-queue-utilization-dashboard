
public class LokiConfig {
    private readonly IConfiguration configuration;

    public LokiConfig (IConfiguration configuration) {
        this.configuration = configuration;
    }

    public string Tenant => configuration["Loki.Tenant"];
    public string Schema => configuration["Loki.Schema"];
    public string Host => configuration["Loki.Host"];
    public int Port => int.Parse(configuration["Loki.Port"]);

    public string GetConnectionString() =>
        $"{Schema}://{Host}:{Port}";
}